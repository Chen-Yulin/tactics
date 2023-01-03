/**
  * @file CppControl.cs
  * @brief ʵ��Cpp�����Unity�Ľӿ�
  * @details  
  * ���ظýű��Ķ����� \n
  * API����ϸ�����ο�CppControl.cs��CppCarControl.h�еĶ��塣
  * @author ���꺽
  * @date 2023-01-01
  */


using AOT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CppControl : MonoBehaviour
{
    public GameObject[] TheCar;
    private static CarController[] TheCarController = new CarController[8];

    void Start()
    {
        for (int i = 0; i < GameSetting.NumofPlayer; i++)
        {
            TheCarController[i] = TheCar[i].GetComponent<CarController>();
        }
    }

    //CarControlCpp��InitializeCppControl������Cpp�ļ��б�д
    /**
     * @fn CarControlCpp
     * @brief �ú�����Cpp�ļ��б�д��ÿ������֡����һ��
     */
    [DllImport("CppControl")]
    public static extern void CarControlCpp();
    /**
     * @fn InitializeCppControl
     * @brief �ú�����Cpp�ļ��б�д�����濪ʼʱ���ã����һЩ��Ҫ�ĳ�ʼ��
     */
    [DllImport("CppControl")]
    public static extern void InitializeCppControl();

    //����callback����
    public delegate float FloatDelegate(int CarNum);
    public delegate double doubleDelegate(int CarNum);
    public delegate int intDelegate();

    /**
     * @fn InitSpeedDelegate
     * @brief �ú�����Cpp�ļ��б�д�����濪ʼʱ��StartManager.cs�е��ã���ʼ����ȡ�����ٶȵ�api
     */
    [DllImport("CppControl")]
    public static extern void InitSpeedDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitPositionXDelegate
     * @brief �ú�����Cpp�ļ��б�д����ʱ����
     */
    [DllImport("CppControl")]
    public static extern void InitPositionXDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitPositionYDelegate
     * @brief �ú�����Cpp�ļ��б�д����ʱ����
     */
    [DllImport("CppControl")]
    public static extern void InitPositionYDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitPositionZDelegate
     * @brief �ú�����Cpp�ļ��б�д����ʱ����
     */
    [DllImport("CppControl")]
    public static extern void InitPositionZDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitCruiseErrorDelegat
     * @brief �ú�����Cpp�ļ��б�д�����濪ʼʱ��StartManager.cs�е��ã���ʼ����ȡ�������·���߾����api
     */
    [DllImport("CppControl")]
    public static extern void InitCruiseErrorDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitCurvatureDelegate
     * @brief �ú�����Cpp�ļ��б�д�����濪ʼʱ��StartManager.cs�е��ã���ʼ����ȡǰ����·���ʵ�api
     */
    [DllImport("CppControl")]
    public static extern void InitCurvatureDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitAngleErrorDelegate
     * @brief �ú�����Cpp�ļ��б�д�����濪ʼʱ��StartManager.cs�е��ã���ʼ����ȡ�����͵�·���߽Ƕ�ƫ���api
     */
    [DllImport("CppControl")]
    public static extern void InitAngleErrorDelegate(FloatDelegate callbackFloat);
    /**
     * @fn InitPlayerNumDelegate
     * @brief �ú�����Cpp�ļ��б�д�����濪ʼʱ��StartManager.cs�е��ã���ʼ����ȡ������Ŀ��api
     */
    [DllImport("CppControl")]
    public static extern void InitPlayerNumDelegate(intDelegate callbackint);


    //����callback����
    public delegate void CarMoveDelegate(float steering, float accel, float footbrake, float handbrake, int CarNum);
    /**
     * @fn InitCarMoveDelegate
     * @brief �ú�����Cpp�ļ��б�д�����濪ʼʱ��StartManager.cs�е��ã���ʼ�����䳵�����Ʋ�����api
     */
    [DllImport("CppControl")]
    public static extern void InitCarMoveDelegate(CarMoveDelegate GetCarMove);

    //C# Function for C++'s call
    /**
     * @fn CallbackPlayerNumFromCpp
     * @brief ��cpp�����У�ʹ��TacticAPI::PlayerNum()�ɵ��øú���
     * @return int ������Ŀ
     */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static int CallbackPlayerNumFromCpp()
    {
        return GameSetting.NumofPlayer;
    }
    /**
    * @fn CallbackSpeedFromCpp
    * @brief ��cpp�����У�ʹ��TacticAPI::Speed(int CarNum)�ɵ��øú���
    * @param[in] CarNum �������
    * @return float ��CarNum�ų������ٶ�
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackSpeedFromCpp(int CarNum)
    {
        return SpeedDisplay.speed[CarNum];
    }
    /**
    * @fn CallbackCruiseErrorFromCpp
    * @brief ��cpp�����У�ʹ��TacticAPI::CruiseError(int CarNum)�ɵ��øú���
    * @param[in] CarNum �������
    * @return float ��CarNum�ų������·���߾���
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackCruiseErrorFromCpp(int CarNum)
    {
        return CruiseData.DistanceError[CarNum];
    }
    /**
    * @fn CallbackCurvatureFromCpp
    * @brief ��cpp�����У�ʹ��TacticAPI::Curvature(int CarNum)�ɵ��øú���
    * @param[in] CarNum �������
    * @return float ��CarNum�ų���ǰ����·������
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackCurvatureFromCpp(int CarNum)
    {
        return CruiseData.Curvature[CarNum];
    }
    /**
    * @fn CallbackAngleErrorFromCpp
    * @brief ��cpp�����У�ʹ��TacticAPI::AngleError(int CarNum)�ɵ��øú���
    * @param[in] CarNum �������
    * @return float ��CarNum�ų������·���ߵĽǶ�ƫ��
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static float CallbackAngleErrorFromCpp(int CarNum)
    {
        return CruiseData.AngleError[CarNum];
    }
    /**
    * @fn GetCarMoveFromCpp
    * @brief ��cpp�����У�ʹ��TacticAPI::CarMove(float steering, float accel, float footbrake, float handbrake, int CarNum)�ɵ��øú���
    * @details ����Ҫ������������ĸ���������CallCppControl.cs����CallCppControl.cs���ٵ���CarController��Move�������Ƴ����ƶ�
    * @param[in] CarNum �������
    * @param[in] steering �����CarNum�ų����ķ�����ת��
    * @param[in] accel �����CarNum�ų���������ֵ
    * @param[in] footbrake �����CarNum�ų����Ľ�ɲֵ
    * @param[in] handbrake �����CarNum�ų�������ɲֵ
    * @return None
    */
    [MonoPInvokeCallback(typeof(FloatDelegate))]
    public static void GetCarMoveFromCpp(float steering, float accel, float footbrake, float handbrake, int CarNum)
    {
        //��¼���ݽ������ĸ�����
        CallCppControl.steering[CarNum] = steering;
        CallCppControl.accel[CarNum] = accel;
        CallCppControl.footbrake[CarNum] = footbrake;
        CallCppControl.handbrake[CarNum] = handbrake;
        //����Move�������Ƴ����ƶ�
        /*
        if ((GameSetting.ControlMethod[CarNum] == 2) && (CarNum < GameSetting.NumofPlayer))
        {
            TheCarController[CarNum].Move(steering, accel, footbrake, handbrake);
            RecordControllerOutput.steer[CarNum].Add(steering);
            RecordControllerOutput.accel[CarNum].Add(accel);
            RecordControllerOutput.footbrake[CarNum].Add(footbrake);
            RecordControllerOutput.handbrake[CarNum].Add(handbrake);
        }*/
    }
}
