using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rig;                                      //Rigidbody取得用

    [SerializeField] private float AngleSpeed;           //回転速度
    [SerializeField] private float MoveSpeed;
    private float Speed;
    private float Power = 3.0f;
    private Vector3 PlayerPos;                                  //プレイヤーのポジション
    private Vector3 Direction;

    private Ray ray;                                            //飛ばすレイ
    private RaycastHit hit;                                     //当たった対象物の情報格納
    private Vector3 rayPosition;                                //Rayの位置
    private float Distance = 0.6f;                              //Rayの長さ
    private Vector3 Cameraforward;



    public enum StatePattern //状態
    {
        Idle,
        Walk,
    }

    private StatePattern m_State; //現在の状態

    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GetComponent<Transform>().position;
        m_State = StatePattern.Idle;
        rig = GetComponent<Rigidbody>();
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

        //Debug.Log(m_State.ToString());
        rayPosition = transform.position;
        ray = new Ray(rayPosition, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * Distance, Color.red); // レイを赤色で表示させる
        //Debug.Log(hit.collider.gameObject.name);

        Debug.Log(m_State.ToString());

    }

    private void Idle()
    {

        Cameraforward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        Direction = Cameraforward * Input.GetAxisRaw("Vertical") + Camera.main.transform.right * Input.GetAxisRaw("Horizontal");

        Quaternion q = Quaternion.LookRotation(Direction.normalized, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * AngleSpeed);

        float rad=Mathf.Pow(Mathf.Max(0, Vector3.Dot(transform.forward, Direction)), Power);
        Speed = MoveSpeed * rad;




        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 && Input.GetAxisRaw("Vertical") == 0 && rad >= 1.0f)
        {
            m_State = StatePattern.Walk;
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1 && rad >=1.0f)
        {
            m_State = StatePattern.Walk;
        }

    }

    private void Walk()
    {
        transform.position += Time.deltaTime * Direction *Speed;

        if (Physics.Raycast(ray, out hit, Distance))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                
                m_State = StatePattern.Idle;
            }
        }

    }
}
