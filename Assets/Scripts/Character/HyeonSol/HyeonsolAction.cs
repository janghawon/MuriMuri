using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterCore;

public class HyeonsolAction : MonoBehaviour
{
    public List<UnityEvent> ActionDataList = new List<UnityEvent>();

    public void SampleMove()
    {
        GameObject sample = GameObject.Find("SamplePos");
        CharacterManager.Instance.MoveSet(CharacterType.Hyeonsol, sample.transform.position, 1);
    }
}
