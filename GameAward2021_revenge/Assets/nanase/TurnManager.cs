using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private int MaxTurn = 30;//�^�[�����
    private int MaxInvertCount = 3;//�\���ϊ��^�[�������
    private int TurnCount;//���݂̃^�[����
    public int InvertCount;//�\���ϊ��^�[����
    public int Environment;//�\������@1���\�@-1����

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
    //�@�@�@�ϐ����Q�b�g
    //
    //============================================================

    //�^�[�����
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

    //���݂̃^�[����
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

    //�\���ϊ��^�[����
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
