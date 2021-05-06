using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private int MaxTurn = 30;//�^�[�����
    private int MaxInvertCount = 3;//�\���ϊ��^�[�������
    private int TurnCount;//���݂̃^�[����
    private int InvertCount;//�\���ϊ��̃^�[����
    private int Environment;//�\������@1���\�@-1����

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
        if (InvertCount == MaxInvertCount)
        {
            InvertCount = 0;
            ChangeEnvironment();
        }
    }

    //�\�����]�֐�
    public void ChangeEnvironment()
    {
        Environment *= -1;
    }

    //============================================================
    //Set�`(int a)�֐�
    //�@�@�@�ϐ���a����
    //
    //Add�`(int a)�֐�
    //�@�@�@�ϐ���a�����Z
    //
    //Get�`()�֐�
    //�@�@�@�ϐ����擾
    //
    //============================================================

    //�^�[�����
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

    //���݂̃^�[����
    public void SetTurnCount(int a)
    {
        TurnCount = a;
    }
    public void AddTurnCount(int a)
    {
        TurnCount += a;
    }
    public int GetTurnCount()
    {
        return TurnCount;
    }

    //�\���ϊ��^�[����
    public void SetInvertCount(int a)
    {
        InvertCount = a;
    }
    public void AddInvertCount(int a)
    {
        InvertCount += a;
    }
    public int GetInvertCount()
    {
        return InvertCount;
    }

    //�\������@1���\�@-1����
    public int GetEnvironment()
    {
        return Environment;
    }

    //�ǋL ���\�ϊ��^�[���ő�l�̎擾
    public int GetMaxInvertCount()
    {
        return MaxInvertCount;
    }
}
