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
    public GameObject TurnManager;      //�^�[���}�l�[�W���[�i�[
    private TurnManager TurnMng;         //�^�[���}�l�[�W���[�̃X�N���v�g�󂯎��

    public Text MaxTurn;                        //�ő�^�[�����\��
    public Text TopTurn;                         //�㕔�^�[�����\��
    public Text UnderTurn;                     //�����^�[�����\��

    public int MaxTurnNum;                   //�ő�^�[�����l
    public int TopTurnNum;                    //�㕔�^�[����
    public int UnderTurnNum;                 //�����^�[����

    // Start is called before the first frame update
    void Start()
    {
        TurnMng = TurnManager.gameObject.GetComponent<TurnManager>();           //�^�[���}�l�[�W���[�X�N���v�g�̊i�[

        //���l�i�[
        MaxTurnNum = TurnMng.GetMaxTurn();                    //�ő�^�[�������l�i�[
        TopTurnNum = TurnMng.GetMaxInvertCount();          //�������\�ϊ��c��^�[�����i�[
        UnderTurnNum = TurnMng.GetMaxInvertCount();

        //�^�[����UI�i�[
        MaxTurn.text = MaxTurnNum.ToString();                   //�ő�^�[����UI�i�[
        TopTurn.text = TopTurnNum.ToString();                    //�\���ϊ��^�[����UI�i�[
        UnderTurn.text = UnderTurnNum.ToString();             //���\�ϊ��^�[����UI�i�[
    }

    // Update is called once per frame
    void Update()
    {
        //�\���
       if(TurnMng.GetEnvironment() == 1)
        {
            //�\�̃^�[�����ƑS�̂̃^�[����������������
            /*�f�o�b�O�p �}�E�X���N���b�N*/
            if(Input.GetMouseButtonDown(0))
            {
                //���̃^�[�����𑝉�������
                if (UnderTurnNum < 3)
                {
                    UnderTurnNum += 1;
                }

                //�^�[��������
                MaxTurnNum -= 1;
                TopTurnNum -= 1;

                //UI�ɔ��f
                MaxTurn.text = MaxTurnNum.ToString();
                TopTurn.text = TopTurnNum.ToString();
                UnderTurn.text = UnderTurnNum.ToString();

                //�ϊ��J�E���g���Z
                TurnMng.AddInvertCount(1); 
            }
        }
       //�����
       else if(TurnMng.GetEnvironment() == -1)
        {
            //���̃^�[�����ƑS�̂̃^�[����������������
            if(Input.GetMouseButtonDown(0))
            {
                //�\�̃^�[�����𑝉�������A�ő�^�[������3�ȉ��ɂȂ����ꍇ���Z���Ȃ�
                if (TopTurnNum < 3 && MaxTurnNum > 3)
                {
                    TopTurnNum += 1;
                }

                //�^�[������
                MaxTurnNum -= 1;
                UnderTurnNum -= 1;

                //UI�ɔ��f
                MaxTurn.text = MaxTurnNum.ToString();
                TopTurn.text = TopTurnNum.ToString();
                UnderTurn.text = UnderTurnNum.ToString();

                //�ϊ��J�E���g���Z
                TurnMng.AddInvertCount(1);
            }
        }
    }
}
