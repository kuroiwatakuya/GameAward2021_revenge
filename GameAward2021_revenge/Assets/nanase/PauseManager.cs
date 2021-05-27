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
        ReStart,
        Select,
        Title,
        MAX
    }

    [SerializeField] private GameObject pauseUI;//�@�|�[�Y�������ɕ\������UI

    private float nowTrigger;//���݂̃t���[���̒l���i�[
    private float beforeTrigger;//1�t���[���O�̒l���i�[


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
            nowTrigger = Input.GetAxis("Horizontal");
            //�I�𒆂̃V�[���̕ύX
            if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetAxis("Horizontal") < 0 && beforeTrigger == 0.0f))
            {
                if (SelectingScene == (int)SceneNum.ReStart)
                {
                    SelectingScene = (int)SceneNum.MAX - 1;
                }
                else
                {
                    SelectingScene--;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetAxis("Horizontal") > 0 && beforeTrigger == 0.0f))
            {
                if (SelectingScene == (int)SceneNum.MAX - 1)
                {
                    SelectingScene = (int)SceneNum.ReStart;
                }
                else
                {
                    SelectingScene++;
                }
            }

            //�X�e�[�W����
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
            {
                Time.timeScale = 1f;
                ChangeScene();
            }

            beforeTrigger = nowTrigger;
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
