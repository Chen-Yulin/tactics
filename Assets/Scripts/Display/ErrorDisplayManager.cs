/**
  * @file ErrorDisplayManager.cs
  * @brief ��ȡÿ�����������������ߵľ��룬����ʾ����Ļ�·���UI��
  * @details  
  * ���ظýű��Ķ���RaceArea �� Canvas �� UIBottom �� ErrorDisplay �� ErrorDisplayManager \n
  * ��SpeedDisplay.cs��ͬ����һ��Speed���飬�ֱ𴢴�ÿ�������ٶȣ���ֻ��һ��CruiseError�������浱ǰ�ӽ������泵����Ѳ����
  * @param CruiseError ��ǰ�ӽ������泵����Ѳ�����
  * @param PlayerNum ��ǰ�۲�ĳ������
  * @author ���꺽
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorDisplayManager : MonoBehaviour
{
    public GameObject ErrorDisplaybox;
    private int PlayerNum;
    private double CruiseError;

    void Update()
    {
        PlayerNum = ViewModeManager.CamNum;
        CruiseError = CruiseData.DistanceError[PlayerNum];
        ErrorDisplaybox.GetComponent<TextMeshProUGUI>().text = "" + CruiseError.ToString("#0.00");
    }
}
