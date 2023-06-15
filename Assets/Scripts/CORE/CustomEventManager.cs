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
    }

    public void FirstCustom()
    {
        StartCoroutine(FirstCustomCo());
    }

    IEnumerator FirstCustomCo()
    {
        yield return new WaitForSeconds(2);
        SentenceManager.Instance.SetPanel();
        GameManager.Instance.SetPlayerState(true, true, true);
    }
}
