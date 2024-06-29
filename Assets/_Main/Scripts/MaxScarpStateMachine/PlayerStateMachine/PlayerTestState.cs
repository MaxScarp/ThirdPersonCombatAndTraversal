using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float timer = 5.0f;

    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private void PlayerInput_OnJump()
    {
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
    }

    public override void Enter()
    {
        Debug.Log("Enter");

        PlayerInput.OnJump += PlayerInput_OnJump;
    }

    public override void Tick(float deltaTime)
    {
        timer -= deltaTime;

        Debug.Log(timer);

        if (timer <= 0.0f)
        {
            stateMachine.SwitchState(new PlayerTestState(stateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit");

        PlayerInput.OnJump -= PlayerInput_OnJump;
    }
}
