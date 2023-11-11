using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClueQuest;
    public GameObject contextClueActive;
    public bool contextActive = false;

    public void ChangeContext()//bool isQuest)
    {
        contextActive = !contextActive;
        contextClueQuest.SetActive(contextActive);
        /*if (isQuest)
        {
            contextActive = !contextActive;
            contextClueQuest.SetActive(contextActive);
        }
        else
        {
            contextActive = !contextActive;
            contextClueActive.SetActive(contextActive);
        }*/
    }
}
