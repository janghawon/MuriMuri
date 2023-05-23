using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCore;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _visual;
    private Animator _animatior;
    private AnimationType selectType = AnimationType.Idle;

    private void Awake()
    {
        _animatior = _visual.GetComponent<Animator>();
    }

    public void SetAnimationType(AnimationType type)
    {
        selectType = type;
    }
    public void WalkAnimation()
    {

    }

    public void IdleAnimation()
    {

    }

    public void SwingAnimation()
    {

    }

    private void Update()
    {
        if(selectType == AnimationType.Idle)
        {
            IdleAnimation();
        }
        else if (selectType == AnimationType.Walk)
        {
            WalkAnimation();
        }
    }
}
