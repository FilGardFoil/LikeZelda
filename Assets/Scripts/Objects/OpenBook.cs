using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : Interactable
{
    public bool isOpen;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("action") && playerInRange)
        {
            if (!isOpen)
            {
                // Открыть сундук.
                StartOpening();
            }
        }
    }

    public virtual void StartOpening()
    {        
        context.Raise();
        isOpen = true;
        animator.SetBool("IsOpen", true);            
    }

    // определение положения игрока в зоне действия триггера.
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
