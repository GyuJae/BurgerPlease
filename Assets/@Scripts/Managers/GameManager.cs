using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Vector2 Dir { get; private set; }

    public void SetDir(Vector2 dir)
    {
        Dir = dir;
    }
    public void ResetDir()
    {
        Dir = Vector2.zero;
    }
}
