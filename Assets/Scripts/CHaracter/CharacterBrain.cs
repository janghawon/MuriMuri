using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class CharacterBrain : MonoBehaviour
{
    public bool canChecking;
    protected Animator _animator;
    
    [SerializeField] protected LayerMask _whatIsPlayer;
    
    protected void LookPlayer(GameObject player)
    {
        Vector3 playerdir = player.transform.position - transform.position;
        float yRot = Mathf.Atan2(playerdir.x, playerdir.z) * Mathf.Rad2Deg;

        transform.DORotate(new Vector3(0, yRot, 0), 0.5f);
    }

    public abstract void SetEmotion(float emotionNum);
    public abstract void OffEmotion();
}
