using UnityEngine;

namespace Core.Scripts.Levels.Buildings
{
    public class FallingObject : MonoBehaviour, IFallingBuilding
    {
        #region Fields

        [SerializeField] private float fallDamageThreshold = -5f;
        [SerializeField] private float fallDamageMultiplier = 10f;
        [SerializeField] private float minFallHeight = 2f;
        
        private float fallStartY;

        #endregion
        
        void Start()
        {
            fallStartY = transform.position.y;
        }
        
        public float CheckFallDamage(Rigidbody2D rigidbody)
        {
            if (rigidbody.velocity.y < fallDamageThreshold)
            {
                if (rigidbody.position.y > fallStartY)
                {
                    fallStartY = rigidbody.position.y;
                }
        
                float fallDistance = fallStartY - rigidbody.position.y;
                if (fallDistance >= minFallHeight)
                {
                    float fallDamage = fallDistance * fallDamageMultiplier;
                    return fallDamage;
                }
            }
            else
            {
                fallStartY = rigidbody.position.y;
            }

            return 0;
        }
    }
}
