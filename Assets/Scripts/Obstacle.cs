using UnityEngine;

namespace AG2189
{
    public class Obstacle : MonoBehaviour
    {

        void Update()
        {
            if (transform.position.y < -6f)
            {
                Destroy(gameObject);
               
            }

        }
    } 
}
