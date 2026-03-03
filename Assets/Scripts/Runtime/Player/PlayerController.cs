using UnityEngine;

namespace Assets.Scripts.Runtime.Player
{
    public class RabbitController : MonoBehaviour
    {
        public float moveSpeed = 8f;
        public float jumpForce = 12f;
        private Rigidbody2D rb;
        private float screenWidth;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            screenWidth = Screen.width;
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
                moveDirection = Input.mousePosition.x < screenWidth / 2 ? -1 : 1;
            }
            else
            {
                moveDirection = Input.GetAxis("Horizontal");
            }

            rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
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
            if (rb.linearVelocity.y <= 0.1f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }
    }
}