using UnityEngine;

public interface IPickable
{
    GameObject GetGameObject();
    void OnPickedUp(IWorker worker);
    void OnDropped(IWorker worker);
}
