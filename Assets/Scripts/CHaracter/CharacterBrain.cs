using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBrain : MonoBehaviour
{
    protected Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public abstract void SetEmotion(float emotionNum);
    public abstract void OffEmotion();
}
