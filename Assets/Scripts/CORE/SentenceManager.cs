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

    int chapterCount = 0;
    int storyCount = 0;
    bool isOnPanel;
    public bool isTexting;

    HyeonsolBrain hb;
    SulABrain sb;
    Coroutine textCo;
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

    private void TextRender()
    {
        textCo = StartCoroutine(LookTexty());
    }

    IEnumerator LookTexty()
    {
        isTexting = true;
        string txt = "";
        for(int i = 0; i < currentSO.SentenceList[storyCount].sentencetext.Length; i++)
        {
            txt += currentSO.SentenceList[storyCount].sentencetext[i];
            textSystem.TextRendering(currentSO.SentenceList[storyCount].nameText, txt);
            yield return new WaitForSeconds(0.05f);
        }
        isTexting = false;
        storyCount++;
    }

    public void LookFastText()
    {
        StopCoroutine(textCo);
        textSystem.TextRendering(currentSO.SentenceList[storyCount].nameText,
                                 currentSO.SentenceList[storyCount].sentencetext);

        isTexting = false;
        storyCount++;
    }

    public void NextSentence()
    {
        TextRender();
        #region ���� ���
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
        #region �̺�Ʈ
        if (currentSO.SentenceList[storyCount].CustomEvent.useCustomEvent)
        {
            currentSO.SentenceList[storyCount].CustomEvent.customEvent?.Invoke();
        }
        if (currentSO.SentenceList[storyCount].PhaseEvent.usePhaseEvent)
        {
            if(currentSO.SentenceList[storyCount].PhaseEvent.character == CharacterType.Hyeonsol)
            {
                hb.SetAction();
            }
            else if (currentSO.SentenceList[storyCount].PhaseEvent.character == CharacterType.SulA)
            {
                sb.SetAction();
            }
        }
        #endregion
        #region SO���Ƴ����
        if (currentSO.SentenceList.Count == storyCount)
        {
            SentenceRender();
        }
        #endregion
    }

    public void SetPanel()
    {
        textSystem.SetPanel(isOnPanel);
        Cursor.visible = !isOnPanel;
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
