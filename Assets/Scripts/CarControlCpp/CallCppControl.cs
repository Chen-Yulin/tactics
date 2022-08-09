using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CallCppControl : MonoBehaviour
{
    public GameObject[] TheCar;
    public static float[] steering = new float[4] { 0, 0, 0, 0 };
    public static float[] accel = new float[4] { 0, 0, 0, 0 };
    public static float[] footbrake = new float[4] { 0, 0, 0, 0 };
    public static float[] handbrake = new float[4] { 0, 0, 0, 0 };
    private int playNum;
    private CarController[] m_Car = new CarController[4];
    private int[] ControlMethod = new int[4] { 0, 0, 0, 0 };

    void Start()
    {
        CppControl.InitializeCppControl();
        playNum = GameSetting.NumofPlayer;
        for(int i = 0;i < playNum;i++)
        {
            m_Car[i] = TheCar[i].GetComponent<CarController>();
            ControlMethod[i] = GameSetting.ControlMethod[i];
        }
        
    }

    void Update()
    {
        CppControl.CarControlCpp();
        for (int i = 0; i < playNum; i++)
        {
            if(ControlMethod[i] == 2)
                m_Car[i].Move(steering[i], accel[i], footbrake[i], handbrake[i]);
        }
    }
}