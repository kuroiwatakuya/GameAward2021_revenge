using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] GameObject gameManager;
    private TurnManager turnManager;
    private bool isActive = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        turnManager = gameManager.GetComponent<TurnManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (turnManager.GetTurnCount() % 2 == 0)
        {
            animator.SetBool("isActive", true);
        }
        else
        {
            animator.SetBool("isActive", false);
        }

    }
}
