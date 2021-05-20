using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//================================
//����:�^�[���X�N���v�g
//�����ɉ����Đ�����ς���
//================================
public class Turn : MonoBehaviour
{

    [SerializeField] private GameObject[] TurnCountUI10;
    [SerializeField] private GameObject[] TurnCountUI1;

    [SerializeField] private GameObject[] InvertTurnCountUI;

    private int PlayCount;

    private GameObject TurnManager;      //�^�[���}�l�[�W���[�i�[
    private TurnManager TurnMng;         //�^�[���}�l�[�W���[�̃X�N���v�g�󂯎��

    private int TurnNum;                   //�ő�^�[�����l
    private int InvertTurnNum;             //�㕔�^�[����

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
        TurnMng = TurnManager.gameObject.GetComponent<TurnManager>();           //�^�[���}�l�[�W���[�X�N���v�g�̊i�[

        //���l�i�[
        TurnNum = TurnMng.GetTurnCount();                       //�ő�^�[�������l�i�[
        InvertTurnNum = TurnMng.GetInvertCount();               //�������\�ϊ��c��^�[�����i�[
    }

    // Update is called once per frame
    void Update()
    {
        TurnNum = TurnMng.GetTurnCount();                       //�ő�^�[�������l�i�[
        InvertTurnNum = TurnMng.GetInvertCount();               //�������\�ϊ��c��^�[�����i�[

        //�\��
        TurnCountUI10[Mathf.FloorToInt(TurnNum / 10)].SetActive(true);
        TurnCountUI1[TurnNum % 10].SetActive(true);
        InvertTurnCountUI[InvertTurnNum].SetActive(true);

        //0����Ȃ��Ƃ��́{�P�̐���False�ɂ���(0�̂Ƃ���9)
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
       