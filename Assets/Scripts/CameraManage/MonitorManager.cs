/**
  * @file MonitorManager.cs
  * @brief ����ʱ����Ļ�Ϸ����С������ʾ�������еĻ���
  * @details  
  * ���ظýű��Ķ���RaceArea �� Canvas �� Monitors �� MonitorManager \n
  * ����MonitorSetting.cs�б�����û��Լ�������������Ӽ���������
  * @author ���꺽
  * @date 2022-12-31
  */


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonitorManager : MonoBehaviour
{
    //������UI
    public GameObject[] MonitorPanel;
    public GameObject[] MonitorImage;
    public GameObject[] MonitorDisplay;

    //����������ͷ
    public GameObject[] Cam_MainView;
    public GameObject[] Cam_LookDown;

    //������ͼ��
    public Material[] Mat_MainView;
    public Material[] Mat_LookDown;

    private int NumofMonitor = 0;
    private int[] MonitorObject = new int[3] { 0, 0, 0 };
    private int[] MonitorPerspective = new int[3] { 0, 0, 0 };

    void Start()
    {
        NumofMonitor = MonitorSetting.NumofMonitor;
        for(int i = 0; i < 3; i++)
        {
            MonitorObject[i] = MonitorSetting.MonitorObject[i];
            MonitorPerspective[i] = MonitorSetting.MonitorPerspective[i];
            MonitorDisplay[i].GetComponent<TextMeshProUGUI>().text = "P" + (MonitorObject[i] + 1).ToString();
        }

        //�����û����õļ��������������������UI�ͼ�������ͷ
        for (int i = 0; i < NumofMonitor; i++)
        {
            SetActiveMonitor(i);
        }
    }

    void SetActiveMonitor(int i)
    {
        MonitorPanel[i].SetActive(true);
        if (MonitorPerspective[i] == 1)
        {
            Cam_LookDown[MonitorObject[i]].SetActive(true);
            MonitorImage[i].GetComponent<Image>().material = Mat_LookDown[MonitorObject[i]];
        }
        else
        {
            Cam_MainView[MonitorObject[i]].SetActive(true);
            MonitorImage[i].GetComponent<Image>().material = Mat_MainView[MonitorObject[i]];
        }
    }

}
