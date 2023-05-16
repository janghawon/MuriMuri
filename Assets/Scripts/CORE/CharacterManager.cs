using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCore;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    CharacterBrain _characterBrain;
    [SerializeField] private GameObject _hyeonsolObject;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("�ɰ��� ����");
        }
        Instance = this;

        DontDestroyOnLoad(this);
    }

    public void SetEmotion(CharacterType type, EmotionType emotion)
    {
        SelecTyper(type);
        _characterBrain.SetEmotion((float)emotion * 0.25f);
    }

    public void ExitEmotion(CharacterType type)
    {
        SelecTyper(type);
        _characterBrain.OffEmotion();
    }

    private void SelecTyper(CharacterType type)
    {
        CharacterType selectType = type;

        switch (selectType)
        {
            case CharacterType.Hyeonsol:
                _characterBrain = _hyeonsolObject.GetComponent<HyeonsolBrain>();
                break;
        }
    }
}
