using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject m_MainCameraObject;
    private GameObject m_UnderCameraObject;
    private Camera m_MainCamera;
    private Camera m_UnderCamera;

    void Start()
    {
        m_MainCameraObject = GameObject.FindWithTag("MainCamera");
        m_UnderCameraObject = GameObject.FindWithTag("UnderCamera");
        m_MainCamera = m_MainCameraObject.GetComponent<Camera>();
        m_UnderCamera = m_UnderCameraObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y > 0)
        {
            Vector3 vec3 = m_MainCamera.transform.position;
            vec3.y = transform.position.y;
            transform.LookAt(vec3);
        }
        else
        {
            Vector3 vec3 = m_UnderCamera.transform.position;
            vec3.y = transform.position.y;
            transform.LookAt(vec3);
        }
    }
}
