using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SentenceManager : MonoBehaviour
{
    public static SentenceManager Instance;
    public TextSystem textSystem;
    [SerializeField] private List<SentenceSO> SentenceList = new List<SentenceSO>();
    SentenceSO currentSO;

    int storyCount = 0;
    bool isOnPanel;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("!!!");
        }
        Instance = this;
        textSystem = GameObject.Find("UICANVAS").GetComponent<TextSystem>();
        DontDestroyOnLoad(this);
    }

    public void NextSentence()
    {
        textSystem.TextRendering(currentSO.SentenceList[storyCount].nameText, 
                                 currentSO.SentenceList[storyCount].sentencetext);

        if(currentSO.SentenceList.Count == storyCount)
        {
            SentenceRender();
        }
        else
        {
            storyCount++;
        }
    }

    public void SetPanel()
    {
        textSystem.SetPanel(isOnPanel);
        isOnPanel = !isOnPanel;
    }

    public void SentenceRender()
    {
        storyCount = 0;
        currentSO = SentenceList[0];
        SentenceList.RemoveAt(0);
        StartEmotion();
    }

    private void Start()
    {
        currentSO = SentenceList[0];
        StartEmotion();
    }

    private void StartEmotion()
    {
        for(int i = 0; i < currentSO.STARTEMOTION.Count; i++)
        {
            CharacterManager.Instance.SetEmotion(currentSO.STARTEMOTION[i].character,
                                                 currentSO.STARTEMOTION[i].emotion);
        }
    }
}
