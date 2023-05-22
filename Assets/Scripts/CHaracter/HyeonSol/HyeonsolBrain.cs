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
        if(canChecking)
        {
            Collider[] hit = Physics.OverlapBox(transform.position, (transform.lossyScale * 5) / 2, Quaternion.identity, _whatIsPlayer);

            foreach (Collider hited in hit)
            {
                PlayerMove playerMove = hited.GetComponent<PlayerMove>();
                PlayerCamera camera = hited.GetComponent<PlayerCamera>();

                playerMove.canMove = false;
                camera.canMoveCam = false;

                GameManager.Instance.SetConversationBefore(this.gameObject);
                LookPlayer(GameManager.Instance.mainCam);
                canChecking = false;

                SentenceManager.Instance.SetPanel();
                SentenceManager.Instance.NextSentence();
                Cursor.visible = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + transform.up * 0.5f, transform.lossyScale * 5);
    }
}
