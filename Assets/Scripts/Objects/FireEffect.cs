using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : Interactable
{
    private bool isFire;

    public GameObject fireEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("action") && playerInRange)
        {
            if (!isFire)
            {
                // Открыть сундук.
                StartGrowing();
            }
        }
    }

    public void StartGrowing()
    {        
        context.Raise();
        isFire = true;
        fireEffect.SetActive(true);              
    }

    // определение положения игрока в зоне действия триггера.
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isFire)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isFire)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
