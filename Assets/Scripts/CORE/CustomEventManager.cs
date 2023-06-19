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
        ActionList[3] = ThirdCustom;
        ActionList[4] = FourthCustom;
        ActionList[5] = ThirdCustom;
        ActionList[6] = FourthCustom;
        ActionList[7] = FifThCustom;
        ActionList[8] = SixCustom;
    }

    public void SixCustom()
    {
        StartCoroutine(SixCo());
    }

    IEnumerator SixCo()
    {
        yield return new WaitForSeconds(2);
        SentenceManager.Instance.SetPanel();
        GameManager.Instance.mainCam.transform.position += new Vector3(0, 0.5f, 0);
        GameManager.Instance.SetPlayerState(true, true, true);
        CharacterBrain _brain = CharacterManager.Instance.SulA.GetComponent<CharacterBrain>();
        _brain.canChecking = true;
    }

    public void FifThCustom()
    {
        StartCoroutine(FIfthCusCo());
    }

    IEnumerator FIfthCusCo()
    {
        yield return new WaitForSeconds(2);
        SentenceManager.Instance.SetPanel();
        EXUIManager.Instance.FadePanel(true);
        yield return new WaitForSeconds(1);
        CharacterManager.Instance.ExitEmotion(CharacterType.Hyeonsol);
        CharacterManager.Instance.ExitEmotion(CharacterType.SulA);
        CharacterManager.Instance.SitSet(CharacterType.Hyeonsol, true);
        CharacterManager.Instance.SitSet(CharacterType.SulA, true);
        CharacterManager.Instance.SulA.transform.rotation = Quaternion.Euler(0, -90, 0);
        CharacterManager.Instance.SulA.transform.position = new Vector3(8f, 3.451f, -8.8f);
        yield return new WaitForSeconds(3);
        EXUIManager.Instance.FadePanel(false);
        SentenceManager.Instance.SentenceRender();
        yield return new WaitForSeconds(1.5f);
        SentenceManager.Instance.SetPanel();
        SentenceManager.Instance.NextSentence();
    }

    public void FourthCustom()
    {
        GameManager.Instance.SetConversationBefore(CharacterManager.Instance.SulA, 1);
    }

    public void ThirdCustom()
    {
        CharacterBrain _brain = CharacterManager.Instance.Hyeonsol.GetComponent<CharacterBrain>();
        _brain.isSit = false;
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
