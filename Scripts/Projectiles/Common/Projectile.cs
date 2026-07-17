using UnityEngine;

namespace Projectiles.Common
{
    public class Projectile : MonoBehaviour {

        public float damage;
        public float speed;

        protected Rigidbody2D Rigidbody;

        protected virtual void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            var projectileDirection = Utils.GetMousePosition() - (Vector2) transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, projectileDirection);
            Rigidbody.linearVelocity = projectileDirection.normalized * speed;
            Destroy(gameObject, 2f);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player") && !other.CompareTag("Projectile") && !other.CompareTag("Untagged")
                && !other.CompareTag("Collider"))
            {
                Destroy(gameObject);
            }
        }

    }
}