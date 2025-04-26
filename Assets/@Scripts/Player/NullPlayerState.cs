public class NullPlayerState : IPlayerState
{
    static NullPlayerState _instance;
    public static NullPlayerState Instance {
        get {
            return _instance ??= new NullPlayerState();
        }
    }

    NullPlayerState()
    {
    }

    public void Enter(PlayerController player)
    {
    }
    public void Update(PlayerController player)
    {
    }
    public void Exit(PlayerController player)
    {
    }
}
