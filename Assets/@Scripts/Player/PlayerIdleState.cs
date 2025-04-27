public class PlayerIdleState : IPlayerState
{
    static PlayerIdleState _instance;
    public static PlayerIdleState Instance {
        get {
            return _instance ??= new PlayerIdleState();
        }
    }

    PlayerIdleState()
    {
    }

    public void Enter(Player player)
    {
        player.CrossFadeAnimate("Idle", 0.1f);
    }

    public void Update(Player player)
    {
        if (player.IsStop()) return;
        player.ChangeState(PlayerMoveState.Instance);
    }

    public void Exit(Player player)
    {
    }
}
