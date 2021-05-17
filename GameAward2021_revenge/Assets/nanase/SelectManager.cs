using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    private int SelectingStage = 0;//�I�𒆃X�e�[�W

    //�X�e�[�W�ԍ�
    private enum StageNum
    {
        stage_1,
        stage_2,
        stage_3,
        stage_4,
        MAX
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�I�𒆂̃X�e�[�W�̕ύX
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("��");
            if (SelectingStage == (int)StageNum.stage_1)
            {
                SelectingStage = (int)StageNum.MAX - 1;
            }
            else
            {
                SelectingStage--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("�E");
            if (SelectingStage == (int)StageNum.MAX - 1)
            {
                SelectingStage = (int)StageNum.stage_1;
            }
            else
            {
                SelectingStage++;
            }
        }

        //�X�e�[�W����
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("����");
            ChangeGameScene();
        }
    }

    public int GetSelectingStage()
    {
        return SelectingStage + 1;
    }

    void ChangeGameScene()
    {
        switch (SelectingStage)
        {
            case (int)StageNum.stage_1:
                SceneManager.LoadScene("stage1");
                break;
            case (int)StageNum.stage_2:
                SceneManager.LoadScene("stage2");
                break;
            case (int)StageNum.stage_3:
                SceneManager.LoadScene("stage3");
                break;
            case (int)StageNum.stage_4:
                SceneManager.LoadScene("stage4");
                break;
            default:
                Debug.Log("�G���[");
                break;
        }
    }
}
