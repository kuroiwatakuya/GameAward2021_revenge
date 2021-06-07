using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    private int SelectingStage;//選択中ステージ
    private GameObject gameManager;
    private SaveManager SaveManager;
    private FadeManager fadeManager;

    //現在のフレームの値を格納  1フレーム前の値を格納
    private float nowHorizontal;//横軸
    private float beforeHorizontal;
    private float nowVertical;//縦軸
    private float beforeVertical;

    [SerializeField] private GameObject SeSt1;
    private Image image_s1;
    [SerializeField] private GameObject SeSt2;
    private Image image_s2;
    [SerializeField] private GameObject SeSt3;
    private Image image_s3;
    [SerializeField] private GameObject SeSt4;
    private Image image_s4;
    [SerializeField] private GameObject SeSt5;
    private Image image_s5;
    [SerializeField] private GameObject SeSt6;
    private Image image_s6;
    [SerializeField] private GameObject SeSt7;
    private Image image_s7;
    [SerializeField] private GameObject SeSt8;
    private Image image_s8;
    [SerializeField] private GameObject SeSt9;
    private Image image_s9;

    [SerializeField] private GameObject SelectBackUI;
    private Image image_back;

    //SE
    public AudioClip clip;
    private AudioSource audioSource;

    private bool isOn;

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
        SaveManager = gameManager.GetComponent<SaveManager>();
        fadeManager = gameManager.GetComponent<FadeManager>();

        fadeManager.OnFadeOut();

        image_s1 = SeSt1.GetComponent<Image>();
        image_s2 = SeSt2.GetComponent<Image>();
        image_s3 = SeSt3.GetComponent<Image>();
        image_s4 = SeSt4.GetComponent<Image>();
        image_s5 = SeSt5.GetComponent<Image>();
        image_s6 = SeSt6.GetComponent<Image>();
        image_s7 = SeSt7.GetComponent<Image>();
        image_s8 = SeSt8.GetComponent<Image>();
        image_s9 = SeSt9.GetComponent<Image>();

        image_back = SelectBackUI.GetComponent<Image>();

        SelectingStage = 1;

        audioSource = GetComponent<AudioSource>();

        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        image_s1.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_s2.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_s3.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_s4.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_s5.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_s6.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_s7.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_s8.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_s9.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_back.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);

        nowHorizontal = Input.GetAxis("Horizontal");
        nowVertical = Input.GetAxis("Vertical");

        if (fadeManager.GetIsFade() == -1 && fadeManager.GetAlfa() < 0.0f)
        {
            //選択中のステージの変更
            if (Input.GetKeyDown(KeyCode.LeftArrow) || (nowHorizontal < 0 && beforeHorizontal == 0.0f))
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
            if (Input.GetKeyDown(KeyCode.RightArrow) || (nowHorizontal > 0 && beforeHorizontal == 0.0f))
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

            if (Input.GetKeyDown(KeyCode.UpArrow) || (nowVertical > 0 && beforeVertical == 0.0f))
            {
                if (SelectingStage == (int)StageNum.title)
                {
                    SelectingStage = (int)StageNum.MAX - 1;
                }
                else if (SelectingStage <= (int)StageNum.stage_3)
                {
                    SelectingStage = (int)StageNum.title;
                }
                else
                {
                    SelectingStage -= 3;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || (nowVertical < 0 && beforeVertical == 0.0f))
            {
                if (SelectingStage <= (int)StageNum.title)
                {
                    SelectingStage = (int)StageNum.stage_1;
                }
                else if (SelectingStage >= (int)StageNum.stage_7)
                {
                    SelectingStage = (int)StageNum.title;
                }
                else
                {
                    SelectingStage += 3;
                }
            }

            SelectScene();

            //ステージ決定
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
            {
                audioSource.PlayOneShot(clip);
                OnFade();
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
            case (int)StageNum.stage_5:
                if (SaveManager.Load("stage4") > 0)
                    SceneManager.LoadScene("stage5");
                break;
            case (int)StageNum.stage_6:
                if (SaveManager.Load("stage5") > 0)
                    SceneManager.LoadScene("stage6");
                break;
            case (int)StageNum.stage_7:
                if (SaveManager.Load("stage6") > 0)
                    SceneManager.LoadScene("stage7");
                break;
            case (int)StageNum.stage_8:
                if (SaveManager.Load("stage7") > 0)
                    SceneManager.LoadScene("stage8");
                break;
            case (int)StageNum.stage_9:
                if (SaveManager.Load("stage8") > 0)
                    SceneManager.LoadScene("stage9");
                break;
            default:
                Debug.Log("エラー");
                break;
        }
    }

    private void SelectScene()
    {
        switch (SelectingStage)
        {
            case (int)StageNum.title:
                image_back.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            case (int)StageNum.stage_1:
                image_s1.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            case (int)StageNum.stage_2:
                image_s2.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                if (SaveManager.Load("Stage1") > 0)
                    image_s2.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            case (int)StageNum.stage_3:
                image_s3.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                if (SaveManager.Load("stage2") > 0)
                    image_s3.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            case (int)StageNum.stage_4:
                image_s4.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                if (SaveManager.Load("stage3") > 0)
                    image_s4.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            case (int)StageNum.stage_5:
                image_s5.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                if (SaveManager.Load("stage4") > 0)
                    image_s5.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            case (int)StageNum.stage_6:
                image_s6.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                if (SaveManager.Load("stage5") > 0)
                    image_s6.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            case (int)StageNum.stage_7:
                image_s7.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                if (SaveManager.Load("stage6") > 0)
                    image_s7.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            case (int)StageNum.stage_8:
                image_s8.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                if (SaveManager.Load("stage7") > 0)
                    image_s8.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
            case (int)StageNum.stage_9:
                image_s9.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                if (SaveManager.Load("stage8") > 0)
                    image_s9.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
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
                if (SaveManager.Load("Stage1") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_3:
                if (SaveManager.Load("stage2") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_4:
                if (SaveManager.Load("stage3") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_5:
                if (SaveManager.Load("stage4") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_6:
                if (SaveManager.Load("stage5") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_7:
                if (SaveManager.Load("stage6") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_8:
                if (SaveManager.Load("stage7") > 0)
                    fadeManager.OnFadeIn();
                break;
            case (int)StageNum.stage_9:
                if (SaveManager.Load("stage8") > 0)
                    fadeManager.OnFadeIn();
                break;
            default:
                Debug.Log("エラー");
                break;
        }
    }
}
