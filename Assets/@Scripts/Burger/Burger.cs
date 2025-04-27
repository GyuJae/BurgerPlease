using UnityEngine;

public class Burger : MonoBehaviour, IPickable
{
    public GameObject GetGameObject()
    {
        return gameObject;
    }
    public void OnPickedUp(IWorker worker)
    {

    }
    public void OnDropped(IWorker worker)
    {
        throw new System.NotImplementedException();
    }
}
