using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCore;
using UnityEngine.AI;

public class CharacterManager : MonoBehaviour
{
    Animator[] _characterAnimator = new Animator[2];
    NavMeshAgent[] _navMesh = new NavMeshAgent[2];

    public static CharacterManager Instance;
    CharacterBrain[] _characterBrain = new CharacterBrain[2];
    public GameObject Hyeonsol;
    public GameObject SulA;

    EmotionType[] currentEmoType = new EmotionType[2];
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("½É°¢ÇÑ ¿À·ù");
        }
        Instance = this;
        DontDestroyOnLoad(this);
        Hyeonsol = GameObject.Find("Hyeonsol");
        SulA = GameObject.Find("SulA");

        _navMesh[0] = Hyeonsol.GetComponent<NavMeshAgent>();
        _characterAnimator[0] = Hyeonsol.GetComponent<Animator>();
        _navMesh[1] = SulA.GetComponent<NavMeshAgent>();
        _characterAnimator[1] = SulA.GetComponent<Animator>();
        _characterBrain[0] = Hyeonsol.GetComponent<CharacterBrain>();
        _characterBrain[1] = SulA.GetComponent<CharacterBrain>();
    }

    public void MoveSet(CharacterType type, Vector3 targetPos, float speed)
    {
        GameObject selectChar;
        if(type == CharacterType.Hyeonsol)
        {
            selectChar = Hyeonsol;
        }
        else
        {
            selectChar = SulA;
        }

        _navMesh[(int)type].enabled = true;
        _navMesh[(int)type].speed = speed;
        _navMesh[(int)type].SetDestination(new Vector3(targetPos.x, selectChar.transform.position.y, targetPos.z));
        _characterBrain[(int)type].isWalk = true;
    }

    public void MoveCancle(CharacterType type)
    {
        _navMesh[(int)type].isStopped = true;
        _navMesh[(int)type].enabled = false;
        _characterBrain[(int)type].isWalk = false;
    }

    public void SitSet(CharacterType type, bool check)
    {
        _characterBrain[(int)type].isSit = check;
    }

    private void Update()
    {
        #region °È±â
        if (_characterBrain[0].isWalk)
        {
            _characterAnimator[0].SetBool("isWalk", true);
        }
        else
        {
            _characterAnimator[0].SetBool("isWalk", false);
        }

        if (_characterBrain[1].isWalk)
        {
            _characterAnimator[1].SetBool("isWalk", true);
        }
        else
        {
            _characterAnimator[1].SetBool("isWalk", false);
        }
        #endregion
        #region ¾É±â
        if (_characterBrain[0].isSit)
        {
            _characterAnimator[0].SetBool("isSit", true);
        }
        else
        {
            _characterAnimator[0].SetBool("isSit", false);
        }

        if(_characterBrain[1].isSit)
        {
            _characterAnimator[1].SetBool("isSit", true);
        }
        else
        {
            _characterAnimator[1].SetBool("isSit", false);
        }
        #endregion
    }

    public void SetEmotion(CharacterType type, EmotionType emotion)
    {
        if (emotion != EmotionType.backhand && emotion != currentEmoType[(int)type])
        {
            StartCoroutine(EmoCo(type, emotion));
        }
    }

    IEnumerator EmoCo(CharacterType type, EmotionType emotion)
    {
        currentEmoType[(int)type] = emotion;
        float b = (float)emotion * 0.14285f;
        float a = b - 0.1f;

        while(a < b)
        {
            a += 0.1f * Time.deltaTime * 5;
            a = Mathf.Clamp(a, a, b);
            _characterBrain[(int)type].SetEmotion(a);
            yield return null;
        }
    }

    public void ExitEmotion(CharacterType type)
    {
        _characterBrain[(int)type].OffEmotion();
    }

}
