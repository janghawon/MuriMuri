using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2BackPos : ChapterBase
{
    protected override void ActionEvent()
    {
        GameManager.Instance.Player.transform.position = new Vector3(-6.7f, -0.17f, -14.5f);
        CharacterManager.Instance.SulA.transform.position = new Vector3(-4f, 0, -14.5f);

        SentenceManager.Instance.SentenceRender();
        SentenceManager.Instance.SetPanel();
        SentenceManager.Instance.NextSentence();
    }

    protected override void Awake()
    {
        distance = 2;
    }
}
