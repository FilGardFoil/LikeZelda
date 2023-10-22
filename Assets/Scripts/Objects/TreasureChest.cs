using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public SignaL raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
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
                OpenChest();
            }
            else
            {
                // Сундук уже открыт.
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        // Обработка событий при открытии сундука.        
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDescription;
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        raiseItem.Raise();        
        context.Raise();
        isOpen = true;
        animator.SetBool("opened", true);              
    }

    public void ChestAlreadyOpen()
    {
            dialogBox.SetActive(false);
            raiseItem.Raise();
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
