using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Field;  //���_(�t�B�[���h�̐^��)
    [SerializeField]
    private float m_Speed = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���E��]
        Vector3 axis = transform.TransformDirection(Vector3.up) * -Input.GetAxisRaw("Horizontal");
        axis = transform.TransformDirection(Vector3.down) * -Input.GetAxisRaw("Horizontal");
        transform.RotateAround(m_Field.transform.position, axis, m_Speed * Time.deltaTime);
        this.gameObject.transform.LookAt(m_Field.transform);
        // �㉺��]
        axis = transform.TransformDirection(Vector3.right) * -Input.GetAxisRaw("Vertical");
        axis = transform.TransformDirection(Vector3.left) * -Input.GetAxisRaw("Vertical");
        transform.RotateAround(m_Field.transform.position, axis, m_Speed * Time.deltaTime);
        this.gameObject.transform.LookAt(m_Field.transform);
    }
}
