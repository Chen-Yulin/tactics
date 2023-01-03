/**
  * @file DamageDisplay.cs
  * @brief ����������ڴ������Ͻ���ʾ�����������˳̶ȡ�
  * @details  
  * ���ظýű��Ķ���RaceArea �� Canvas �� UILeft �� ����DamageDisplay �� DamageDisplayManager
  * @param ExtentOfDamage �����������˳̶�
  * @param CollisionNum ����������ײ������
  * @param CarNum �ýű�Ҫ��ʾ���ų���������ֵ�����ű�����ʾһ�ų������˳̶ȵ�UI���������ֵ����Ϊ0�����ű�����ʾ���ų������˳̶ȵ�UI���������ֵ����Ϊ1�����Դ����ơ�
  * @author ���꺽
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour
{
    [SerializeField] public int CarNum;
    public GameObject damageDisplay;
    static public float[] ExtentOfDamage = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    static public int[] CollisionNum = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    void Update()
    {
        damageDisplay.GetComponent<TextMeshProUGUI>().text = "" + ExtentOfDamage[CarNum].ToString("#0.00");
    }
}
