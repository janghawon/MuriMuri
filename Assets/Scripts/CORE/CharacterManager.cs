using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCore;
using UnityEngine.AI;

public class CharacterManager : MonoBehaviour
{
    Animator _characterAnimator;
    NavMeshAgent _navMesh;
    public static CharacterManager Instance;
    CharacterBrain _characterBrain;
    public GameObject Hyeonsol;
    public GameObject SulA;

    bool isWalk;

    EmotionType currentEmoType;
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
        _navMesh = Hyeonsol.GetComponent<NavMeshAgent>();
        _characterAnimator = Hyeonsol.GetComponent<Animator>();
    }

    public void MoveSet(CharacterType type, Vector3 targetPos, float speed)
    {
        if(type == CharacterType.Hyeonsol)
        {
            _navMesh = Hyeonsol.GetComponent<NavMeshAgent>();
            _characterAnimator = Hyeonsol.GetComponent<Animator>();
        }
        else
        {
            _navMesh = SulA.GetComponent<NavMeshAgent>();
            _characterAnimator = SulA.GetComponent<Animator>();
        }
        
        _navMesh.speed = speed;
        _navMesh.SetDestination(targetPos);
        isWalk = true;
    }

    private void Update()
    {
        if (isWalk)
        {
            Debug.Log(_navMesh);
            if (!_navMesh.isStopped)
            {
                _characterAnimator.SetBool("isWalk", true);
            }
            else
            {
                _characterAnimator.SetBool("isWalk", false);
                isWalk = false;
            }
        }
    }

    public void SetEmotion(CharacterType type, EmotionType emotion)
    {
        SelecTyper(type);
        if(emotion == EmotionType.backhand)
        {
            _characterBrain.SetEmotion(0);
        }
        else
        {
            if(emotion == currentEmoType)
            {
                return;
            }
            StartCoroutine(EmoCo(emotion));
        }
    }

    IEnumerator EmoCo(EmotionType emotion)
    {
        currentEmoType = emotion;
        float b = (float)emotion * 0.2f;
        float a = b - 0.1f;

        while(a < b)
        {
            a += 0.1f * Time.deltaTime * 5;
            a = Mathf.Clamp(a, a, b);
            _characterBrain.SetEmotion(a);
            yield return null;
        }
        
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
