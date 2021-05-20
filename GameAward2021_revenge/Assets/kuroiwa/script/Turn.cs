using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//================================
//黒岩:ターンスクリプト
//歩数に応じて数字を変える
//================================
public class Turn : MonoBehaviour
{

    [SerializeField] private GameObject[] TurnCountUI10;
    [SerializeField] private GameObject[] TurnCountUI1;

    [SerializeField] private GameObject[] InvertTurnCountUI;

    private int PlayCount;

    private GameObject TurnManager;      //ターンマネージャー格納
    private TurnManager TurnMng;         //ターンマネージャーのスクリプト受け取り

    private int TurnNum;                   //最大ターン数値
    private int InvertTurnNum;             //上部ターン数

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 9; i++)
        {
            TurnCountUI10[i].SetActive(false);
        }
        for (int i = 0; i <= 9; i++)
        {
            TurnCountUI1[i].SetActive(false);
        }
        for (int i = 0; i <= 9; i++)
        {
            InvertTurnCountUI[i].SetActive(false);
        }

        TurnManager = GameObject.FindWithTag("GameManager");
        TurnMng = TurnManager.gameObject.GetComponent<TurnManager>();           //ターンマネージャースクリプトの格納

        //数値格納
        TurnNum = TurnMng.GetTurnCount();                       //最大ターン数数値格納
        InvertTurnNum = TurnMng.GetInvertCount();               //初期裏表変換残りターン数格納
    }

    // Update is called once per frame
    void Update()
    {
        TurnNum = TurnMng.GetTurnCount();                       //最大ターン数数値格納
        InvertTurnNum = TurnMng.GetInvertCount();               //初期裏表変換残りターン数格納

        //表示
        TurnCountUI10[Mathf.FloorToInt(TurnNum / 10)].SetActive(true);
        TurnCountUI1[TurnNum % 10].SetActive(true);
        InvertTurnCountUI[InvertTurnNum].SetActive(true);

        //0じゃないときは＋１の数をFalseにする(0のときは9)
        if (Mathf.FloorToInt(TurnNum / 10) == 9)
        {
            TurnCountUI10[0].SetActive(false);
        }
        else
        {
            TurnCountUI10[Mathf.FloorToInt(TurnNum / 10) + 1].SetActive(false);
        }

        if (TurnNum % 10 == 9)
        {
            TurnCountUI1[0].SetActive(false);
        }
        else
        {
            TurnCountUI1[TurnNum % 10 + 1].SetActive(false);
        }

        if (InvertTurnNum == TurnMng.GetMaxInvertCount())
        {
            InvertTurnCountUI[0].SetActive(false);
            InvertTurnCountUI[1].SetActive(false);
        }
        else
        {
            InvertTurnCountUI[InvertTurnNum + 1].SetActive(false);
        }

       

    }
}
       