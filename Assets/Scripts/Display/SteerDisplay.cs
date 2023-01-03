/**
  * @file SteerDisplay.cs
  * @brief ��ȡÿ�����ķ�����ת�ǣ�����ʾ����Ļ�·���UI��
  * @details  
  * ���ظýű��Ķ���RaceArea �� Canvas �� UIBottom �� SteerDisplay �� SteerDisplayManager \n
  * �ڵ�һ�˳��ӽ�ģʽ�£�������ʾ������ת����ֵ��������ʾ�����̵���ͼ��\n
  * ��SpeedDisplay.cs��ͬ����һ��Speed���飬�ֱ𴢴�ÿ�������ٶȣ���ֻ��һ��steer�������浱ǰ�ӽ������泵���ķ�����ת�ǡ�
  * @param steer ��ǰ�ӽ������泵���ķ�����ת��
  * @author ���꺽
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SteerDisplay : MonoBehaviour
{
    private float Steer;
    
    public GameObject SteerWheel;
    public GameObject steerDisplaybox;

    private int PlayerNum;

    void FixedUpdate()
    {
        PlayerNum = ViewModeManager.CamNum;//��ǰ�ӽǸ���ĳ������
        if(GameSetting.ControlMethod[PlayerNum] == 1)//Keyboard
        {
            Steer = CarControlKeyBoard.h[PlayerNum];
        }
        else//ScriptControl
        {
            Steer = CallCppControl.steering[PlayerNum];
        }
        
        SteerWheel.transform.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, Steer*-90);
        steerDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + Steer.ToString("#0.00");
    }
}
