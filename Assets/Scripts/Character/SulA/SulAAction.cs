using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterCore;
using DG.Tweening;

public class SulAAction : MonoBehaviour
{
    [SerializeField] private GameObject _booldEffect;
    SulABrain _brain;
    TextSystem textSystem;
    public List<UnityEvent> ActionDataList = new List<UnityEvent>();

    Vector3 targetTrans;
    private void Awake()
    {
        textSystem = GameObject.Find("UICANVAS").GetComponent<TextSystem>();
        _brain = GetComponent<SulABrain>();
    }

    public void SCARE()
    {
        _brain.LookTrans(GameManager.Instance.mainCam);
    }

    public void REBIND()
    {
        this.gameObject.transform.position = new Vector3(8.7f, 3f, -5.7f);
        this.gameObject.transform.rotation = Quaternion.Euler(0, -142, 0);
        CharacterManager.Instance.SetEmotion(CharacterType.SulA, EmotionType.armhang);
    }

    public void CancleLook()
    {
        _brain.LookTrans(GameManager.Instance.mainCam);
        GameManager.Instance.SetConversationBefore(CharacterManager.Instance.SulA, 1);
    }

    public void LookBuilding()
    {
        GameObject pos = GameObject.Find("BuildingPos");
        _brain.LookTrans(pos);
        GameManager.Instance.SetConversationBefore(pos, 0);
    }

    public void SulaDie()
    {
        StartCoroutine(SUDIE());
    }

    IEnumerator SUDIE()
    {
        yield return new WaitForSeconds(0.25f);
        GameObject blood = Instantiate(_booldEffect);
        blood.transform.position = new Vector3(-4.38f, 0.75f, -14.46f);
        blood.transform.rotation = Quaternion.Euler(-42.1f, 129, 0);
    }

    public void Chapter2Start()
    {
        GameManager.Instance.Player.transform.position = new Vector3(6.5f, 2.83f, -7.7f);
        CharacterManager.Instance.SulA.transform.position = new Vector3(9, 2.9f, -8.2f);
        CharacterManager.Instance.SitSet(CharacterType.SulA, false);
        SentenceManager.Instance.SetPanel();
        GameManager.Instance.SetPlayerState(false, false, false);
        SentenceManager.Instance.NextSentence();
        GameManager.Instance.SetConversationBefore(this.gameObject, 1);
        _brain.LookTrans(GameManager.Instance.mainCam);
    }

    public void ClassRunning()
    {
        textSystem.canClick = false;
        CharacterManager.Instance.MoveCancle(CharacterType.SulA);
        this.gameObject.transform.position = new Vector3(8.7f, 3f, -5.7f);
        targetTrans = GameObject.Find("ClassDestinationPos").transform.position;
        CharacterManager.Instance.MoveSet(CharacterType.SulA, targetTrans, 1);
        StartCoroutine(ClassRunCo());
    }

    IEnumerator ClassRunCo()
    {
        GameManager.Instance.SetPlayerState(false, true, false);
        while (Vector3.Distance(targetTrans, transform.position) > 0.2f)
        {
            yield return null;
            continue;
        }
        targetTrans = GameObject.Find("ClassLookPos").transform.position;
        CharacterManager.Instance.MoveCancle(CharacterType.SulA);
        Vector3 dir = targetTrans - transform.position;
        float yRot = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        transform.DORotate(new Vector3(0, yRot, 0), 0.5f);
        yield return new WaitForSeconds(1);
        GameManager.Instance.SetConversationBefore(CharacterManager.Instance.SulA, 1);
        GameManager.Instance.SetPlayerState(false, false, false);
        SentenceManager.Instance.NextSentence();
        textSystem.canClick = true;
    }
}
