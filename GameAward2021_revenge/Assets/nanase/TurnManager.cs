using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private int MaxTurn = 30;//ターン上限
    private int MaxInvertCount = 3;//表裏変換ターン数上限
    private int TurnCount;//現在のターン数
    public int InvertCount;//表裏変換ターン数
    public int Environment;//表裏判定　1が表　-1が裏

    // Start is called before the first frame update
    void Start()
    {
        TurnCount = 0;
        InvertCount = 0;
        Environment = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (InvertCount > MaxInvertCount)
        {
            InvertCount = 0;
            ChangeEnvironment();
        }
    }

    //表裏反転関数
    public void ChangeEnvironment()
    {
        Environment *= -1;
    }

    //============================================================
    //Set～(int a)関数
    //　　　変数にaを代入
    //
    //Add～(int a)関数
    //　　　変数にaを加算
    //
    //Get～()関数
    //　　　変数をゲット
    //
    //============================================================

    //ターン上限
    public int SetMaxTurn(int a)
    {
        MaxTurn = a;
        return MaxTurn;
    }
    public int AddMaxTurn(int a)
    {
        MaxTurn += a;
        return MaxTurn;
    }
    public int GetMaxTurn()
    {
        return MaxTurn;
    }

    //現在のターン数
    public int SetTurnCount(int a)
    {
        TurnCount = a;
        return TurnCount;
    }
    public int AddTurnCount(int a)
    {
        TurnCount += a;
        return TurnCount;
    }
    public int GetTurnCount()
    {
        return TurnCount;
    }

    //表裏変換ターン数
    public int SetInvertCount(int a)
    {
        InvertCount = a;
        return InvertCount;
    }
    public int AddInvertCount(int a)
    {
        InvertCount += a;
        return InvertCount;
    }
    public int GetInvertCount()
    {
        return InvertCount;
    }

    //表裏判定　1が表　-1が裏
    public int GetEnvironment()
    {
        return Environment;
    }

    //追記 裏表変換ターン最大値の取得
    public int GetMaxInvertCount()
    {
        return MaxInvertCount;
    }
}
