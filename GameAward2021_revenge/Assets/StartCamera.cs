using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCamera : MonoBehaviour
{

    private GameObject m_Player;   //�v���C���[�I�u�W�F�N�g

    private Vector3 m_StartPosition;   //���`��Ԃ�����Ƃ��̍ŏ��̍��W
    private Vector3 m_GoalPosition;    //�I���̂Ƃ�

    [SerializeField] private Vector3 m_AddPosition = new Vector3(0.0f,2.0f,-1.5f);   //�ŏ��̈ʒu���v���C���[���璲������p

    public bool m_StartCameraMove;  //�X�^�[�g���̃J�������쓮����

    private float m_Blend = 0;  //���`��Ԃ̃u�����h�l
    private float m_MoveSpeed = 0.5f;  //���x

    // Start is called before the first frame update
    void Start()
    {
        m_GoalPosition = new Vector3(0.0f, 37.0f, -20.0f);

        m_Player = GameObject.FindWithTag("Player");
        transform.position = new Vector3(m_Player.transform.position.x + m_AddPosition.x, m_Player.transform.position.y + m_AddPosition.y, m_Player.transform.position.z + m_AddPosition.z);
        m_StartPosition = transform.position;

        m_StartCameraMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(!m_StartCameraMove)
        {
            return;
        }

        if(m_Blend > 1)
        {
            m_StartCameraMove = false;
        }

        Vector3 Pos = transform.position;
        Pos = Vector3.Lerp(m_StartPosition, m_GoalPosition, m_Blend);
        this.transform.position = Pos;

        m_Blend += m_MoveSpeed * Time.deltaTime;
    }

    public bool GetMove()
    {
        return m_StartCameraMove;
    }
}
