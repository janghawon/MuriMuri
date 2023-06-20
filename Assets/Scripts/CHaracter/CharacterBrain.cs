using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class CharacterBrain : MonoBehaviour
{
    public bool canChecking;
    protected Animator _animator;

    public bool isSit;
    public bool isWalk;
    
    [SerializeField] protected LayerMask _whatIsPlayer;
    
    public void LookTrans(GameObject trans)
    {
        Vector3 dir = trans.transform.position - transform.position;
        float yRot = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        transform.DORotate(new Vector3(0, yRot, 0), 0.5f);
    }

    public abstract void SetEmotion(float emotionNum);
    public abstract void OffEmotion();
}
