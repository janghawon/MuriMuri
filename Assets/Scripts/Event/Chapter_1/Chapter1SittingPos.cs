using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1SittingPos : ChapterBase
{
    GameObject sittingLookingPos;
    protected override void Awake()
    {
        distance = 2;
        sittingLookingPos = GameObject.Find("SittingLookingPos");
    }

    protected override void ActionEvent()
    {
        SentenceManager.Instance.SetPanel();
        SentenceManager.Instance.NextSentence();
        GameManager.Instance.SetPlayerState(false, false, false);
        GameManager.Instance.Player.transform.position = this.transform.position;
        GameManager.Instance.SetConversationBefore(sittingLookingPos, 0);
    }
}
