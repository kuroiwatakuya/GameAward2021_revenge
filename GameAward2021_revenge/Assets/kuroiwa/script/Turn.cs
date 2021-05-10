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
    private GameObject TurnManager;      //�^�[���}�l�[�W���[�i�[
    private TurnManager TurnMng;         //�^�[���}�l�[�W���[�̃X�N���v�g�󂯎��

    public Text TurnText;                        //�ő�^�[�����\��
    public Text InvertTurn;                     //�����^�[�����\��

    private int TurnNum;                   //�ő�^�[�����l
    private int InvertTurnNum;             //�㕔�^�[����

    // Start is called before the first frame update
    void Start()
    {
        TurnManager = GameObject.FindWithTag("GameManager");
        TurnMng = TurnManager.gameObject.GetComponent<TurnManager>();           //�^�[���}�l�[�W���[�X�N���v�g�̊i�[

        //���l�i�[
        TurnNum = TurnMng.GetTurnCount();                       //�ő�^�[�������l�i�[
        InvertTurnNum = TurnMng.GetInvertCount();               //�������\�ϊ��c��^�[�����i�[

        //�^�[����UI�i�[
        TurnText.text = TurnNum.ToString();                   //�ő�^�[����UI�i�[
        InvertTurn.text = InvertTurnNum.ToString();             //���\�ϊ��^�[����UI�i�[
    }

    // Update is called once per frame
    void Update()
    {
        TurnNum = TurnMng.GetTurnCount();                       //�ő�^�[�������l�i�[
        InvertTurnNum = TurnMng.GetInvertCount();               //�������\�ϊ��c��^�[�����i�[

        //UI�ɔ��f
        TurnText.text = TurnNum.ToString();
        InvertTurn.text = InvertTurnNum.ToString();
    }
}
       