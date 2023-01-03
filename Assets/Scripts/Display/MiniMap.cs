/**
  * @file MiniMap.cs
  * @brief ����С��ͼ�ĳ�����ʶλ�úͷ���
  * @details  
  * ���ظýű��Ķ���RaceArea �� Canvas �� UIRight �� MiniMap �� MarkPlayerCar \n
  * @param CarNum �ýű����Ƶ��Ǽ��ų���С��ͼ��־
  * @param CarPosition ��¼����������λ��
  * @param MarkX ��CarNum�ų�����С��ͼ��־��X���꣬����λ�ù�ϵ�ȱ������ŵõ�
  * @param MarkY ��CarNum�ų�����С��ͼ��־��Y���꣬����λ�ù�ϵ�ȱ������ŵõ�
  * @author ���꺽
  * @date 2023-01-01
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject TheCar;
    public static Vector3[] CarPosition = new Vector3[4];
    private float MarkX;
    private float MarkY;
    [SerializeField] public int CarNum;
    void Update()
    {
        CarPosition[CarNum] = TheCar.GetComponent<Transform>().position;
        MarkX = -50+(CarPosition[CarNum].z - 1)*100/563;
        MarkY = 50-(CarPosition[CarNum].x - 411)*100/528;
        transform.GetComponent<RectTransform>().localPosition = new Vector3(MarkX, MarkY, 0);
        transform.GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,-90-TheCar.transform.eulerAngles.y);
    }
}
