using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class HeroModel : MonoBehaviour
    {
        public float jumpPower = 5f;
        public float moveSpeed = 3f;
        private bool jump = false;
        private Animator _animator; //References players animator
        private SpriteRenderer _renderer; //References players Renderer Component
        private Rigidbody2D _rb; //References Players Rigidbody component
        

        public LayerMask groundLayer;

        public void Start()
        {
            _animator = GetComponent<Animator>();
            _renderer = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
            _animator.Play("Chicken Idle");
            _animator.enabled = true;
        }

        public void Update()
        {
            Debug.DrawRay(transform.position, Vector2.down, Color.green);

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
            {
                jump = true;
            }

            var direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            if (direction.x != 0f) { _animator.Play("Chicken Run"); }
            else { _animator.Play("Chicken Idle"); }

            if (direction.x != 0)
            {
                _renderer.flipX = direction.x > 0f;
            }

           

        }

        public void FixedUpdate()
        {
            if (jump)
            {
                Jump();
               
            }
        }

        void Jump()
        {
            //_playerVelocity.y = jumpPower;
            _rb.velocity = Vector2.up * jumpPower;
            jump = false;
        }

        bool isGrounded()
        {
            Vector2 position = transform.position;
            Vector2 direction = Vector2.down;
            float distance = 1.0f;

            RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
            
            if (hit.collider != null)
            {
                return true;
            }

            return false;
        }
    }
}
