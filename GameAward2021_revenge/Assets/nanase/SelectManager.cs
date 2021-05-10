using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    private int SelectingStage = 0;//選択中ステージ

    //ステージ番号
    private enum StageNum
    {
        stage_1,
        stage_2,
        stage_3,
        stage_4,
        stage_5,
        MAX
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //選択中のステージの変更
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("左");
            if (SelectingStage == (int)StageNum.stage_1)
            {
                SelectingStage = (int)StageNum.MAX - 1;
            }
            else
            {
                SelectingStage--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("右");
            if (SelectingStage == (int)StageNum.MAX - 1)
            {
                SelectingStage = (int)StageNum.stage_1;
            }
            else
            {
                SelectingStage++;
            }
        }

        //ステージ決定
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("決定");
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
            case (int)StageNum.stage_5:
                SceneManager.LoadScene("stage5");
                break;

            default:
                Debug.Log("エラー");
                break;
        }
    }
}
