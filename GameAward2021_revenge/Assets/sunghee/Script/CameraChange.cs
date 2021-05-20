using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    //�J�������i�[����ϐ�
    private GameObject m_MainCameraObject;
    private GameObject m_UnderCameraObject;
    private Camera m_MainCamera;
    private Camera m_UnderCamera;

    private GameObject m_GameManager;
    private TurnManager m_TurnManager;

    //�I�u�W�F
    private GameObject m_TopObject;
    private GameObject m_UnderObject;

    // Start is called before the first frame update
    void Start()
    {
        m_MainCameraObject = GameObject.FindWithTag("MainCamera");
        m_UnderCameraObject = GameObject.FindWithTag("UnderCamera");
        m_MainCamera = m_MainCameraObject.GetComponent<Camera>();
        m_UnderCamera = m_UnderCameraObject.GetComponent<Camera>();

        m_GameManager = GameObject.FindWithTag("GameManager");
        m_TurnManager = m_GameManager.GetComponent<TurnManager>();

        m_TopObject = GameObject.FindWithTag("TopObject");
        m_UnderObject = GameObject.FindWithTag("UnderObject");

        //���߂̓T�u�J�������I�t�ɂ��Ă���
        m_UnderCamera.enabled = false;

        m_UnderObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_TurnManager.GetEnvironment() == 1)
        {
            m_MainCamera.enabled = true;
            m_UnderCamera.enabled = false;
            m_TopObject.SetActive(true);
            m_UnderObject.SetActive(false);

            

        }
        else
        {
            m_MainCamera.enabled = false;
            m_UnderCamera.enabled = true;
            m_TopObject.SetActive(false);
            m_UnderObject.SetActive(true);

        }
    }
}
