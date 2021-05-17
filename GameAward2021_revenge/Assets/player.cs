using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    private Rigidbody rig;                                      //Rigidbody�擾�p

    [SerializeField] private float AngleSpeed;           //��]���x
    [SerializeField] private float MoveSpeed;
    private float Speed;
    private float Power = 3.0f;
    private Vector3 PlayerPos;                                  //�v���C���[�̃|�W�V����
    private Vector3 Direction;

    private Ray ray;                                            //��΂����C
    private RaycastHit hit;                                     //���������Ώە��̏��i�[
    private Vector3 rayPosition;                                //Ray�̈ʒu
    private float Distance = 0.6f;                              //Ray�̒���
    private Vector3 Cameraforward;

    private GameObject gameManager;
    private TurnManager turnManager;
    private bool isActive = false;

    //�J�������i�[����ϐ�
    private GameObject m_MainCameraObject;
    private GameObject m_UnderCameraObject;
    private Camera m_MainCamera;
    private Camera m_UnderCamera;

    //���C�g
    private Light m_PlayerLight;
    [SerializeField] private float m_LightUp = 10;


    public enum StatePattern //���
    {
        Idle,
        Walk,
    }

    private StatePattern m_State; //���݂̏��

    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GetComponent<Transform>().position;
        rig = GetComponent<Rigidbody>();
        gameManager = GameObject.FindWithTag("GameManager");
        turnManager = gameManager.GetComponent<TurnManager>();

        m_MainCameraObject = GameObject.FindWithTag("MainCamera");
        m_UnderCameraObject = GameObject.FindWithTag("UnderCamera");
        m_MainCamera = m_MainCameraObject.GetComponent<Camera>();
        m_UnderCamera = m_UnderCameraObject.GetComponent<Camera>();

        m_PlayerLight = GetComponentInChildren<Light>();

        m_State = StatePattern.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_State)
        {
            case StatePattern.Idle:
                Idle();
                break;

            case StatePattern.Walk:
                Walk();
                break;

        }

        rayPosition = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        ray = new Ray(rayPosition, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * Distance, Color.red); // ���C��ԐF�ŕ\��������
        int invertcount = turnManager.GetInvertCount();

        Debug.Log(turnManager.GetInvertCount());
        if (invertcount <= 0)
        {
            isActive = true;
        }
        if (isActive)
        {
            Vector3 pos = transform.position;
            pos.y = pos.y * -1 + 3.0f;
            transform.position = pos;
            turnManager.ChangeEnvironment();
            turnManager.ResetInvertCount();
            isActive = false;
        }
    }

    private void FixedUpdate()
    {
        if (m_State == StatePattern.Walk)
        {
            rig.velocity = Direction * Speed;


        }
    }

    private void Idle()
    {

        if (!isActive)
        {
            if (turnManager.GetEnvironment() == 1)
            {
                Cameraforward = Vector3.Scale(m_MainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
                Direction = Cameraforward * Input.GetAxisRaw("Vertical") + m_MainCamera.transform.right * Input.GetAxisRaw("Horizontal");
            }
            else
            {
                Cameraforward = Vector3.Scale(m_UnderCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
                Direction = Cameraforward * Input.GetAxisRaw("Vertical") + m_UnderCamera.transform.right * Input.GetAxisRaw("Horizontal");
            }


            //�v���C���[�̉�]�p�x���v�Z
            Quaternion q = Quaternion.LookRotation(Direction.normalized, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * AngleSpeed);

            float rad = Mathf.Pow(Mathf.Max(0, Vector3.Dot(transform.forward, Direction)), Power);
            Speed = MoveSpeed * rad;

            if (!Physics.Raycast(ray, out hit, 1.0f))
            {
                transform.position += Vector3.zero;
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 && Input.GetAxisRaw("Vertical") == 0 && rad >= 1.0f)
                {
                    m_State = StatePattern.Walk;
                }
                if (Input.GetAxisRaw("Horizontal") == 0 && Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1 && rad >= 1.0f)
                {
                    m_State = StatePattern.Walk;
                }
            }

        }
    }

    private void Walk()
    {
        //���������Ƃ��̃v���O������
        if (Physics.Raycast(ray, out hit, Distance))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                TurnReset();
            }

            if (hit.collider.CompareTag("HealItem"))
            {
                Destroy(hit.collider.gameObject);
                turnManager.AddTurnCount(1);
            }

            if (hit.collider.CompareTag("LightUp"))
            {
                Destroy(hit.collider.gameObject);
                m_PlayerLight.range += m_LightUp;
            }
            if (hit.collider.CompareTag("BreakWall"))
            {

                TurnReset();
                Destroy(hit.collider.gameObject);
            }

            if (hit.collider.CompareTag("SpeedDownWall"))
            {
                TurnReset();
                hit.collider.gameObject.SetActive(false);
            }

            if (hit.collider.CompareTag("Hole"))
            {
                SceneManager.LoadScene("GameOver");
            }

        }

    }

    private void TurnReset()
    {
        m_State = StatePattern.Idle;
        turnManager.AddGimmickTurnCount(1);
        turnManager.ReduceTrunCount(1);
        turnManager.ReduceInvertTrunCount(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArmorEnemyAttack"))
        {
            turnManager.ReduceTrunCount(1);
        }
    }
}
