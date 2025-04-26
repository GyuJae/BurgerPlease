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
        slider.value += 0.1f * Time.deltaTime;
    }
}
