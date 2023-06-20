using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterCore;

public class HyeonsolAction : MonoBehaviour
{
    HyeonsolBrain _brain;
    TextSystem textSystem;
    public List<UnityEvent> ActionDataList = new List<UnityEvent>();
    PlayerCamera cam;

    Vector3 targetTrans;
    private void Awake()
    {
        _brain = GetComponent<HyeonsolBrain>();
        textSystem = GameObject.Find("UICANVAS").GetComponent<TextSystem>();
        cam = GameObject.Find("Player").GetComponent<PlayerCamera>();
    }

    public void ByeBye()
    {
        StartCoroutine(ByeCo());
    }

    IEnumerator ByeCo()
    {
        textSystem.canClick = false;
        yield return new WaitForSeconds(2);
        CharacterManager.Instance.ExitEmotion(CharacterType.Hyeonsol);
        targetTrans = GameObject.Find("ClassExitPos").transform.position;
        CharacterManager.Instance.MoveSet(CharacterType.Hyeonsol, targetTrans, 2);

        yield return new WaitForSeconds(1);
        textSystem.canClick = true;
        yield return new WaitForSeconds(1);
        CharacterManager.Instance.MoveCancle(CharacterType.Hyeonsol);
        CharacterManager.Instance.Hyeonsol.transform.position = new Vector3(31.7f, 2.9f, 4.4f);
    }

    public void UpSit()
    {
        transform.position = new Vector3(8.31f, 2.9f, -9.276f);
        CharacterManager.Instance.SitSet(CharacterType.Hyeonsol, false);
        GameManager.Instance.SetConversationBefore(this.gameObject, 1);
        _brain.LookTrans(GameManager.Instance.mainCam);
    }

    public void RunSchool()
    {
        textSystem.canClick = false;
        targetTrans = GameObject.Find("RunningPos").transform.position;
        CharacterManager.Instance.MoveSet(CharacterType.Hyeonsol, targetTrans, 6);
        cam.canhor = true;
        StartCoroutine(RunSchoolCo());
    }

    IEnumerator RunSchoolCo()
    {
        yield return new WaitForSeconds(4f);

        while (Vector3.Distance(targetTrans, transform.position) > 1)
        {
            yield return null;
            continue;
        }
        CharacterManager.Instance.MoveCancle(CharacterType.Hyeonsol);
        SentenceManager.Instance.SetPanel();
        CharacterManager.Instance.SitSet(CharacterType.Hyeonsol, true);
        transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        transform.position = new Vector3(8f, 3.451f, -9.8f);

        yield return new WaitForSeconds(2f);
        
        SentenceManager.Instance.SetPanel();
        textSystem.ClickEvent();
    }
}
