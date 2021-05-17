using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    private int SelectingScene = 0;//�I�𒆃V�[��

    //�V�[���ԍ�
    private enum SceneNum
    {
        Title,
        ReStart,
        Select,
        MAX
    }

    [SerializeField] private GameObject pauseUI;//�@�|�[�Y�������ɕ\������UI


    void Start()
    {
        SelectingScene = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 7"))
        {
            //�@�|�[�YUI�̃A�N�e�B�u�A��A�N�e�B�u��؂�ւ�
            pauseUI.SetActive(!pauseUI.activeSelf);

            //�@�|�[�YUI���\������Ă鎞�͒�~
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else //�@�|�[�YUI���\������ĂȂ���Βʏ�ʂ�i�s
            {
                Time.timeScale = 1f;
            }
        }

        if (pauseUI.activeSelf)
        {
            //�I�𒆂̃V�[���̕ύX
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("joystick button 4"))
            {
                Debug.Log("��");
                if (SelectingScene == (int)SceneNum.Title)
                {
                    SelectingScene = (int)SceneNum.MAX - 1;
                }
                else
                {
                    SelectingScene--;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("joystick button 5"))
            {
                Debug.Log("�E");
                if (SelectingScene == (int)SceneNum.MAX - 1)
                {
                    SelectingScene = (int)SceneNum.Title;
                }
                else
                {
                    SelectingScene++;
                }
            }

            //�X�e�[�W����
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
            {
                Debug.Log("����");
                Time.timeScale = 1f;
                ChangeScene();
            }
        }
    }

    public int GetSelectingScene()
    {
        return SelectingScene;
    }

    //�|�[�Y�m�F�֐�
    public bool GetOnPause()
    {
        return pauseUI.activeSelf;//true�Ń|�[�Y��
    }

    void ChangeScene()
    {
        switch (SelectingScene)
        {
            case (int)SceneNum.Title:
                SceneManager.LoadScene("Title");
                break;
            case (int)SceneNum.Select:
                SceneManager.LoadScene("Select");
                break;
            case (int)SceneNum.ReStart:
                // ���݂�Scene�����擾����
                Scene loadScene = SceneManager.GetActiveScene();
                // Scene�̓ǂݒ���
                SceneManager.LoadScene(loadScene.name);
                break;
            default:
                Debug.Log("�G���[");
                break;
        }
    }
}
