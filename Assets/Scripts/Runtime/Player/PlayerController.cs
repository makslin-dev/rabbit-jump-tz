using UnityEngine;

namespace Assets.Scripts.Runtime.Player
{
    public class RabbitController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 8f;
        [SerializeField] private float _jumpForce = 12f;
        private Rigidbody2D _rb;
        private float _screenWidth;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _screenWidth = Screen.width;
        }

        void Update()
        {
            HandleInput();
            CheckScreenBounds();
        }

        void HandleInput()
        {
            float moveDirection = 0;

            if (Input.GetMouseButton(0))
            {
                moveDirection = Input.mousePosition.x < _screenWidth / 2 ? -1 : 1;
            }
            else
            {
                moveDirection = Input.GetAxis("Horizontal");
            }

            _rb.linearVelocity = new Vector2(moveDirection * _moveSpeed, _rb.linearVelocity.y);
        }

        void CheckScreenBounds()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0)
            {
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1, pos.y, pos.z));
            }
            else if (pos.x > 1)
            {
                transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, pos.y, pos.z));
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_rb.linearVelocity.y <= 0.1f)
            {
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
            }
        }
    }
}