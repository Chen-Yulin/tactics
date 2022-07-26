#pragma once
#define DLLForUnity_API _declspec(dllexport)
//#define UnityLog(acStr)  char acLogStr[512] = { 0 }; sprintf_s(acLogStr, "%s",acStr); Debug::Log(acLogStr,strlen(acStr));

//C++ Call C#

EXTERN_C class TacticAPI
{
//�ӿڶ���
public:
	static float (*Speed)(); //����С���ٶ�
	static float (*PositionX)(); //����С��X����
	static float (*PositionY)(); //����С��Y����
	static float (*PositionZ)(); //����С��Z����
	static double (*CruiseError)(); //����С���������������ߵľ���
	static void (*CarMove)(float steering, float accel, float footbrake, float handbrake); //�����ĸ�����(steering��accel��footbrake��handbrake)����С���ƶ�
	static double (*Curvature)(); //����ǰ�����������ߵ�����
	static float (*AngleError)(); //����С����������������߷����ƫ��
};


//��Ϊ�ӿڶ�����ش��룬�����Ķ�
//C# Call C++

EXTERN_C void DLLForUnity_API InitSpeedDelegate(float (*callbackFloat)());
EXTERN_C void DLLForUnity_API InitPositionXDelegate(float (*callbackFloat)());
EXTERN_C void DLLForUnity_API InitPositionYDelegate(float (*callbackFloat)());
EXTERN_C void DLLForUnity_API InitPositionZDelegate(float (*callbackFloat)());
EXTERN_C void DLLForUnity_API InitCruiseErrorDelegate(double (*callbackdouble)());
EXTERN_C void DLLForUnity_API InitCurvatureDelegate(double (*callbackdouble)());
EXTERN_C void DLLForUnity_API InitAngleErrorDelegate(float (*callbackFloat)());

EXTERN_C void DLLForUnity_API InitCarMoveDelegate(void (*GetCarMove)(float steering, float accel, float footbrake, float handbrake));

EXTERN_C DLLForUnity_API void __stdcall CarControlCpp();

/*
EXTERN_C class Debug
{
	public:
		static void (*Log)(char* message, int iSize);
};
//EXTERN_C void DLLForUnity_API InitCSharpDelegate(void (*Log)(char* message, int iSize));
*/

