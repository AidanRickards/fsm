
using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class RunningState : State
    {
        private float _horizontalInput;

        public Rigidbody2D rigidbody;
        Vector2 move;
        public float speed = 5;

        // constructor
        public RunningState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            player.animator.Play("arthur_run", 0, 0);
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
            base.LogicUpdate();
            player.CheckForIdle();
            player.CheckForJump();
            Debug.Log("checking for idle");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            //running code
            move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            player.rb.velocity = new Vector2(move.x * speed, player.rb.velocity.y);
        }
    }
}