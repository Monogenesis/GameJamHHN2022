using UnityEngine;

namespace Units
{
    public class UnitMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private float speed = 1;

        private Vector2 _moveDirection;


        public void AlignDirection(Vector2 direction)
        {
            _moveDirection = direction;
        }

        private void FixedUpdate()
        {
            if (GameManager.State == GameManager.GameState.Running)
            {
                Move();
            }
        }

        private void Move()
        {
            rb2d.MovePosition(rb2d.position + (_moveDirection * speed * Time.deltaTime));
            ;
        }
    }
}