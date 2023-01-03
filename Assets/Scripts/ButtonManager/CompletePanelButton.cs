/**
  * @file GamePauseButton.cs
  * @brief �ڷ�����������а��²�ͬ��ť��ִ�еĺ�����
  * @details 
  * ���ظýű��Ķ���RaceArea �� Canvas �� Panel complete �� CompletePanelButtonManager \n
  * @author ���꺽
  * @date 2023-12-31
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletePanelButton : MonoBehaviour
{
    private int trackNum;
    public GameObject SavePanel;
    public GameObject CompletePanel;

    /**
     * @fn SaveGame
     * @brief �򿪴浵���ڣ�ͬʱ�رս��㴰��
     * @details ��Ҫ��¼�û����ڽ����������Ĵ浵���� \n
     * ���û��˳��浵���棬��Ӧ���ٴδ򿪽��㴰��
     * @return None
     */
    public void SaveGame()
    {
        SavePanel.SetActive(true);
        CompletePanel.SetActive(false);
        SaveButton.WhoCalloutSavePanel = 1;
    }

    /**
     * @fn MainMenu
     * @brief �������˵�
     * @details �ͷű��η�������м�¼��������ָ�����ķѵ��ڴ棬�ο�RecordControllerOutput.cs
     * @return None
     */
    public void MainMenu()
    {
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
     * @fn Retry
     * @brief ���·���
     * @details �ͷű��η�������м�¼��������ָ�����ķѵ��ڴ棬�ο�RecordControllerOutput.cs \n
     * ����������泡��
     * @return None
     */
    public void Retry()
    {
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
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
