/**
  * @file ScoreDisplay.cs
  * @brief ScoreMode��������У�������������ĵ÷ֲ����ڴ������Ͻ���ʾ�������ĵ÷�
  * @details  
  * ���ظýű��Ķ���RaceArea �� Canvas �� UILeft �� ScoreModeDisplay �� ScoreModeDisplay \n
  * @param CarNum ��ʾ�ýű���Ҫ��ʾ���ų����ĵ÷֡����ű�����ʾһ�ų����÷ֵ�UI���������ֵ����Ϊ0�����ű�����ʾ���ų����÷ֵ�UI���������ֵ����Ϊ1�����Դ����ơ�
  * @author ���꺽
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public static int[] Score = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public GameObject CurrentScoreDisplay;
    [SerializeField] public int CarNum;

    void Update()
    {
        CurrentScoreDisplay.GetComponent<TextMeshProUGUI>().text = "" + Score[CarNum];
    }
}
