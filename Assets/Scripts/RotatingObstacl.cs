using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace AG2189
{
    public class RotatingObstacle : Obstacle
    {
        [SerializeField] private float rotationSpeed = 180f;

        private void Start()
        {
            fallSpeed = 200f;
        }

        public override void Fall()
        {
            base.Fall();
            Rotate();
        }

        private void Rotate()
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}

