/**
  * @file GamePauseButton.cs
  * @brief ������ͣ�����а��²�ͬ��ť��ִ�еĺ�����
  * @details 
  * ���ظýű��Ķ���RaceArea �� Canvas �� Panel Pause �� PauseButtonManager \n
  * - Continue��ť��ContinueRace()���������档
  * - Save and Load��ť��SaveGame()���򿪴浵�������ڡ�
  * - Retry��ť��Retry()�����¿�ʼ��
  * - MainMenu��ť��BacktoMainMenu()���ص����˵����档
  * .
  * @author ���꺽
  * @date 2023-12-31
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseButton : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject SavePanel;
    private int CamMode;
    private int trackNum;

    /**
     * @fn BacktoMainMenu
     * @brief �������˵�
     * @details �ͷű��η�������м�¼��������ָ�����ķѵ��ڴ棬�ο�RecordControllerOutput.cs
     * @return None
     */
    public void BacktoMainMenu()
    {
        Time.timeScale = 1;
        //�ͷ��ڴ�
        for (int i = 0; i < 4; i++)
        {
            RecordControllerOutput.steer[i] = null;
            RecordControllerOutput.accel[i] = null;
            RecordControllerOutput.footbrake[i] = null;
            RecordControllerOutput.handbrake[i] = null;
        }
        SceneManager.LoadScene(0);
    }
    /**
     * @fn ContinueRace
     * @brief ��������
     * @return None
     */
    public void ContinueRace()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    /**
     * @fn SaveGame
     * @brief �򿪴浵���ڣ�ͬʱ�ر���ͣ����
     * @details ��Ҫ��¼�û�������ͣ��������Ĵ浵���� \n
     * ���û��˳��浵���棬��Ӧ���ٴδ���ͣ����
     * @return None
     */
    public void SaveGame()
    {
        SavePanel.SetActive(true);
        pausePanel.SetActive(false);
        SaveButton.WhoCalloutSavePanel = 2;
    }
    /**
     * @fn Retry
     * @brief ���·���
     * @details �ͷű��η�������м�¼��������ָ�����ķѵ��ڴ棬�ο�RecordControllerOutput.cs \n
     * ����������泡��
     * @return None
     */
    public void Retry()
    {
        Time.timeScale = 1;
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        //�ͷ��ڴ�
        for (int i = 0; i < 4; i++)
        {
            RecordControllerOutput.steer[i] = null;
            RecordControllerOutput.accel[i] = null;
            RecordControllerOutput.footbrake[i] = null;
            RecordControllerOutput.handbrake[i] = null;
        }
        if (trackNum == 1)
            SceneManager.LoadScene(2);
        else if (trackNum == 2)
            SceneManager.LoadScene(3);
        else if (trackNum == 3)
            SceneManager.LoadScene(5);
        else
            SceneManager.LoadScene(5);
    }
}
