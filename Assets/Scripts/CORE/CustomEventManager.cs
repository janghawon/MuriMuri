using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CharacterCore;
using DG.Tweening;

public class CustomEventManager : MonoBehaviour
{
    [SerializeField] private Material _mat;
    [SerializeField] private GameObject _axe;
    TextSystem _textSystem;
    public Action[] ActionList = new Action[20];
    private void Awake()
    {
        _textSystem = GameObject.Find("UICANVAS").GetComponent<TextSystem>();
        ActionList[0] = TwelveCus;
        ActionList[1] = ThirdTenCus;
        ActionList[2] = ForTenCus;
        //ActionList[0] = FirstCustom;
        //ActionList[1] = FirstCustom;
        //ActionList[2] = SecondCustom;
        //ActionList[3] = ThirdCustom;
        //ActionList[4] = FourthCustom;
        //ActionList[5] = ThirdCustom;
        //ActionList[6] = FourthCustom;
        //ActionList[7] = FifThCustom;
        //ActionList[8] = SixCustom;
        //ActionList[9] = FourthCustom;
        //ActionList[10] = TenCustom;
        //ActionList[11] = FourthCustom;
        //ActionList[12] = TenCustom;
        //ActionList[13] = FourthCustom;
        //ActionList[14] = TenCustom;
        //ActionList[15] = FourthCustom;
        //ActionList[16] = ElevenCus;
        //ActionList[17] = TwelveCus;
        //ActionList[18] = ThirdTenCus;
        //ActionList[19] = ForTenCus;
    }

    public void ForTenCus()
    {
        GameObject ax = GameObject.Find("axe(Clone)");
        GameObject.Find("axe(Clone)").transform.parent = null;
        Sequence swq = DOTween.Sequence();
        swq.Join(ax.transform.DOMove(new Vector3(-4.3f, 0.5f, -14f), 0.5f));
        swq.Join(ax.transform.DORotate(new Vector3(5, 150, 120), 0.5f));
        swq.Play();
        StartCoroutine(ForTenCusCo());
    }

    IEnumerator ForTenCusCo()
    {
        EXUIManager.Instance.SetPanelColor(Color.red);
        EXUIManager.Instance.FadePanel(true);
        yield return new WaitForSeconds(2);
    }

    public void ThirdTenCus()
    {
        GameObject.Find("axe(Clone)").transform.parent = GameManager.Instance.Player.transform;
        GameManager.Instance.Player.transform.DOMoveX(-5.5f, 1);
    }

    public void TwelveCus()
    {
        StartCoroutine(TwelveCusCo());
    }

    IEnumerator TwelveCusCo()
    {
        _textSystem.canClick = false;
        yield return new WaitForSeconds(1);
        GameObject ax = Instantiate(_axe);

        ax.transform.position = new Vector3(-5.5f, 0, -15);
        ax.transform.rotation = Quaternion.Euler(0, 150, 0);
        ax.transform.DOMoveY(1, 2);
        yield return new WaitForSeconds(0.5f);
        _textSystem.canClick = true;
    }

    public void ElevenCus()
    {
        StartCoroutine(ElevenCusCo());
    }

    IEnumerator ElevenCusCo()
    {
        yield return new WaitForSeconds(2);
        SentenceManager.Instance.SetPanel();
        CharacterManager.Instance.ExitEmotion(CharacterType.SulA);
        GameManager.Instance.SetPlayerState(true, true, true);
        GameManager.Instance.SetConversationBefore(CharacterManager.Instance.SulA, 1);
        SulABrain _sb = CharacterManager.Instance.SulA.GetComponent<SulABrain>();
        _sb.LookTrans(GameManager.Instance.Player);
    }

    public void SixCustom()
    {
        StartCoroutine(SixCo());
    }

    IEnumerator SixCo()
    {
        _textSystem.canClick = false;
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
        Light _li = GameObject.Find("Directional Light").GetComponent<Light>();
        _li.gameObject.transform.rotation = Quaternion.Euler(120, -45, 0);
        Skybox sb = GameManager.Instance.mainCam.GetComponent<Skybox>();
        sb.material = _mat;
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

    public void TenCustom()
    {
        GameManager.Instance.SetConversationBefore(CharacterManager.Instance.Hyeonsol, 1);
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
