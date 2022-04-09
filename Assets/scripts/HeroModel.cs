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
        private Vector2 playerVelocity = new Vector2(2f,10f);
        private Animator _animator;
        private SpriteRenderer _renderer;

        public void Start()
        {
            _animator = GetComponent<Animator>();
            _renderer = GetComponent<SpriteRenderer>();
            _animator.Play("Chicken Idle");
            _animator.enabled = true;
        }

        public void Update()
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(playerVelocity.x * inputX, playerVelocity.y * inputY, 0);

            if (movement.x != 0f) { _animator.Play("Chicken Run"); }
            else { _animator.Play("Chicken Idle"); }
            _renderer.flipX = movement.x > 0f;

            movement *= Time.deltaTime;

            transform.Translate(movement);

  
        }
    }
}
