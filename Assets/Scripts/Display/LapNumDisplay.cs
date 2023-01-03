/**
  * @file LapNumDisplay.cs
  * @brief Ѳ��ʱ�ڴ������Ͻ���ʾ��ǰ�ӽǶ�Ӧ����������ʻȦ��
  * @details  
  * ���ظýű��Ķ���RaceArea �� Canvas �� UIRight �� PanelRight �� LapNumDisplayManager \n
  * @param CarNum ��ǰ�۲�ĳ������
  * @author ���꺽
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapNumDisplay : MonoBehaviour
{
    public GameObject LapCountDisplay;
    private int CarNum;
    void Start()
    {
        CarNum = ViewModeManager.CamNum;
    }

    void Update()
    {
        CarNum = ViewModeManager.CamNum;
        LapCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapComplete.LapCount[CarNum];
    }
}
