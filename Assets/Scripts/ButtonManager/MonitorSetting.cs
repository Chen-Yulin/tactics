/**
  * @file MonitorSetting.cs
  * @brief ʵ���û���Ӽ������Ĺ��ܲ������û��Լ�����������
  * @details 
  * ���ظýű��Ķ���TrackSelect �� Canvas ��ButtonPanel �� Panel �� AddMonotors �� MonitorDropDownManager \n
  * �û��Լ����������ð�������������Ŀ����3����������Ŀ�ꡢ�������ļ��ӽǶȡ�\n
  * ��Щ���ö���ͨ��DropDownʵ�֣�����Button��\n
  * �û��ڽ���TrackSelect�����󣬻���øýű���Start()�����������û��Ĺ������ó�ʼ����ص�DropDown��\n
  * ֮����RaceArea������MonitorManager.cs�ű������û������öԼ��������г�ʼ��ʱ����Ҫ��ȡ�ýű��д���Ĳ�����
  * @param NumofMonitor ����������
  * @param MonitorObject ���Ӷ���
  * @param MonitorPerspective ���ӽǶ�
  * @author ���꺽
  * @date 2023-12-31
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonitorSetting : MonoBehaviour
{
    public static int NumofMonitor = 0;
    public static int[] MonitorObject = new int[3] { 0, 0, 0 };
    public static int[] MonitorPerspective = new int[3] { 0, 0, 0 };

    public GameObject DropdowmMonitorNum;
    public GameObject[] DropdowmMonitorObject;
    public GameObject[] DropdowmMonitorPerspective;

    void Start()
    {
        //��ȡ��ʷ��¼
        if (PlayerPrefs.HasKey("NumofMonitor")) NumofMonitor = PlayerPrefs.GetInt("NumofMonitor");
        else NumofMonitor = 0;

        for(int i = 1; i <= 3; i++)
        {
            if (PlayerPrefs.HasKey("Monitor"+i.ToString()+ "Object"))
                MonitorObject[i-1] = PlayerPrefs.GetInt("Monitor" + i.ToString() + "Object");
            else MonitorObject[i-1] = 0;

            if (PlayerPrefs.HasKey("Monitor" + i.ToString() +"Perspective"))
                MonitorPerspective[i-1] = PlayerPrefs.GetInt("Monitor" + i.ToString() + "Perspective");
            else MonitorPerspective[i-1] = 0;
        }

        //Ĭ�ϰ�����ʷ��¼���ü�����
        DropdowmMonitorNum.GetComponent<TMP_Dropdown>().value = NumofMonitor;
        for (int i = 0; i < 3; i++)
        {
            DropdowmMonitorObject[i].GetComponent<TMP_Dropdown>().value = MonitorObject[i];
            DropdowmMonitorPerspective[i].GetComponent<TMP_Dropdown>().value = MonitorPerspective[i];
        }
    }

    /**
     * @fn SetNumofMonitor
     * @brief �û����ü���������
     * @param[in] value �û�����Ӧ��dropdown��ѡ���ѡ���š�
     * @details �û�����ͨ��dropdown(����ʽ�˵�)���ü���������������ֵ��ΪNumofMonitor����
     */
    public void SetNumofMonitor(int value)
    {
        NumofMonitor = value;
        if(NumofMonitor > 3 || NumofMonitor < 0) NumofMonitor = 0;
        PlayerPrefs.SetInt("NumofMonitor", NumofMonitor);
    }
    /**
     * @fn SetMonitor1Object
     * @brief �û�����1�ż������ļ��Ӷ���
     * @param[in] value �û�����Ӧ��dropdown��ѡ���ѡ���š�
     * @details �û�����ͨ��dropdown(����ʽ�˵�)����1�ż������ļ��Ӷ��󣬽���ֵ����MonitorObject[0]
     */
    public void SetMonitor1Object(int value)
    {
        MonitorObject[0] = value;
        if (MonitorObject[0] > 7 || MonitorObject[0] < 0) MonitorObject[0] = 0;
        PlayerPrefs.SetInt("Monitor1Object", MonitorObject[0]);
    }
    /**
     * @fn SetMonitor2Object
     * @brief �û�����2�ż������ļ��Ӷ���
     * @param[in] value �û�����Ӧ��dropdown��ѡ���ѡ���š�
     * @details �û�����ͨ��dropdown(����ʽ�˵�)����2�ż������ļ��Ӷ��󣬽���ֵ����MonitorObject[1]
     */
    public void SetMonitor2Object(int value)
    {
        MonitorObject[1] = value;
        if (MonitorObject[1] > 7 || MonitorObject[1] < 0) MonitorObject[1] = 0;
        PlayerPrefs.SetInt("Monitor2Object", MonitorObject[1]);
    }
    /**
     * @fn SetMonitor3Object
     * @brief �û�����3�ż������ļ��Ӷ���
     * @param[in] value �û�����Ӧ��dropdown��ѡ���ѡ���š�
     * @details �û�����ͨ��dropdown(����ʽ�˵�)����3�ż������ļ��Ӷ��󣬽���ֵ����MonitorObject[2]
     */
    public void SetMonitor3Object(int value)
    {
        MonitorObject[2] = value;
        if (MonitorObject[2] > 7 || MonitorObject[2] < 0) MonitorObject[2] = 0;
        PlayerPrefs.SetInt("Monitor3Object", MonitorObject[2]);
    }
    /**
     * @fn SetMonitor1Perspective
     * @brief �û�����1�ż������ļ��ӽǶ�
     * @param[in] value �û�����Ӧ��dropdown��ѡ���ѡ���š�
     * @details �û�����ͨ��dropdown(����ʽ�˵�)����1�ż������ļ��ӽǶȣ�����ֵ����MonitorPerspective[0]
     */
    public void SetMonitor1Perspective(int value)
    {
        MonitorPerspective[0] = value;
        if (MonitorPerspective[0] != 0 && MonitorPerspective[0] != 1) MonitorPerspective[0] = 0;
        PlayerPrefs.SetInt("Monitor1Perspective", MonitorPerspective[0]);
    }
    /**
     * @fn SetMonitor2Perspective
     * @brief �û�����2�ż������ļ��ӽǶ�
     * @param[in] value �û�����Ӧ��dropdown��ѡ���ѡ���š�
     * @details �û�����ͨ��dropdown(����ʽ�˵�)����2�ż������ļ��ӽǶȣ�����ֵ����MonitorPerspective[1]
     */
    public void SetMonitor2Perspective(int value)
    {
        MonitorPerspective[1] = value;
        if (MonitorPerspective[1] != 0 && MonitorPerspective[1] != 1) MonitorPerspective[1] = 0;
        PlayerPrefs.SetInt("Monitor2Perspective", MonitorPerspective[1]);
    }
    /**
     * @fn SetMonitor3Perspective
     * @brief �û�����3�ż������ļ��ӽǶ�
     * @param[in] value �û�����Ӧ��dropdown��ѡ���ѡ���š�
     * @details �û�����ͨ��dropdown(����ʽ�˵�)����3�ż������ļ��ӽǶȣ�����ֵ����MonitorPerspective[2]
     */
    public void SetMonitor3Perspective(int value)
    {
        MonitorPerspective[2] = value;
        if (MonitorPerspective[2] != 0 && MonitorPerspective[2] != 1) MonitorPerspective[2] = 0;
        PlayerPrefs.SetInt("Monitor3Perspective", MonitorPerspective[2]);
    }

}
