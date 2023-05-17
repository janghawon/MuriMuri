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

    public void SentenceNext()
    {
        // ¥Ÿ¿Ω

        if(currentSO.SentenceList.Count == storyCount)
        {
            SentenceRender();
        }
        else
        {
            storyCount++;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            textSystem.SetPanel();
        }
    }

    public void SentenceRender()
    {
        storyCount = 0;
        currentSO = SentenceList[0];
        SentenceList.RemoveAt(0);
    }
}
