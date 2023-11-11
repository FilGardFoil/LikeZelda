using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMagicBook : OpenBook
{
    private Animator animator;
    public GameObject magicEffect;

    public override void StartOpening()
    {        
        base.StartOpening(); 
        magicEffect.SetActive(true);            
    }
}
