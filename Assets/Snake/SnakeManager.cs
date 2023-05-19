using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    private Transform _snake = null;
    private List<Transform> snakes = new List<Transform>();
    private BackGround _bg;

    [SerializeField] private float _width = 1f;
    [SerializeField] private float _range = 0.1f;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _moveSpeed = 2f;
    float[] timers;
    private void Awake()
    {
        _snake = GameObject.Find("Snake").transform;
        timers = new float[_snake.Find("Visual").childCount];
        for(int i = 0; i < _snake.Find("Visual").childCount; i++)
        {
            snakes.Add(_snake.Find("Visual").GetChild(i));
            timers[i] = 0f;
        }
        _bg = GameObject.Find("BGManager").GetComponent<BackGround>();
    }

    private void Start()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        for (int i = 0; i < snakes.Count; i++)
        {
            StartCoroutine(SSSNake(snakes[i], i));
            yield return new WaitForSeconds(_range);
        }
    }

    IEnumerator SSSNake(Transform obj, int idx)
    {
        while(true)
        {
            obj.transform.position = new Vector3(Mathf.Sin(timers[idx] * _speed) * _width, obj.transform.position.y);
            timers[idx] += Time.fixedDeltaTime;
            _snake.transform.Translate(new Vector3(0, _moveSpeed * 0.001f, 0));
            yield return null;
        }
    }
}
