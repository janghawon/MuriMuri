using CharacterCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyeonsolBrain : CharacterBrain
{
    public override void OffEmotion()
    {
        _animator.SetBool("isEmotion", false);
    }

    public override void SetEmotion(float emotionNum)
    {
        _animator.SetFloat("EmotionCount", emotionNum);
        _animator.SetBool("isEmotion", true);
    }
}
