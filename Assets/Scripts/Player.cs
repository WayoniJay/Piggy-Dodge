using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;


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
            playerPos.x = Mathf.Clamp(playerPos.x, -1.98f, 1.98f);
            transform.position = playerPos;

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                // TODO: Add sound here (for .5 secs)
                AudioManager.instance.PlaySFX(AudioManager.instance.hit);
                StartCoroutine(nameof(ReloadScene));
            }
        }

        private IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("Game");
        }
    }
}



