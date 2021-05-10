using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureSceneManager : MonoBehaviour
{
    private GameObject TurnManager;      //ターンマネージャー格納
    private TurnManager TurnMng;         //ターンマネージャーのスクリプト受け取り

    private int TurnNum;                   //現在ターン数値

    // Start is called before the first frame update
    void Start()
    {
        TurnManager = GameObject.FindWithTag("GameManager");
        TurnMng = TurnManager.gameObject.GetComponent<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TurnNum = TurnMng.GetTurnCount();                       //最大ターン数数値格納

        if(TurnNum<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
