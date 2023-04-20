using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        public int horizontal = 0;
        public int vertical = 0;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void FixedUpdate()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1;
                vertical = 0;
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = 1;
                vertical = 0;
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                vertical = 1;
                horizontal = 0;
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                vertical = -1;
                horizontal = 0;
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
