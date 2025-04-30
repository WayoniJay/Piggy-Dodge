using UnityEngine;
using System.Collections.Generic;

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

                if(touchPos.x < 0)
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
            playerPos.x = Mathf.Clamp(playerPos.x, -2.25f, 2.25f);
            transform.position = playerPos;
        }
    } 
}
