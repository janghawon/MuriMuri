using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterCore;

public class HyeonsolAction : MonoBehaviour
{
    TextSystem textSystem;
    public List<UnityEvent> ActionDataList = new List<UnityEvent>();
    PlayerCamera cam;

    Vector3 targetTrans;
    private void Awake()
    {
        textSystem = GameObject.Find("UICANVAS").GetComponent<TextSystem>();
        cam = GameObject.Find("Player").GetComponent<PlayerCamera>();
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
        transform.position = new Vector3(8f, 3.451f, -9.7f);

        yield return new WaitForSeconds(2f);
        
        SentenceManager.Instance.SetPanel();
        textSystem.ClickEvent();
    }
}
