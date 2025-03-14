using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KebabNPC : MonoBehaviour
{
    [SerializeField] private List<GameObject> selectableObjects;
    public List<int> _kebabPartsRequested;

    List<GameObject> _kebabParts = new List<GameObject>();
    
    public Transform graphicPreviewPos;

    void Awake()
    {
        GenerateKebabRequest();
    }
    
    public void GenerateKebabRequest()
    {
        _kebabPartsRequested = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            var x = Random.Range(1, selectableObjects.Count + 1);
            _kebabPartsRequested.Add(x);
            var gO = Instantiate(selectableObjects[x-1], graphicPreviewPos);
            gO.transform.rotation = Quaternion.Euler(90, 0, 0);
            gO.transform.localScale = Vector3.one * 0.1f;
            _kebabParts.Add(gO);
            
        }
    }

    private int shownItem;
    private float time;
    private float maxCooldown = 0.3f;
    
    void Update()
    {
        time += Time.deltaTime;

        if (time > maxCooldown)
        {
            time = 0;
            for (int i = 0; i < _kebabParts.Count; i++)
            {
                if (i != shownItem)
                {
                    _kebabParts[i].SetActive(false);
                }
                else
                {
                    _kebabParts[i].SetActive(true);
                }
            }

            shownItem++;
            
            if (shownItem >= _kebabParts.Count)
                shownItem = 0;
        }
    }

    public List<int> GetRequestedKebabParts()
    {
        return _kebabPartsRequested;
    }
}
