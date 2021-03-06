using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Field;  //視点(フィールドの真ん中)
    [SerializeField]
    private float m_Speed = 3;

    [SerializeField] private float m_CameraLookPoint;

    private bool m_RotFlag = false;

    [SerializeField]  private float m_Blend;

    Vector3 m_StartPosition, m_GoalPosition,m_InitPosition; //移動の始めと終わり

    private GameObject m_GameManager;
    TurnManager m_TurnManager;

    private GameObject m_MainCamera;
    private StartCamera m_StartCameraScript;

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

        m_MainCamera  = GameObject.FindWithTag("MainCamera");
        m_StartCameraScript = m_MainCamera.GetComponent<StartCamera>();

        m_GameManager = GameObject.FindWithTag("GameManager");
        m_TurnManager = m_GameManager.GetComponent<TurnManager>();

        m_InitPosition = this.transform.position;
        m_StartPosition = m_InitPosition;
        m_Direction = Direction.NONE;
        m_Blend = 0;

        m_PositionNum = PositionNum.Pos0;
    }

    // Update is called once per frame
    void Update()
    {

        if (!m_StartCameraScript.GetMove())
        {
            if (!m_RotFlag)
            {
                if (Input.GetKeyDown("joystick button 4") || Input.GetKeyDown(KeyCode.J))
                {
                    m_Direction = Direction.LEFT;
                    m_RotFlag = true;
                }
                if (Input.GetKeyDown("joystick button 5") || Input.GetKeyDown(KeyCode.L))
                {
                    m_Direction = Direction.RIGHT;
                    m_RotFlag = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {

        if (!m_StartCameraScript.GetMove())
        {
            Vector3 Pos = this.transform.position;

            this.gameObject.transform.LookAt(new Vector3(m_Field.transform.position.x, m_Field.transform.position.y - m_CameraLookPoint, m_Field.transform.position.z));

            if (m_Direction == Direction.LEFT)
            {
                if (m_PositionNum == PositionNum.Pos0)
                {
                    m_GoalPosition = new Vector3(m_InitPosition.z, transform.position.y, 0);
                }
                else if (m_PositionNum == PositionNum.Pos1)
                {
                    m_GoalPosition = new Vector3(m_InitPosition.x, transform.position.y, m_InitPosition.z);
                }
                else if (m_PositionNum == PositionNum.Pos2)
                {
                    m_GoalPosition = new Vector3(m_InitPosition.z * -1, transform.position.y, 0);
                }
                else if (m_PositionNum == PositionNum.Pos3)
                {
                    m_GoalPosition = new Vector3(m_InitPosition.x, transform.position.y, m_InitPosition.z * -1);
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
                    else if (m_PositionNum == PositionNum.Pos1)
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
                    m_GoalPosition = new Vector3(m_InitPosition.z * -1, transform.position.y, 0);
                }
                else if (m_PositionNum == PositionNum.Pos1)
                {
                    m_GoalPosition = new Vector3(m_InitPosition.x, transform.position.y, m_InitPosition.z * -1);
                }
                else if (m_PositionNum == PositionNum.Pos2)
                {
                    m_GoalPosition = new Vector3(m_InitPosition.z, transform.position.y, 0);
                }
                else if (m_PositionNum == PositionNum.Pos3)
                {
                    m_GoalPosition = new Vector3(m_InitPosition.x, transform.position.y, m_InitPosition.z);
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

    }

    public bool GetRotFlag()
    {
        return m_RotFlag;
    }
}
