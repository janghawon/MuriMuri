using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextReader : MonoBehaviour
{
    [SerializeField] private List<TextAsset> dialogs = new List<TextAsset>();
    public List<List<Dictionary<string, object>>> data_DialogList;

    private void Awake()
    {
        for(int i = 0; i< dialogs.Count; i++)
        {
            data_DialogList[i] = CSVReader.Read(dialogs[i].name);
        }
    }
}
