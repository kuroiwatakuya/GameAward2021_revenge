using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCamera : MonoBehaviour
{

    private GameObject m_Player;   //プレイヤーオブジェクト

    private Vector3 m_StartPosition;   //線形補間させるときの最初の座標
    private Vector3 m_GoalPosition;    //終わりのとこ

    [SerializeField] private Vector3 m_AddPosition = new Vector3(0.0f,2.0f,-1.5f);   //最初の位置をプレイヤーから調整する用

    public bool m_StartCameraMove;  //スタート時のカメラが作動中か

    private float m_Blend = 0;  //線形補間のブレンド値
    private float m_MoveSpeed = 0.5f;  //速度

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
