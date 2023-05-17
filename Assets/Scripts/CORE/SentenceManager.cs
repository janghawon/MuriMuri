using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SentenceManager : MonoBehaviour
{
    public static SentenceManager Instance; 

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
        DontDestroyOnLoad(this);
    }

    public void SentenceNext()
    {
        // ¶ç¿ì±â

        if(currentSO.SentenceList.Count == storyCount)
        {
            SentenceRender();
        }
        else
        {
            storyCount++;
        }
    }

    public void OnPanel()
    {
        isOnPanel = true;
    }

    public void SentenceRender()
    {
        storyCount = 0;
        currentSO = SentenceList[0];
        SentenceList.RemoveAt(0);
        isOnPanel = false;
    }
}
