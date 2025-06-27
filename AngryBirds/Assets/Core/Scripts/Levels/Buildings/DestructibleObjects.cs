using UnityEngine;

namespace Core.Scripts.Levels.Buildings
{
    public class DestructibleObjects : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _health;
        [SerializeField] private IFallingBuilding _fallingBuilding;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private ITakingDamage _takingDamage;

        #endregion

        #region MonoBehavior

        private void Start()
        {
            _takingDamage = new HealthObject(_health);
            _takingDamage.OnDeath += Die;
        }

        private void OnDestroy()
        {
            _takingDamage.OnDeath -= Die;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            float collisionDamage = CalculateCollisionDamage(collision);
            _takingDamage.TakeDamage(collisionDamage);
        }

        private void Update()
        {
            _fallingBuilding?.CheckFallDamage(_rigidbody);
        }

        #endregion

        private float CalculateCollisionDamage(Collision2D collision)
        {
            float relativeVelocity = collision.relativeVelocity.magnitude;
            float damage = relativeVelocity;
            return damage;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
