using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCore;

public class SentenceManager : MonoBehaviour
{
    public static SentenceManager Instance;
    TextSystem textSystem;
    [SerializeField] private List<SentenceSO> SentenceList = new List<SentenceSO>();
    SentenceSO currentSO;

    int storyCount = 0;
    bool isOnPanel;

    HyeonsolBrain hb;
    SulABrain sb;
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

        #region 감정 사용
        if (currentSO.SentenceList[storyCount].useEmotion)
        {
            for(int i = 0; i < currentSO.SentenceList[storyCount].EmotionSetting.Count; i++)
            {
                CharacterManager.Instance.SetEmotion(currentSO.SentenceList[storyCount].EmotionSetting[i].character,
                                                 currentSO.SentenceList[storyCount].EmotionSetting[i].emotion);
            }
        }
        else
        {
            for (int i = 0; i < currentSO.SentenceList[storyCount].EmotionSetting.Count; i++)
            {
                CharacterManager.Instance.ExitEmotion(currentSO.SentenceList[storyCount].EmotionSetting[i].character);
            }
        }
        #endregion
        #region 이벤트
        if (currentSO.SentenceList[storyCount].CustomEvent.useCustomEvent)
        {
            currentSO.SentenceList[storyCount].CustomEvent.customEvent?.Invoke();
        }
        if (currentSO.SentenceList[storyCount].PhaseEvent.usePhaseEvent)
        {
            if(currentSO.SentenceList[storyCount].PhaseEvent.character == CharacterType.Hyeonsol)
            {
                Debug.Log(1);
                hb.SetAction();
            }
            else if (currentSO.SentenceList[storyCount].PhaseEvent.character == CharacterType.SulA)
            {
                sb.SetAction();
            }
        }
        #endregion
        #region SO갈아끼우기
        if (currentSO.SentenceList.Count == storyCount)
        {
            SentenceRender();
        }
        else
        {
            storyCount++;
        }
        #endregion
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
        hb = CharacterManager.Instance.Hyeonsol.GetComponent<HyeonsolBrain>();
        sb = CharacterManager.Instance.SulA.GetComponent<SulABrain>();
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
