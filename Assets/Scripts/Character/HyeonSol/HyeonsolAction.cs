using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterCore;

public class HyeonsolAction : MonoBehaviour
{
    public List<UnityEvent> ActionDataList = new List<UnityEvent>();

    public void StartGame()
    {
        SentenceManager.Instance.SetPanel();
        SentenceManager.Instance.NextSentence();
        Cursor.visible = true;
    }

    public void SampleMove()
    {
        GameObject sample = GameObject.Find("SamplePos");
        CharacterManager.Instance.MoveSet(CharacterType.Hyeonsol, sample.transform.position, 1);
    }
}
