using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1StartPos : ChapterBase
{
    protected override void Awake()
    {
        distance = 2;
    }

    protected override void ActionEvent()
    {
        SentenceManager.Instance.SentenceRender();
        GameManager.Instance.Player.transform.position =
            new Vector3(9.3f, GameManager.Instance.Player.transform.position.y,
            GameManager.Instance.Player.transform.position.z);
        GameManager.Instance.SetConversationBefore(this.gameObject, 0);
        SentenceManager.Instance.SetPanel();
        SentenceManager.Instance.NextSentence();
        GameManager.Instance.SetPlayerState(false, false, false);
    }
}
