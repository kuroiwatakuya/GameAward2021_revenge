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
    private GameObject TurnManager;      //ターンマネージャー格納
    private TurnManager TurnMng;         //ターンマネージャーのスクリプト受け取り

    public Text TurnText;                        //最大ターン数表示
    public Text InvertTurn;                     //下部ターン数表示

    private int TurnNum;                   //最大ターン数値
    private int InvertTurnNum;             //上部ターン数

    // Start is called before the first frame update
    void Start()
    {
        TurnManager = GameObject.FindWithTag("GameManager");
        TurnMng = TurnManager.gameObject.GetComponent<TurnManager>();           //ターンマネージャースクリプトの格納

        //数値格納
        TurnNum = TurnMng.GetTurnCount();                       //最大ターン数数値格納
        InvertTurnNum = TurnMng.GetInvertCount();               //初期裏表変換残りターン数格納

        //ターン数UI格納
        TurnText.text = TurnNum.ToString();                   //最大ターン数UI格納
        InvertTurn.text = InvertTurnNum.ToString();             //裏表変換ターン数UI格納
    }

    // Update is called once per frame
    void Update()
    {
        TurnNum = TurnMng.GetTurnCount();                       //最大ターン数数値格納
        InvertTurnNum = TurnMng.GetInvertCount();               //初期裏表変換残りターン数格納

        //UIに反映
        TurnText.text = TurnNum.ToString();
        InvertTurn.text = InvertTurnNum.ToString();
    }
}
       