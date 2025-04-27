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

    public void Enter(Player player)
    {
    }
    public void Update(Player player)
    {
    }
    public void Exit(Player player)
    {
    }
}
