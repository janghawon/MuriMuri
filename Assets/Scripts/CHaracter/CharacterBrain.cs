using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class CharacterBrain : MonoBehaviour
{
    public bool canChecking;
    protected Animator _animator;
    
    [SerializeField] protected LayerMask _whatIsPlayer;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        canChecking = true;
    }

    protected void LookPlayer(GameObject player)
    {
        Vector3 playerdir = player.transform.position - transform.position;
        float yRot = Mathf.Atan2(playerdir.x, playerdir.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    public abstract void SetEmotion(float emotionNum);
    public abstract void OffEmotion();
}
