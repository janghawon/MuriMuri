using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    private Transform _snake = null;
    private List<Transform> snakes = new List<Transform>();
    [SerializeField] private List<Material> snakeMats = new List<Material>();

    [SerializeField] private float _width;
    [SerializeField] private float _range;
    [SerializeField] private float _wiggleSpeed;
    [SerializeField] private float _moveSpeed;
    public float Movespeed => _moveSpeed;
    float[] timers;

    private void Awake()
    {
        MeshRenderer mat;
        _snake = GameObject.Find("Snake").transform;
        timers = new float[_snake.Find("Visual").childCount];

        for(int i = 0; i < _snake.Find("Visual").childCount; i++)
        {
            snakes.Add(_snake.Find("Visual").GetChild(i));
            mat = _snake.Find("Visual").GetChild(i).GetComponent<MeshRenderer>();
            snakeMats.Add(mat.material);
            timers[i] = 0f;
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

    IEnumerator CCCColor(Material matm, int idx)
    {
        float a;
        while(true)
        {
            //mat.color = new Color(1, 1, 1, )
        }
    }

    IEnumerator SSSSNake(Transform obj, int idx)
    {
        while(true)
        {
            obj.transform.position = new Vector3(Mathf.Sin(timers[idx] * _wiggleSpeed) * _width, obj.transform.position.y);
            timers[idx] += Time.fixedDeltaTime;
            _snake.transform.Translate(new Vector3(0, _moveSpeed * 0.001f, 0));
            yield return null;
        }
    }
}
