using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneManager : MonoBehaviour
{
    private GameObject gameManager;
    private SaveManager saveManager;
    private TurnManager TurnMng;         //ターンマネージャーのスクリプト受け取り
    private FadeManager fadeManager;

    private int TurnNum;                   //現在ターン数値

    private bool isClear;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        saveManager = gameManager.GetComponent<SaveManager>();
        TurnMng = gameManager.GetComponent<TurnManager>();
        fadeManager = gameManager.GetComponent<FadeManager>();

        fadeManager.OnFadeOut();

        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClear)
        {
            TurnNum = TurnMng.GetTurnCount();                       //最大ターン数数値格納
        }

        if (TurnNum <= 0)
        {
            fadeManager.OnFadeIn();
        }

        if (fadeManager.GetIsFade() == 1 && fadeManager.GetAlfa() > 1.0f)
        {
            if (TurnNum <= 0)
            {
                saveManager.SaveSceneName();
                SceneManager.LoadScene("GameOver");
            }

            if(isClear == true)
            {
                saveManager.SaveSceneName();
                saveManager.Save();
                SceneManager.LoadScene("ClearScene");
            }

        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isClear = true;
            fadeManager.OnFadeIn();
        }
    }
}
