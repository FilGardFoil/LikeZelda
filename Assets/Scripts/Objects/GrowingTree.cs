using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingTree : Interactable
{
    public bool isGrowing;
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
            if (!isGrowing)
            {
                // Открыть сундук.
                StartGrowing();
            }
        }
    }

    public void StartGrowing()
    {        
        context.Raise();
        isGrowing = true;
        animator.SetBool("IsGrowing", true);              
    }

    // определение положения игрока в зоне действия триггера.
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isGrowing)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isGrowing)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
