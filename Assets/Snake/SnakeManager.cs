using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    private Transform _snake = null;
    private List<Transform> snakes = new List<Transform>();
    [SerializeField] private List<Material> snakeMats = new List<Material>();

    [Header("배배배뱀")]
    [SerializeField] private float _width;
    [SerializeField] private float _range;
    [SerializeField] private float _wiggleSpeed;
    [SerializeField] private float _moveSpeed;
    public float Movespeed => _moveSpeed;

    [Header("투투투명")]
    [SerializeField] private float _blinkSpeed;

    float[] timers;
    float[] alphas;

    private void Awake()
    {
        MeshRenderer mat;
        _snake = GameObject.Find("Snake").transform;
        timers = new float[_snake.Find("Visual").childCount];
        alphas = new float[_snake.Find("Visual").childCount];

        for(int i = 0; i < _snake.Find("Visual").childCount; i++)
        {
            snakes.Add(_snake.Find("Visual").GetChild(i));
            mat = _snake.Find("Visual").GetChild(i).GetComponent<MeshRenderer>();
            Debug.Log(_snake.Find("Visual").GetChild(i));
            snakeMats.Add(mat.material);
            timers[i] = 0f;
            alphas[i] = 0f;
        }
    }

    private void Start()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        for (int i = 0; i < snakes.Count; i++)
        {
            yield return new WaitForSeconds(_range);
            StartCoroutine(SSSSNake(snakes[i], i));
            StartCoroutine(CCCColor(snakeMats[i], i));
        }
    }

    IEnumerator CCCColor(Material mat, int idx)
    {
        while(true)
        {
            mat.color = new Color(0, 1, 1, Mathf.Sin(alphas[idx] * _blinkSpeed));
            alphas[idx] += Time.fixedDeltaTime;
            yield return null;
        }
    }

    IEnumerator SSSSNake(Transform obj, int idx)
    {
        while(true)
        {
            obj.transform.position = new Vector3(Mathf.Sin(timers[idx] * _wiggleSpeed) * _width, obj.transform.position.y);
            timers[idx] += Time.fixedDeltaTime;
            yield return null;
        }
    }
}
