using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeleKebabController : MonoBehaviour
{
    [SerializeField] private List<GameObject> selectableObjects;
    
    bool _isOnSelection;
    
    private List<Outline> _selectableObjectsOutline;
    private int _selectedObject;
    public List<int> _kebabParts = new List<int>();

    private KebabNPC _kebabNPC;
    public List<KebabNPC> npcPrefabs;
    public Vector3 npcSpawnPosition;
    
    public Camera cam;
    public Transform selectionPosition;
    public Transform notSelectionPosition;
    
    void Awake()
    {
        Activate();
        
        _selectableObjectsOutline = selectableObjects.Select(o => o.GetComponent<Outline>()).ToList();
        
        UpdateMaterial();
    }

    void Update()
    {
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
        _selectedObject--;
        
        if (_selectedObject < 0)
            _selectedObject = selectableObjects.Count - 1;
        
        UpdateMaterial();
    }

    void Left()
    {
        _selectedObject++;
        if (_selectedObject >= selectableObjects.Count)
            _selectedObject = 0;
        
        UpdateMaterial();
    }

    void SelectElement()
    {
        if (!_isOnSelection && _kebabNPC != null)
        {
            _isOnSelection = true;
            return;
        }
        
        if (_selectedObject == 0)
        {
            bool isDifferent = false;
            if (_kebabNPC is not null && _kebabParts.Count != _kebabNPC.GetRequestedKebabParts().Count)
            {
                isDifferent = true;
            }
            else
            {
                for (int i = 0; i < _kebabParts.Count; i++)
                {
                    if (_kebabParts[i] != _kebabNPC.GetRequestedKebabParts()[i])
                    {
                        isDifferent = true;
                    }
                }
            }
            if (isDifferent)
            {
                Die();
                return;
            }
            
            if (_kebabNPC)
                Destroy(_kebabNPC.gameObject);
            _isOnSelection = false;
            _kebabNPC = Instantiate(npcPrefabs[Random.Range(0, npcPrefabs.Count)], npcSpawnPosition, Quaternion.identity);
            _kebabParts = new List<int>();
            return;
        }
        
        _kebabParts.Add(_selectedObject);
    }

    void Die()
    {
        print("AAY");
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
