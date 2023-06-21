using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SulABrain : CharacterBrain
{
    SulAAction _sulAAction;
    int actionNum = 0;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sulAAction = GetComponent<SulAAction>();
    }

    public void SetAction()
    {
        _sulAAction.ActionDataList[actionNum]?.Invoke();
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
        if (canChecking && Vector3.Distance(this.transform.position, GameManager.Instance.Player.transform.position) < 2)
        {
            GameManager.Instance.SetConversationBefore(this.gameObject, 1);
            LookTrans(GameManager.Instance.mainCam);
            canChecking = false;
            SetAction();
        }
    }
}
