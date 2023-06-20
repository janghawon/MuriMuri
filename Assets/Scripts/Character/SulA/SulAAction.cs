using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterCore;
using DG.Tweening;

public class SulAAction : MonoBehaviour
{
    SulABrain _brain;
    TextSystem textSystem;
    public List<UnityEvent> ActionDataList = new List<UnityEvent>();

    Vector3 targetTrans;
    private void Awake()
    {
        textSystem = GameObject.Find("UICANVAS").GetComponent<TextSystem>();
        _brain = GetComponent<SulABrain>();
    }

    public void Chapter2Start()
    {
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
