using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall",fileName = "PlayerState_Fall")]
public class PlayerState_Fall: PlayerState
{
    [SerializeField] AnimationCurve speedCurve;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float stunTime = 0.3f;
    public bool dropStun => StateDuration >= stunTime;

    public override void LogicUpdate()
    {
        if(player.IsGround)
        {
            stateMachine.SwitchState(typeof(PlayerState_Land));
        }

        if(dropStun)
        {
            player.isStun = true;
        }

        if(input.Jump)
        {
            if(player.CanAirJump)
            {
                stateMachine.SwitchState(typeof(PlayerState_AirJump));

                return;
            }

            input.SetJumpInputBufferTimer();
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(moveSpeed);
        player.SetVelocityY(speedCurve.Evaluate(StateDuration));
    }
}
