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
    GameObject item;

    readonly Stack<GameObject> _items = new Stack<GameObject>();

    void Start()
    {
        StartCoroutine(CoTestStack());
    }

    void AddItem(GameObject go)
    {
        Vector3 position = spawnPoint.position + Vector3.up * heightOffset * _items.Count;
        GameObject newItem = Instantiate(go, position, Quaternion.identity, transform);
        _items.Push(newItem);
    }

    GameObject RemoveItem()
    {
        if (_items.Count == 0) return null;
        GameObject removeItem = _items.Pop();
        Destroy(removeItem);
        return removeItem;
    }

    IEnumerator CoTestStack()
    {
        for (int i = 0; i < 10; i++) {
            AddItem(item);
            yield return new WaitForSeconds(1f);
        }
    }
}
