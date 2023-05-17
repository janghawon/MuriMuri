using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
public struct TextDum
{
    public string nameText;
    public string sentencetext;
    public bool useEmotion;
    public EmotionDum EmotionSetting;
    public EventSO Event;
}

[CreateAssetMenu(menuName ="SO/SentenceSO")]
public class SentenceSO : ScriptableObject
{
    public List<StartEmotion> STARTEMOTION = new List<StartEmotion>();
    public List<TextDum> SentenceList = new List<TextDum>();
}
