using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class BurgerMachine : MonoBehaviour
{
    [SerializeField]
    Grill grill;

    [SerializeField]
    Tray tray;

    [SerializeField]
    GameObject burger;

    [SerializeField]
    GameObject maxBubble;

    void Start()
    {
        StartCoroutine(CoMakeBurger());
    }

    void Update()
    {
        maxBubble.SetActive(tray.IsFull());
    }

    void AddBurger()
    {
        if (tray.IsFull()) return;
        tray.AddItem(burger);
    }

    IEnumerator CoMakeBurger()
    {
        while (true) {
            AddBurger();
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
