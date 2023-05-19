using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Material _snakeMat;
    private List<Transform> snakes = new List<Transform>();
    Transform _snake;

    Material _mat;
    private void Awake()
    {
        _snake = GameObject.Find("Snake").transform;
        for (int i = 0; i < _snake.Find("Visual").childCount; i++)
        {
            snakes.Add(_snake.Find("Visual").GetChild(i));
        }
    }
    private void Start()
    {
        StartCoroutine(Changing());
    }
    IEnumerator Changing()
    {
        for (int i = 0; i < snakes.Count; i++)
        {
            StartCoroutine(SSSNake(snakes[i]));
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator SSSNake(Transform obj)
    {
        while (true)
        {
            _mat = obj.gameObject.GetComponent<Material>();
            _mat = _snakeMat;
            yield return null;
        }
    }
}
