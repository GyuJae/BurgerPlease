using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    static PlayerMoveState _instance;
    public static PlayerMoveState Instance {
        get {
            return _instance ??= new PlayerMoveState();
        }
    }

    PlayerMoveState()
    {
    }

    public void Enter(PlayerController player)
    {
        player.CrossFadeAnimate("Move", 0.05f);
    }

    public void Update(PlayerController player)
    {
        if (player.IsStop()) {
            player.ChangeState(PlayerIdleState.Instance);
            return;
        }

        Vector3 dir = GameManager.Instance.Dir;
        Vector3 moveDir = new Vector3(dir.x, 0, dir.y);

        Debug.Assert(Camera.main != null, "Camera.main is null!");

        float cameraYAngle = Camera.main.transform.eulerAngles.y;
        moveDir = (Quaternion.Euler(0, cameraYAngle, 0) * moveDir).normalized;

        player.Move(moveDir);
        player.Rotate(moveDir);
    }

    public void Exit(PlayerController player)
    {
    }
}
