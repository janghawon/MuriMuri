using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CharacterCore;

[System.Serializable]
public struct StartEmotion
{
    public CharacterType character;
    public EmotionType emotion;
}

[System.Serializable]
public struct EmotionDum
{
    public CharacterType character;
    public EmotionType emotion;
}

[System.Serializable]
public class PhaseEvent
{
    public bool usePhaseEvent;
    public CharacterType character;
}

[System.Serializable]
public class CustomEvent
{
    public bool useCustomEvent;
    public UnityEvent customEvent;
}

[System.Serializable]
public class TextDum
{
    public string nameText;
    public string sentencetext;
    public bool useEmotion;
    public List<EmotionDum> EmotionSetting = new List<EmotionDum>();
    public PhaseEvent PhaseEvent;
    public CustomEvent CustomEvent;
    public EventSO Event;
}

[CreateAssetMenu(menuName ="SO/SentenceSO")]
public class SentenceSO : ScriptableObject
{
    public List<StartEmotion> STARTEMOTION = new List<StartEmotion>();
    public List<TextDum> SentenceList = new List<TextDum>();
}
