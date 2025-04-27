using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using UnityEngine;

public class CarriedItems
{
    readonly List<IPickable> carriedItems = new List<IPickable>();

    GameObject _gameObject;

    CarriedItems(GameObject go)
    {
        _gameObject = go;
    }

    public static CarriedItems Of(GameObject go)
    {
        return new CarriedItems(go);
    }


    public void Add(IPickable item)
    {
        carriedItems.Add(item);

        // TODO 정리
        item.GetGameObject().transform.SetParent(_gameObject.transform);
        item.GetGameObject().transform.localPosition = Vector3.up * carriedItems.Count * 0.3f;
        item.GetGameObject().transform.localRotation = Quaternion.identity;
    }
}
