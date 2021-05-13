using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorEnemy : MonoBehaviour
{
    private Animator m_Animator;
    private float m_Time = 0;

    private GameObject gameManager;
    private TurnManager turnManager;

    private GameObject m_AttackObject;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponentInChildren<Animator>();

        gameManager = GameObject.FindWithTag("GameManager");
        turnManager = gameManager.GetComponent<TurnManager>();

        m_AttackObject = GameObject.FindWithTag("ArmorEnemyAttack");
        m_AttackObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(turnManager.GetTurnCount() % 2 == 0)
        {
            m_Animator.SetBool("ArmorEnemyAttack", false);
            m_AttackObject.SetActive(false);
        }
        else
        {
            m_Animator.SetBool("ArmorEnemyAttack", true);
            m_AttackObject.SetActive(true);
        }
    }
}
