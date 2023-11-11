using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapmDestroy : Interactable
{
    private bool isDestroy;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("action") && playerInRange)
        {
            if (!isDestroy)
            {
                // Открыть сундук.
                StartGrowing();
            }
        }
    }

    public void StartGrowing()
    {        
        context.Raise();
        isDestroy = true;
        animator.SetBool("IsDestroy", true);              
    }

    // определение положения игрока в зоне действия триггера.
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isDestroy)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isDestroy)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
