using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorEnemy : MonoBehaviour
{
    private Animator m_Animator;
    private float m_Time = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Time += Time.deltaTime;
        if(m_Time <= 3)
        {
            m_Animator.SetBool("ArmorEnemyAttack", false);
        }
        else
        {
            m_Animator.SetBool("ArmorEnemyAttack", true);
        }
    }
}
