using CharacterCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyeonsolBrain : CharacterBrain
{
    HyeonsolAction _hyeonsolAction;
    int actionNum = 0;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _hyeonsolAction = GetComponent<HyeonsolAction>();
        canChecking = true;
    }

    public void SetAction()
    {
        _hyeonsolAction.ActionDataList[actionNum]?.Invoke();
        actionNum++;
    }

    public override void OffEmotion()
    {
        _animator.SetBool("isEmotion", false);
    }

    public override void SetEmotion(float emotionNum)
    {
        _animator.SetFloat("EmotionCount", emotionNum);
        _animator.SetBool("isEmotion", true);
    }

    private void Update()
    {
        if(canChecking && Vector3.Distance(this.gameObject.transform.position, GameManager.Instance.Player.transform.position) < 2.5f)
        {
            GameManager.Instance.SetConversationBefore(this.gameObject, 1);
            LookTrans(GameManager.Instance.mainCam);
            canChecking = false;
            GameManager.Instance.SetPlayerState(false, false, false);
            SentenceManager.Instance.SetPanel();
            SentenceManager.Instance.NextSentence();
        }
    }
}
