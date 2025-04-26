using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    GameObject background;

    [SerializeField]
    GameObject cursor;

    float _radius;
    Vector2 _touchPos;

    void Start()
    {
        _radius = background.GetComponent<RectTransform>().sizeDelta.y / 3;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        background.transform.position = eventData.position;
        cursor.transform.position = eventData.position;
        _touchPos = eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        cursor.transform.position = _touchPos;
        GameManager.Instance.ResetDir();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchDir = eventData.position - _touchPos;

        float moveDist = Mathf.Min(touchDir.magnitude, _radius);
        Vector2 moveDir = touchDir.normalized;
        Vector2 newPosition = _touchPos + moveDir * moveDist;
        cursor.transform.position = newPosition;

        GameManager.Instance.SetDir(moveDir);
    }
}
