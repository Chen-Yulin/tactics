﻿/**
  * @file CruiseData.cs
  * @brief 计算小车距离中心线的距离、赛道曲率等
  * @details
  * 挂载该脚本的对象：：RaceArea → Car\n
  * WaypointsData为当前赛道中心点的数据，数据为xml格式，是通过CarWaypoints插件生成的。\n
  * 该插件可以很方便地获取赛道中心路标点。\n
  * 使用该插件时，需要将Editor文件夹中的CarWaypoints文件夹移动到Editor文件夹外；\n
  * 而使用完该插件后，需要将CarWaypoints文件夹放回Editor文件夹。\n
  * 该插件的使用教程可以在CarWaypoints文件夹中找到。\n
  * 计算小车距离中心线的距离的方法：\n
  * 获取距离小车最近的两个路标点，以这两点作直线，求小车距离该直线的距离。\n
  * 计算小车当前位置赛道中心线曲率的方法：\n
  * 获取离小车最近的一个路标点以及之后的第一个、第三个路标点，\n
  * 过这三个点做圆，该圆半径的倒数就为当前曲率。\n
  * @param CarNum 当前小车的编号，不同Car中CruiseData组分的CarNum数值不同
  * @param DistanceError 小车距离中心线的距离
  * @param Curvature 当前位置赛道中心线曲率
  * @param AngleError 小车方向和赛道中心线方向的差距
  * @param WaypointsData 当前赛道中心点的数据，数据为xml格式
  * @author 李雨航
  * @date 2022-01-06
  */


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CruiseData : MonoBehaviour
{
    private int lastClosestWP = -1;
    private int NumofWP;
    /// 各车辆的巡线误差
    public static float[] DistanceError = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    /// 各车辆前方的赛道曲率
    public static float[] Curvature = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    /// 各车辆的角度误差
    public static float[] AngleError = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    /// 该脚本计算的是几号车的巡线误差、赛道曲率、角度误差
    [SerializeField] public int CarNum;

    //public GameObject ErrorDisplay;
    //public GameObject RadiusDisplay;


    /// 路标点数据文件 <summary>
    /// </summary>
    public TextAsset waypointsData = null;
    /// 路标点专用XML操作 <summary>
    /// </summary>
    private WaypointsXML _WaypointsXML = new WaypointsXML();
    /// 所有路标点 <summary>
    /// </summary>
    public List<WaypointsModel> WaypointsModelAll = new List<WaypointsModel>();
    void Start()
    {
        //获取路标点数据
        _WaypointsXML.GetXmlData(WaypointsModelAll, null, waypointsData.text);
        lastClosestWP = -1;
        NumofWP = WaypointsModelAll.Count;
        //获取距离最近的路标点
        //WaypointsModel ClosestWP = GetClosestWP(WaypointsModelAll, transform.position);
    }

    void FixedUpdate()
    {
        //获取距离最近的路标点
        WaypointsModel ClosestWP = GetClosestWP(WaypointsModelAll, transform.position);
        int tmpNum1 = lastClosestWP + 1;
        int tmpNum2 = lastClosestWP - 1;
        if (tmpNum1 >= NumofWP) tmpNum1 = 0;
        if (tmpNum2 < 0) tmpNum2 = NumofWP - 1;
        float dist1 = Mathf.Pow(WaypointsModelAll[tmpNum1].Position.x - transform.position.x, 2)+ Mathf.Pow(WaypointsModelAll[tmpNum1].Position.z - transform.position.z, 2);
        float dist2 = Mathf.Pow(WaypointsModelAll[tmpNum2].Position.x - transform.position.x, 2)+ Mathf.Pow(WaypointsModelAll[tmpNum2].Position.z - transform.position.z, 2);
        if (dist1 <= dist2)//即lastClosestWP和lastClosestWP+1号路标点是离车最近的两点  
        {
            DistanceError[CarNum] = GetCruiseError(WaypointsModelAll[lastClosestWP].Position, WaypointsModelAll[tmpNum1].Position, transform.position);
        }
        else//即lastClosestWP-1和lastClosestWP号路标点是离车最近的两点  
        {
            DistanceError[CarNum] = GetCruiseError(WaypointsModelAll[tmpNum2].Position, WaypointsModelAll[lastClosestWP].Position, transform.position);
        }

        //取出后两个坐标点，用于计算曲率
        tmpNum1 = lastClosestWP;
        tmpNum2 = lastClosestWP + 1;
        int tmpNum3 = lastClosestWP + 3;
        //if (tmpNum1 < 0) tmpNum1 += NumofWP;
        if (tmpNum2 >= NumofWP) tmpNum2 -= NumofWP;
        if (tmpNum3 >= NumofWP) tmpNum3 -= NumofWP;
        Curvature[CarNum] = GetCurvature(tmpNum1, tmpNum2, tmpNum3);
        //RadiusDisplay.GetComponent<TextMeshProUGUI>().text = "" + Curvature.ToString("#0.00");
        AngleError[CarNum] = WaypointsModelAll[lastClosestWP].Rotation.y - transform.eulerAngles.y;
        //Debug.Log(string.Format("CruiseData{0} {1}:{2}", CallCppControl.a,CarNum, DistanceError[CarNum]));
        //ErrorDisplay.GetComponent<TextMeshProUGUI>().text = "" + DistanceError.ToString("#0.00");

    }
    /**
    * @fn GetCurvature
    * @brief 根据前方三个路标点获取前方道路曲率
    */
    private float GetCurvature(int WP1, int WP2, int WP3)
    {
        Vector2 pos1 = new Vector2(WaypointsModelAll[WP1].Position.x, WaypointsModelAll[WP1].Position.z);
        Vector2 pos2 = new Vector2(WaypointsModelAll[WP2].Position.x, WaypointsModelAll[WP2].Position.z);
        Vector2 pos3 = new Vector2(WaypointsModelAll[WP3].Position.x, WaypointsModelAll[WP3].Position.z);
        //判断共线
        if (Mathf.Abs(WaypointsModelAll[lastClosestWP].Rotation.y - WaypointsModelAll[WP2].Rotation.y)<0.01) return 0;
        //不共线：
        float radius;//曲率半径
        float dis, dis1, dis2, dis3;//距离
        float cosA;//ab确定的边所对应的角A的cos值
        dis1 = Vector2.Distance(pos1, pos2);
        dis2 = Vector2.Distance(pos1, pos3);
        dis3 = Vector2.Distance(pos2, pos3);
        dis = dis1 * dis1 + dis3 * dis3 - dis2 * dis2;
        cosA = dis / (2 * dis1 * dis3);//余弦定理
        radius = dis2 / (Mathf.Sqrt(1-cosA*cosA)*2);

        float cur = 1 / radius;
        return cur;
    }
    /**
    * @fn GetCruiseError
    * @brief 计算myPositon到直线pos1-pos2的距离
    * @details 方法参考https://zhuanlan.zhihu.com/p/176996694
    * @param[in] myPositon 车辆当前位置
    * @param[in] pos1 路标点1
    * @param[in] pos2 路标点2
    */
    private float GetCruiseError(Vector3 pos1, Vector3 pos2, Vector3 myPosition)
    {
        //y分量统一设为0
        Vector3 vec1 = new Vector3(pos2.x - pos1.x,0,pos2.z - pos1.z);
        Vector3 vec2 = new Vector3(myPosition.x - pos1.x,0,myPosition.z - pos1.z);
        //向量叉乘后y分量的正负性可以判断myposition在向量pos1~pos2的哪侧
        Vector3 tmp1 = Vector3.Cross(vec1, vec2);
        float WhichSide = Mathf.Sign(Vector3.Cross(vec1, vec2).y);
        float Area = tmp1.magnitude;
        float tmp2 = vec1.magnitude;
        float CruiseError = -WhichSide * Area / tmp2;//偏左为正，偏右为负；
        return CruiseError;
    }

    /// 获取距离最近的路径点 <summary>
    /// 获取距离最近的路径点
    /// </summary>
    /// <param name="DPs">路径点集合</param>
    /// <param name="myPosition">当前坐标</param>
    /// <returns>返回最近距离的路标点</returns>
    /// 
    private WaypointsModel GetClosestWP(List<WaypointsModel> all, Vector3 myPosition)
    {
        WaypointsModel tMin = null;
        float minDist = Mathf.Infinity;//正无穷
        int thisClosestWPN = -1;

        if (lastClosestWP == -1)//没有上一次调用的数据
        {
            for (int i = 0; i < NumofWP; i++)
            {
                //忽略y轴上的距离（不考虑垂直地面方向的差别）
                float dist = Mathf.Pow((all[i].Position.x - myPosition.x), 2) + Mathf.Pow((all[i].Position.z - myPosition.z), 2);
                //float dist = Vector3.Distance(all[i].Position, myPosition);
                if (dist < minDist)
                {
                    thisClosestWPN = i;
                    tMin = all[i];
                    minDist = dist;
                }
            }
        }
        else//有上一次调用的数据,只处理最近的10个路标点
        {
            int j;
            for(int i = lastClosestWP - 3; i < lastClosestWP + 3; i++)
            {
                if (i < 0) j = i + NumofWP;
                else if (i >= NumofWP) j = i - NumofWP;
                else j = i;
                float dist = Mathf.Pow((all[j].Position.x - myPosition.x), 2) + Mathf.Pow((all[j].Position.z - myPosition.z), 2);
                //float dist = Vector3.Distance(all[j].Position, myPosition);
                if (dist < minDist)
                {
                    thisClosestWPN = j;
                    tMin = all[j];
                    minDist = dist;
                }
            }
        }
        lastClosestWP = thisClosestWPN;
        return tMin;
    }
}
