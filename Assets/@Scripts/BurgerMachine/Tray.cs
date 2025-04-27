using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    float heightOffset = 0.2f;

    [SerializeField]
    int maxCount = 5;

    readonly Stack<GameObject> _items = new Stack<GameObject>();

    public void AddItem(GameObject go)
    {
        Vector3 position = spawnPoint.position + Vector3.up * (heightOffset * _items.Count);
        GameObject newItem = Instantiate(go, position, Quaternion.identity, transform);
        _items.Push(newItem);
    }

    public GameObject RemoveItem()
    {
        if (_items.Count == 0) return null;
        GameObject removeItem = _items.Pop();
        Destroy(removeItem);
        return removeItem;
    }

    public bool IsFull()
    {
        return _items.Count >= maxCount;
    }
}
