using System;
using UnityEngine;

public class UI_OrderBubble : MonoBehaviour
{
    void LateUpdate()
    {
        Debug.Assert(Camera.main != null, "Camera.main != null");
        Vector3 dir = transform.position - Camera.main.transform.position;
        transform.LookAt(transform.position + dir);
    }
}
