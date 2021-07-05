using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewSelectManager : MonoBehaviour
{
    [SerializeField] private int SelectingStage;//選択中ステージ
    private GameObject gameManager;
    private SaveManager saveManager;
    private FadeManager fadeManager;
    private stageselect stageSelect;

    //現在のフレームの値を格納  1フレーム前の値を格納
    private float nowHorizontal;//横軸
    private float beforeHorizontal;
    private float nowVertical;//縦軸
    private float beforeVertical;

    //SE
    public AudioClip clip;
    private AudioSource audioSource;
   

    //ステージ番号
    private enum StageNum
    {
        title,
        stage_1,
        stage_2,
        stage_3,
        stage_4,
        stage_5,
        stage_6,
        stage_7,
        stage_8,
        stage_9,
        MAX
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        saveManager = gameManager.GetComponent<SaveManager>();
        fadeManager = gameManager.GetComponent<FadeManager>();
        stageSelect = gameManager.GetComponent<stageselect>();

        fadeManager.OnFadeOut();
        
        SelectingStage = 1;

        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        nowHorizontal = Input.GetAxis("Horizontal");
        nowVertical = Input.GetAxis("Vertical");

        if (fadeManager.GetIsFade() == -1 && fadeManager.GetAlfa() < 0.0f)
        {
            if (stageSelect.GetMoveFlag() == false)
            {
                //選択中のステージの変更
                if (Input.GetKeyDown(KeyCode.LeftArrow) || (nowHorizontal < 0 && beforeHorizontal == 0.0f))
                {
                    if (SelectingStage == (int)StageNum.MAX - 1)
                    {
                        SelectingStage = (int)StageNum.stage_1;
                    }
                    else
                    {
                        SelectingStage++;
                    }
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) || (nowHorizontal > 0 && beforeHorizontal == 0.0f))
                {
                    if (SelectingStage == (int)StageNum.stage_1)
                    {
                        SelectingStage = (int)StageNum.MAX - 1;
                    }
                    else
                    {
                        SelectingStage--;
                    }
                }

                //ステージ決定
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
                {
                    audioSource.PlayOneShot(clip);
                    OnFade();
                }
            }
        }

        if (fadeManager.GetIsFade() == 1 && fadeManager.GetAlfa() > 1.0f)
        {
            ChangeGameScene();
        }


        beforeHorizontal = nowHorizontal;
        beforeVertical = nowVertical;
    }

    public int GetSelectingStage()
    {
        return SelectingStage;
    }

    private void ChangeGameScene()
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
                if (saveManager.Load("Stage1") > 0)
                    SceneManager.LoadScene("stage2");
                break;
            case (int)StageNum.stage_3:
                if (saveManager.Load("stage2") > 0)
                    SceneManager.LoadScene("stage3");
                break;
            case (int)StageNum.stage_4:
                if (saveManager.Load("stage3") > 0)
                    SceneManager.LoadScene("stage4");
                break;
            case (int)StageNum.stage_5:
                if (saveManager.Load("stage4") > 0)
                    SceneManager.LoadScene("stage5");
                break;
            case (int)StageNum.stage_6:
                if (saveManager.Load("stage5") > 0)
                    SceneManager.LoadScene("stage6");
                break;
            case (int)StageNum.stage_7:
                if (saveManager.Load("stage6") > 0)
                    SceneManager.LoadScene("stage7");
                break;
            case (int)StageNum.stage_8:
                if (saveManager.Load("stage7") > 0)
                    SceneManager.LoadScene("stage8");
                break;
            case (int)StageNum.stage_9:
                if (saveManager.Load("stage8") > 0)
                    SceneManager.LoadScene("stage9");
                break;
            default:
                Debug.Log("エラー");
                break;
        }
    }

    private void OnFade()
    {
        switch (SelectingStage)
        {
            case (int)StageNum.title:
                fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_1:
                fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_2:
                if (saveManager.Load("Stage1") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_3:
                if (saveManager.Load("stage2") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_4:
                if (saveManager.Load("stage3") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_5:
                if (saveManager.Load("stage4") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_6:
                if (saveManager.Load("stage5") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_7:
                if (saveManager.Load("stage6") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_8:
                if (saveManager.Load("stage7") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_9:
                if (saveManager.Load("stage8") > 0)
                    fadeManager.OnFadeIn();
                break;
            default:
                Debug.Log("エラー");
                break;
        }
    }
}
