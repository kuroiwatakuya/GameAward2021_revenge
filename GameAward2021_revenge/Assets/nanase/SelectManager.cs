using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    private int SelectingStage = 0;//選択中ステージ
    private GameObject gameManager;
    private SaveManager SaveManager;

    //ステージ番号
    private enum StageNum
    {
        title,
        stage_1,
        stage_2,
        stage_3,
        stage_4,
        MAX
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        SaveManager = gameManager.GetComponent<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //選択中のステージの変更
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("joystick button 4"))
        {
            if (SelectingStage == (int)StageNum.title)
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
            if (SelectingStage == (int)StageNum.MAX - 1)
            {
                SelectingStage = (int)StageNum.title;
            }
            else
            {
                SelectingStage++;
            }
        }

        //ステージ決定
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            ChangeGameScene();
        }
    }

    public int GetSelectingStage()
    {
        return SelectingStage;
    }

    void ChangeGameScene()
    {
        switch (SelectingStage)
        {
            case (int)StageNum.title:
                SceneManager.LoadScene("Title");
                break;
            case (int)StageNum.stage_1:
                SceneManager.LoadScene("stage1");
                break;
            case (int)StageNum.stage_2:
                if (SaveManager.Load("Stage1") > 0)
                    SceneManager.LoadScene("stage2");
                break;
            case (int)StageNum.stage_3:
                if (SaveManager.Load("stage2") > 0)
                    SceneManager.LoadScene("stage3");
                break;
            case (int)StageNum.stage_4:
                if (SaveManager.Load("stage3") > 0)
                    SceneManager.LoadScene("stage4");
                break;
            default:
                Debug.Log("エラー");
                break;
        }
    }
}
