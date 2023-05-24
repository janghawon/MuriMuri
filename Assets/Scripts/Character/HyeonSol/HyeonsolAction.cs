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

    private void Awake()
    {
        move = GameObject.Find("Player").GetComponent<PlayerMove>();
        cam = GameObject.Find("Player").GetComponent<PlayerCamera>();
    }

    public void SampleMove()
    {
        GameObject sample = GameObject.Find("SamplePos");
        CharacterManager.Instance.MoveSet(CharacterType.Hyeonsol, sample.transform.position, 1);
    }

    public void RunSchool()
    {
        CharacterManager.Instance.MoveSet(CharacterType.Hyeonsol, GameObject.Find("RunningPos").transform.position, 6);
        cam.canhor = true;
        Cursor.visible = false;
        StartCoroutine(RunSchoolCo());
    }

    IEnumerator RunSchoolCo()
    {
        yield return new WaitForSeconds(2f);
        SentenceManager.Instance.SetPanel();
        cam.canver = true;
    }
}
