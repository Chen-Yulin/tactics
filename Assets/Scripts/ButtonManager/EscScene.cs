/**
  * @file EscScene.cs
  * @brief ��TrackSelect������Credit����ͨ��Esc�����ٻص����˵�
  * @details 
  * ���ظýű��Ķ���TrackSelect �� Esc�� Credit �� Esc \n
  * @author ���꺽
  * @date 2023-12-31
  */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EscScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
