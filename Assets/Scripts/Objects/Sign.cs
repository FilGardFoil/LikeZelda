﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    public string dialog;
    public GameObject dialogBox;
    public Text dialogText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Отображать дилог если игрок находиться в поле действия и нажал на пробел.
        if (Input.GetButtonDown("action") && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);

        if (other.CompareTag("Player") && !other.isTrigger)
        {
            dialogBox.SetActive(false);
        }
    }
}