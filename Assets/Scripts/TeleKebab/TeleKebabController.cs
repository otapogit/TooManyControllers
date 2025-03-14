using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class TeleKebabController : MonoBehaviour
{
    [SerializeField] private List<GameObject> selectableObjects;
    
    bool _isOnSelection;
    
    private List<Outline> _selectableObjectsOutline;
    private int _selectedObject;
    public List<int> kebabParts = new List<int>();

    private KebabNPC _kebabNpc;
    public List<KebabNPC> npcPrefabs;
    public Vector3 npcSpawnPosition;
    public Vector3 npcSpawnTarget;
    
    public Camera cam;
    public Transform selectionPosition;
    public Transform notSelectionPosition;

    public List<GameObject> singleObjects = new List<GameObject>();
    public List<Transform> selectedPositions;
    private readonly List<GameObject> _instantiatedObjects = new List<GameObject>();
    
    void Awake()
    {
        
        _selectableObjectsOutline = selectableObjects.Select(o => o.GetComponent<Outline>()).ToList();
        
        UpdateMaterial();
    }

    void Update()
    {
        if (_kebabNpc is not null)
        {
            _kebabNpc.transform.position = Vector3.Lerp(_kebabNpc.transform.position, npcSpawnTarget, Time.deltaTime);
            _kebabNpc.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            SpawnNPC();
        }
        
        if (_isOnSelection)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, selectionPosition.position, Time.deltaTime * 5f);
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, selectionPosition.rotation, Time.deltaTime * 5f);
        }
        else
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, notSelectionPosition.position, Time.deltaTime * 5f);
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, notSelectionPosition.rotation, Time.deltaTime * 5f);
        }
    }

    void UpdateMaterial()
    {
        for (int i = 0; i < selectableObjects.Count; i++)
        {
            _selectableObjectsOutline[i].OutlineColor = i == _selectedObject ? Color.white : Color.clear;
        }
    }

    void Right()
    {
        if (!_isOnSelection)
            return;
        _selectedObject--;
        
        if (_selectedObject < 0)
            _selectedObject = selectableObjects.Count - 1;
        
        UpdateMaterial();
    }

    void Left()
    {
        if (!_isOnSelection)
            return;
        _selectedObject++;
        if (_selectedObject >= selectableObjects.Count)
            _selectedObject = 0;
        
        UpdateMaterial();
    }

    void SelectElement()
    {
        if (!_isOnSelection && _kebabNpc != null)
        {
            _isOnSelection = true;
            return;
        }
        
        if (_selectedObject == 0)
        {
            bool isDifferent = false;
            if (_kebabNpc is not null && kebabParts.Count != _kebabNpc.GetRequestedKebabParts().Count)
            {
                isDifferent = true;
            }
            else
            {
                if (_kebabNpc != null)
                    isDifferent = !AreEqualIgnoringOrderAndDuplicates(kebabParts, _kebabNpc.GetRequestedKebabParts());
            }
            if (isDifferent)
            {
                Die();
                return;
            }
            
            SpawnNPC();
            foreach (var o in _instantiatedObjects)
            {
                Destroy(o);
            }
            _instantiatedObjects.Clear();
            return;
        }

        if (kebabParts.Count >= 3)
        {
            return;
        }
        
        kebabParts.Add(_selectedObject);
        var gO = Instantiate(singleObjects[_selectedObject - 1], selectedPositions[kebabParts.Count - 1].position,
            selectedPositions[kebabParts.Count - 1].rotation);
        gO.transform.localScale = Vector3.one * 0.3f;
        gO.SetActive(true);
        _instantiatedObjects.Add(gO);
    }
    
    bool AreEqualIgnoringOrderAndDuplicates(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count)
            return false;

        var count1 = list1.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var count2 = list2.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        return count1.Count == count2.Count && count1.All(kv => count2.TryGetValue(kv.Key, out int count) && count == kv.Value);
    }

    void Die()
    {
        print("AAY");
    }

    void SpawnNPC()
    {
        if (_kebabNpc)
            Destroy(_kebabNpc.gameObject);
        _isOnSelection = false;
        _kebabNpc = Instantiate(npcPrefabs[Random.Range(0, npcPrefabs.Count)], npcSpawnPosition, Quaternion.identity);
        kebabParts = new List<int>();
    }
    
    public void Activate()
    {
        EventManager.AKeyDown += Left;
        EventManager.DKeyDown += Right;
        EventManager.KKeyDown += SelectElement;
    }

    public void DeActivate()
    {
        EventManager.AKeyDown -= Left;
        EventManager.DKeyDown -= Right;
        EventManager.KKeyDown -= SelectElement;
    }
}
