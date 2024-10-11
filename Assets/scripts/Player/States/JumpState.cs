
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class JumpState : State
    {
        Vector2 move;

        // constructor
        public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.animator.Play("arthur_jump_up", 0, 0);
            //jump code
            //player.rb.velocityY = 10f;

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

            if (player.rb.velocity.x > 0)
            {
                player.sm.ChangeState(player.moveFallState);
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
