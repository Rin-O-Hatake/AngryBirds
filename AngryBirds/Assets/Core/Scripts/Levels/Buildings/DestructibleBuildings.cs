using UnityEngine;

namespace Core.Scripts.Levels.Buildings
{
    public class DestructibleBuildings : MonoBehaviour
    {
        public float health = 100f;
        public float destructionThreshold = 50f;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Rigidbody2D rb = collision.rigidbody;

            if (rb != null)
            {
                float impactForce = rb.velocity.magnitude;
                TakeDamage(impactForce);
            }
            
            // if (rb != null)
            // {
            //     float impactForce = rb.velocity.magnitude;
            //
            //     // Проверяем, если объект упал с высоты
            //     if (collision.relativeVelocity.y < -1) // Если относительная скорость по оси Y отрицательная (падение)
            //     {
            //         float fallDamage = Mathf.Abs(collision.relativeVelocity.y) * 10; // Увеличьте множитель по мере необходимости
            //         TakeDamage(fallDamage);
            //     }
            //
            //     TakeDamage(impactForce);
            // }
        }

        public void TakeDamage(float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                DestroyObject();
            }
        }

        private void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}
