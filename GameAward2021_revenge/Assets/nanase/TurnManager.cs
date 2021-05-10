using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]private int MaxTurn;//ターン上限
    [SerializeField] private int MaxInvertCount;//表裏変換ターン数上限
    [SerializeField] private int TurnCount;//現在のターン数
    private int InvertCount;//表裏変換のターン数
    private int Environment;//表裏判定　1が表　-1が裏

    // Start is called before the first frame update
    void Start()
    {
        TurnCount = MaxTurn;
        InvertCount = MaxInvertCount;
        Environment = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //表裏反転関数
    public void ChangeEnvironment()
    {
        Environment *= -1;

    }

    public void ResetInvertCount()
    {
        InvertCount = MaxInvertCount;
    }


    //============================================================
    //Set～(int a)関数
    //　　　変数にaを代入
    //
    //Add～(int a)関数
    //　　　変数にaを加算
    //
    //Reduce～(int a)関数
    //　　　変数にaを減算
    //
    //Get～()関数
    //　　　変数を取得
    //
    //============================================================

    //ターン上限
    public void SetMaxTurn(int a)
    {
        MaxTurn = a;
    }
    public void AddMaxTurn(int a)
    {
        MaxTurn += a;
    }
    public int GetMaxTurn()
    {
        return MaxTurn;
    }

    //現在のターン数
    public void SetTurnCount(int a)
    {
        TurnCount = a;
    }
    public void AddTurnCount(int a)
    {
        TurnCount += a;
    }

    public void ReduceTrunCount(int a)
    {
        TurnCount -= a;
    }
    public int GetTurnCount()
    {
        return TurnCount;
    }

    //表裏変換ターン数
    public void SetInvertCount(int a)
    {
        InvertCount = a;
    }
    public void AddInvertCount(int a)
    {
        InvertCount += a;
    }
    public void ReduceInvertTrunCount(int a)
    {
        InvertCount -= a;
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
