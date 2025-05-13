using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace AG2189
{
    public abstract class Obstacle : MonoBehaviour
    {
        [SerializeField] protected float fallSpeed = 2f;

        protected virtual void Update()
        {
            Fall();
        }

        public virtual void Fall()
        {
            transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

            if (transform.position.y < -Camera.main.orthographicSize - 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}








//using UnityEngine;

//namespace AG2189
//{
//    public class Obstacle : MonoBehaviour
//    {

//        void Update()
//        {
//            if (transform.position.y < -6f)
//            {
//                Destroy(gameObject);

//            }

//        }
//    } 
//}
