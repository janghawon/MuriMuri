using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCore;
using UnityEngine.AI;

public class CharacterManager : MonoBehaviour
{
    NavMeshAgent _navMesh;
    public static CharacterManager Instance;
    CharacterBrain _characterBrain;
    [SerializeField] private GameObject _hyeonsolObject;
    [SerializeField] private GameObject _sulAObject;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("심각한 오류");
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void MoveSet(CharacterType type, Vector3 targetPos, float time)
    {
        if(type == CharacterType.Hyeonsol)
        {
            _navMesh = _hyeonsolObject.GetComponent<NavMeshAgent>();
        }
        else
        {
            _navMesh = _sulAObject.GetComponent<NavMeshAgent>();
        }

        _navMesh.SetDestination(targetPos);
    }

    public void SetEmotion(CharacterType type, EmotionType emotion)
    {
        SelecTyper(type);
        _characterBrain.SetEmotion((float)emotion * 0.2f);
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
            case CharacterType.SulA:
                _characterBrain = _sulAObject.GetComponent<SulABrain>();
                break;
        }
    }
}
