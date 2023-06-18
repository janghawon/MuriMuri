using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1StartPos : MonoBehaviour
{
    public bool isStart = true;

    private void Start()
    {
        isStart = true;
    }

    private void Update()
    {
        if(isStart && Vector3.Distance(GameManager.Instance.Player.transform.position, this.transform.position) < 2)
        {
            isStart = false;
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
}
