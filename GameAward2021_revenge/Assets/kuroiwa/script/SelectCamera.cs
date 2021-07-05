using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//=============================
//�Z���N�g��ʂ̃J����
//=============================
public class SelectCamera : MonoBehaviour
{
    //�X�e�[�W�̒��S���W
    public float stagepos_X;
    public float stagepos_Z;

    [SerializeField] private GameObject Player;
    //[SerializeField] private GameObject StageSelect;
    public Transform Target;
    private Vector3 Offset;     //�J�����̑��΋���
    
    public GameObject[] StageSelectPos;
    private int SelectPosNum;
    private Vector3 angle;
    private Vector3 nextpos;
    private Vector3 keeppos;

    // Start is called before the first frame update
    void Start()
    {
        //�J�����ƃ^�[�Q�b�g�̑��΋���
        Offset = GetComponent<Transform>().position - Target.transform.position;
        SelectPosNum = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[���J�����̒����_�Ƃ���
        this.gameObject.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));
        
        GetComponent<Transform>().position = Target.transform.position + Offset;
    }
}
