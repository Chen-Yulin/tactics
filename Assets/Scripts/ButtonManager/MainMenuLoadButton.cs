/**
  * @file MainMenuLoadButton.cs
  * @brief ���˵������д浵���ڵĴ򿪺͹ر�
  * @details 
  * ���ظýű��Ķ���MainMenu �� Canvas �� ButtonManager \n 
  * ���˵������а���Load Game��ť�󣬺����浵���ڣ��ڴ浵���ڰ���Back��ť�󣬹رմ浵���ڡ�
  * @author ���꺽
  * @date 2023-12-31
  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoadButton : MonoBehaviour
{
    public GameObject loadPanel;
    public GameObject mainMenu;
    /**
     * @fn MainloadGame
     * @brief �򿪴浵���ڣ��ر����˵�ѡ��
     */
    public void MainloadGame()
    {
        loadPanel.SetActive(true);
        mainMenu.SetActive(false);
    }
    /**
     * @fn Back
     * @brief �رմ浵���ڣ������˵�ѡ��
     */
    public void Back()
    {
        loadPanel.SetActive(false);
        mainMenu.SetActive(true);
    }
}
