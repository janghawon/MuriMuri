using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    private BackGround _bg;
    private Transform _snake = null;
    private List<Transform> snakes = new List<Transform>();

    [SerializeField] private float _width;
    [SerializeField] private float _range;
    [SerializeField] private float _wiggleSpeed;
    [SerializeField] private float _moveSpeed;
    float[] timers;
    private void Awake()
    {
        _snake = GameObject.Find("Snake").transform;
        timers = new float[_snake.Find("Visual").childCount];
        for(int i = 0; i < _snake.Find("Visual").childCount; i++)
        {
            snakes.Add(_snake.Find("Visual").GetChild(i));
            Debug.Log(_snake.Find("Visual").GetChild(i));
            timers[i] = 0f;
        }
    }

    private void Start()
    {
        _bg = GameObject.Find("BG_1").GetComponent<BackGround>();
        _bg.speed = _moveSpeed;
        _bg = GameObject.Find("BG_2").GetComponent<BackGround>();
        _bg.speed = _moveSpeed;
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
            obj.transform.position = new Vector3(Mathf.Sin(timers[idx] * _wiggleSpeed) * _width, obj.transform.position.y);
            timers[idx] += Time.fixedDeltaTime;
            _snake.transform.Translate(new Vector3(0, _moveSpeed * 0.001f, 0));
            yield return null;
        }
    }
}
