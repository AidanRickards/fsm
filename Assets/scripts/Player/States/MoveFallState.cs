
using Player;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace player
{

    public class MoveFallState : State
    {
        public MoveFallState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.animator.Play("arthur_jump_forward", 0, 0);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CheckForLanding();

            if (player.rb.velocity.x <= 0)
            {
                player.sm.ChangeState(player.jumpState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        void CheckForLanding()
        {
            if (player.HasLanded())
            {
                player.sm.ChangeState(player.idleState);
            }
        }
    }
}