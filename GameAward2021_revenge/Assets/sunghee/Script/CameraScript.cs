using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Field;  //視点(フィールドの真ん中)
    [SerializeField]
    private float m_Speed = 3;

    private bool m_RotFlag = false;

    [SerializeField]  private float m_Blend;

    Vector3 m_StartPosition, m_GoalPosition,m_InitPosition; //移動の始めと終わり

    enum PositionNum
    {
        Pos0,
        Pos1,
        Pos2,
        Pos3
    }

    enum Direction
    {
        RIGHT,
        LEFT,
        NONE
    }

    PositionNum m_PositionNum;

    Direction m_Direction;

    // Start is called before the first frame update
    void Start()
    {
        m_InitPosition = this.transform.position;
        m_StartPosition = m_InitPosition;
        m_Direction = Direction.NONE;
        m_Blend = 0;

        m_PositionNum = PositionNum.Pos0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_RotFlag)
        {
            if (Input.GetKeyDown("joystick button 4"))
            {
                m_Direction = Direction.LEFT;
                m_RotFlag = true;
            }
            if (Input.GetKeyDown("joystick button 5"))
            {
                m_Direction = Direction.RIGHT;
                m_RotFlag = true;
            }
        }
    }

    private void FixedUpdate()
    {
        this.gameObject.transform.LookAt(m_Field.transform);

        Vector3 Pos = this.transform.position;

        if (m_Direction == Direction.LEFT)
        {
            if (m_PositionNum == PositionNum.Pos0)
            {
                m_GoalPosition = new Vector3(m_InitPosition.z, m_InitPosition.y, 0);
            }
            else if (m_PositionNum == PositionNum.Pos1)
            {
                m_GoalPosition = new Vector3(m_InitPosition.x, m_InitPosition.y, m_InitPosition.z);
            }
            else if (m_PositionNum == PositionNum.Pos2)
            {
                m_GoalPosition = new Vector3(m_InitPosition.z * -1, m_InitPosition.y, 0);
            }
            else if (m_PositionNum == PositionNum.Pos3)
            {
                m_GoalPosition = new Vector3(m_InitPosition.x, m_InitPosition.y, m_InitPosition.z * -1);
            }

            Pos = Vector3.Lerp(m_StartPosition, m_GoalPosition, m_Blend);
            this.transform.position = Pos;

            m_Blend += m_Speed * Time.deltaTime;
            if (m_Blend > 1)
            {
                this.transform.position = m_GoalPosition;
                m_Direction = Direction.NONE;
                m_Blend = 0;
                m_StartPosition = m_GoalPosition;
                m_RotFlag = false;

                if (m_PositionNum == PositionNum.Pos0)
                {
                    m_PositionNum = PositionNum.Pos3;
                }
                else if(m_PositionNum == PositionNum.Pos1)
                {
                    m_PositionNum = PositionNum.Pos0;
                }
                else if (m_PositionNum == PositionNum.Pos2)
                {
                    m_PositionNum = PositionNum.Pos1;
                }
                else if (m_PositionNum == PositionNum.Pos3)
                {
                    m_PositionNum = PositionNum.Pos2;
                }

            }
        }

        if (m_Direction == Direction.RIGHT)
        {
            if (m_PositionNum == PositionNum.Pos0)
            {
                m_GoalPosition = new Vector3(m_InitPosition.z * -1, m_InitPosition.y, 0);
            }
            else if (m_PositionNum == PositionNum.Pos1)
            {
                m_GoalPosition = new Vector3(m_InitPosition.x, m_InitPosition.y, m_InitPosition.z * -1);
            }
            else if (m_PositionNum == PositionNum.Pos2)
            {
                m_GoalPosition = new Vector3(m_InitPosition.z, m_InitPosition.y, 0);
            }
            else if (m_PositionNum == PositionNum.Pos3)
            {
                m_GoalPosition = new Vector3(m_InitPosition.x, m_InitPosition.y, m_InitPosition.z);
            }

            Pos = Vector3.Lerp(m_StartPosition, m_GoalPosition, m_Blend);
            this.transform.position = Pos;

            m_Blend += m_Speed * Time.deltaTime;
            if (m_Blend > 1)
            {
                this.transform.position = m_GoalPosition;
                m_Direction = Direction.NONE;
                m_Blend = 0;
                m_StartPosition = m_GoalPosition;
                m_RotFlag = false;

                if (m_PositionNum == PositionNum.Pos0)
                {
                    m_PositionNum = PositionNum.Pos1;
                }
                else if (m_PositionNum == PositionNum.Pos1)
                {
                    m_PositionNum = PositionNum.Pos2;
                }
                else if (m_PositionNum == PositionNum.Pos2)
                {
                    m_PositionNum = PositionNum.Pos3;
                }
                else if (m_PositionNum == PositionNum.Pos3)
                {
                    m_PositionNum = PositionNum.Pos0;
                }

            }
        }

    }

    public bool GetRotFlag()
    {
        return m_RotFlag;
    }
}
