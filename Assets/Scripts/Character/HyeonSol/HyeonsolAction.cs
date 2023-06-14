using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterCore;

public class HyeonsolAction : MonoBehaviour
{
    public List<UnityEvent> ActionDataList = new List<UnityEvent>();
    PlayerMove move;
    PlayerCamera cam;

    Vector3 targetTrans;
    private void Awake()
    {
        move = GameObject.Find("Player").GetComponent<PlayerMove>();
        cam = GameObject.Find("Player").GetComponent<PlayerCamera>();
    }

    public void RunSchool()
    {
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
        Debug.Log(1);
        CharacterManager.Instance.MoveSet(CharacterType.Hyeonsol, transform.position, 0);
        //CharacterManager.Instance.MoveSet(CharacterType.Hyeonsol, transform.position, 0);
        //SentenceManager.Instance.SetPanel();
        //transform.position = new Vector3(8.16f, 3, -9.7f);
        //CharacterManager.Instance.SitSet(CharacterType.Hyeonsol, true);
        //cam.canver = true;
        //move.canMove = true;
    }
}
