using player;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public SpriteRenderer sr;
        public Animator animator;

        bool isGrounded;

        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public JumpState jumpState;
        public MoveFallState moveFallState;

        public StateMachine sm;



        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sm = gameObject.AddComponent<StateMachine>();
            sr = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
            jumpState = new JumpState(this, sm);
            moveFallState = new MoveFallState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);

            UIscript.ui.DrawText(s);

            UIscript.ui.DrawText("Press I for idle / R for run");


            if (rb.velocity.x > 0)
            {
                sr.flipX = false;
            }
            if (rb.velocity.x < 0)
            {
                sr.flipX = true;
            }
        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }


        public void CheckForRun()
        {
            if (isGrounded)
            {
                if (Input.GetKey("right") || Input.GetKey("left")) // key held down
                {
                    sm.ChangeState(runningState);
                    return;
                }
            }
        }


        public void CheckForIdle()
        {
            if (isGrounded)
            {

                if (Input.GetKey("right") == false)
                {
                    if (Input.GetKey("left") == false)
                    {
                        sm.ChangeState(idleState);
                    }
                }

            }
        }

        public void CheckForJump()
        {
            if (isGrounded)
            {
                if (Input.GetKey("right") == false && Input.GetKey("left") == false)
                {
                    if (Input.GetKey("j"))
                    {
                        rb.velocityY = 10f;
                        sm.ChangeState(jumpState);
                    }
                }
            }
        }

        public void CheckForFall()
        {
            if (!isGrounded)
            {
                if(Input.GetKey("left") || Input.GetKey("right"))
                {

                }
            }
        }

        public bool HasLanded() 
        {
            if (rb.velocity.y <= 0 && isGrounded)
            {
                return true;
            }
            return false;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            isGrounded=false;
        }
    }

}