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
    public GameObject Hyeonsol;
    public GameObject SulA;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("심각한 오류");
        }
        Instance = this;
        DontDestroyOnLoad(this);
        Hyeonsol = GameObject.Find("Hyeonsol");
        SulA = GameObject.Find("SulA");
    }

    public void MoveSet(CharacterType type, Vector3 targetPos, float speed)
    {
        if(type == CharacterType.Hyeonsol)
        {
            _navMesh = Hyeonsol.GetComponent<NavMeshAgent>();
        }
        else
        {
            _navMesh = SulA.GetComponent<NavMeshAgent>();
        }
        _navMesh.speed = speed;
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
                _characterBrain = Hyeonsol.GetComponent<HyeonsolBrain>();
                break;
            case CharacterType.SulA:
                _characterBrain = SulA.GetComponent<SulABrain>();
                break;
        }
    }
}
