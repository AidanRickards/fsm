
using UnityEngine;
namespace Player
{
    public class IdleState : State
    {
        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            player.rb.velocity = new Vector2(player.rb.velocity.x * 0.2f, player.rb.velocity.y);

            player.animator.Play("arthur_stand", 0, 0);
            base.Enter();
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
            player.CheckForRun();
            player.CheckForJump();
            Debug.Log("checking for run");
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}