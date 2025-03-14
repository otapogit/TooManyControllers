using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KebabNPC : MonoBehaviour
{
    [SerializeField] private List<GameObject> selectableObjects;
    public List<int> _kebabPartsRequested;

    public void GenerateKebabRequest()
    {
        _kebabPartsRequested = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            _kebabPartsRequested.Add(Random.Range(1, selectableObjects.Count + 1));
        }
    }

    public List<int> GetRequestedKebabParts()
    {
        return _kebabPartsRequested;
    }
}
