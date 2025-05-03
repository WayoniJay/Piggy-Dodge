using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


namespace AG2189
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed;
        Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }


        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (touchPos.x < 0)
                {
                    rb.AddForce(Vector2.left * moveSpeed);
                }

                else
                {
                    rb.AddForce(Vector2.right * moveSpeed);
                }
            }

            else
            {
                rb.linearVelocity = Vector2.zero;
            }

            Vector3 playerPos = transform.position;
            playerPos.x = Mathf.Clamp(playerPos.x, -1.9f, 1.9f);
            transform.position = playerPos;

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}



