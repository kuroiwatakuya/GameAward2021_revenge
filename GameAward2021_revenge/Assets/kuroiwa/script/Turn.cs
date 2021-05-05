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
    public GameObject TurnManager;      //ターンマネージャー格納
    private TurnManager TurnMng;         //ターンマネージャーのスクリプト受け取り

    public Text MaxTurn;                        //最大ターン数表示
    public Text TopTurn;                         //上部ターン数表示
    public Text UnderTurn;                     //下部ターン数表示

    public int MaxTurnNum;                 //最大ターン数値
    public int TopTurnNum;                  //上部ターン数
    public int UnderTurnNum;              //下部ターン数

    // Start is called before the first frame update
    void Start()
    {
        TurnMng = TurnManager.gameObject.GetComponent<TurnManager>();

        //数値格納
        MaxTurnNum = TurnMng.GetMaxTurn();                    //最大ターン数数値格納
        TopTurnNum = TurnMng.GetMaxInvertCount();          //初期裏表変換残りターン数格納
        UnderTurnNum = TurnMng.GetMaxInvertCount();

        //ターン数UI格納
        MaxTurn.text = MaxTurnNum.ToString();                   //最大ターン数UI格納
        TopTurn.text = TopTurnNum.ToString();                    //表裏変換ターン数UI格納
        UnderTurn.text = UnderTurnNum.ToString();             //裏表変換ターン数UI格納
    }

    // Update is called once per frame
    void Update()
    {
        //表状態
       if(TurnMng.GetEnvironment() == 1)
        {
            //表のターン数と全体のターン数を減少させる
            /*デバッグ用 マウス左クリック*/
            if(Input.GetMouseButtonDown(0))
            {
                //最大ターン数減少
                MaxTurnNum -= 1;
                TopTurnNum -= 1;

                //UIに反映
                MaxTurn.text = MaxTurnNum.ToString();           
                TopTurn.text = TopTurnNum.ToString();

                //変換カウント加算
                TurnMng.AddInvertCount(1);
            }
        }
       //裏状態
       else if(TurnMng.GetEnvironment() == -1)
        {
            //裏のターン数と全体のターン数を減少させる
            if(Input.GetMouseButtonDown(0))
            {
                MaxTurnNum -= 1;
                UnderTurnNum -= 1;

                MaxTurn.text = MaxTurnNum.ToString();
                UnderTurn.text = UnderTurnNum.ToString();

                //変換カウント加算
                TurnMng.AddInvertCount(1);
            }
        }
    }
}
