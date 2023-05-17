using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public abstract void SetEmotion(float emotionNum);
    public abstract void OffEmotion();
}
