using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomEventManager : MonoBehaviour
{
    public Action[] ActionList = new Action[10];
    private void Awake()
    {
        ActionList[0] = FirstCustom;
        ActionList[1] = FirstCustom;
        ActionList[2] = SecondCustom;
    }

    public void SecondCustom()
    {
        SentenceManager.Instance.SetPanel();
        SentenceManager.Instance.NextSentence();
    }

    public void FirstCustom()
    {
        SentenceManager.Instance.SetPanel();
        GameManager.Instance.SetPlayerState(true, true, true);
    }
}
