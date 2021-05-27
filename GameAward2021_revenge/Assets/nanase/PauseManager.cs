using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    private int SelectingScene = 0;//選択中シーン

    //シーン番号
    private enum SceneNum
    {
        ReStart,
        Select,
        Title,
        MAX
    }

    [SerializeField] private GameObject pauseUI;//　ポーズした時に表示するUI

    private float nowTrigger;//現在のフレームの値を格納
    private float beforeTrigger;//1フレーム前の値を格納


    void Start()
    {
        SelectingScene = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 7"))
        {
            //　ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            //　ポーズUIが表示されてる時は停止
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else //　ポーズUIが表示されてなければ通常通り進行
            {
                Time.timeScale = 1f;
            }
        }

        if (pauseUI.activeSelf)
        {
            nowTrigger = Input.GetAxis("Horizontal");
            //選択中のシーンの変更
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

            //ステージ決定
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

    //ポーズ確認関数
    public bool GetOnPause()
    {
        return pauseUI.activeSelf;//trueでポーズ中
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
                // 現在のScene名を取得する
                Scene loadScene = SceneManager.GetActiveScene();
                // Sceneの読み直し
                SceneManager.LoadScene(loadScene.name);
                break;
            default:
                Debug.Log("エラー");
                break;
        }
    }
}
