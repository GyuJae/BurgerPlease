using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    Vector3 _offset;

    void Start()
    {
        _offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        transform.position = target.position + _offset;
    }
}
