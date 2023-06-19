using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CharacterCore;

public class CustomEventManager : MonoBehaviour
{
    TextSystem _textSystem;
    public Action[] ActionList = new Action[10];
    private void Awake()
    {
        _textSystem = GameObject.Find("UICANVAS").GetComponent<TextSystem>();
        ActionList[0] = FirstCustom;
        ActionList[1] = FirstCustom;
        ActionList[2] = SecondCustom;
        // ActionList[1] = FirstCustom;
        // ActionList[2] = SecondCustom;
        ActionList[3] = ThirdCustom;
    }

    public void ThirdCustom()
    {
        GameManager.Instance.SetConversationBefore(CharacterManager.Instance.Hyeonsol, 1);
        CharacterManager.Instance.SetEmotion(CharacterType.Hyeonsol, EmotionType.angry);

    }

    public void SecondCustom()
    {
        _textSystem.canClick = false;
        StartCoroutine(SecondCusCo());
    }

    IEnumerator SecondCusCo()
    {
        yield return new WaitForSeconds(2);
        SentenceManager.Instance.SetPanel();
        yield return new WaitForSeconds(2);
        SentenceManager.Instance.SetPanel();
        SentenceManager.Instance.NextSentence();
        yield return new WaitForSeconds(5);
    }

    public void FirstCustom()
    {
        _textSystem.canClick = false;
        StartCoroutine(FirstCusCo());
    }

    IEnumerator FirstCusCo()
    {
        yield return new WaitForSeconds(2);
        SentenceManager.Instance.SetPanel();
        GameManager.Instance.SetPlayerState(true, true, true);
    }
}
