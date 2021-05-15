using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    GameObject m_Hole;

    float m_TimeCount;

    // Start is called before the first frame update
    void Start()
    {
        m_Hole = GameObject.FindWithTag("Hole");

        m_Hole.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        m_TimeCount += Time.deltaTime;

        if(m_TimeCount >= 2)
        {
            if(m_Hole.activeSelf)
            {
                m_Hole.SetActive(false);
            }
            else
            {
                m_Hole.SetActive(true);
            }

            m_TimeCount = 0;
        }
        
    }
}
