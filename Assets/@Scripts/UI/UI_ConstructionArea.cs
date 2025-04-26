using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_ConstructionArea : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        slider.value += 0.1f * Time.deltaTime;
    }
}
