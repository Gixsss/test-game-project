using Entity.Common;
using Projectiles.Common;
using UnityEngine;

namespace Entity
{
    public class Enemy : DamageableEntity
    {
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private GameObject expShardToDrop;
        [SerializeField] private Animator animator;
        [SerializeField] private BoxCollider2D boxCollider2D;
        [SerializeField] private Canvas canvas;
        [SerializeField] private CapsuleCollider2D capsuleCollider2D;
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private static readonly int Dead = Animator.StringToHash("Dead");
        private static readonly int Hit = Animator.StringToHash("Hit");
        
        private GameObject _target;

        private void Start()
        {
            _target = GameObject.Find("Player");
            Health.OnDeath += HandleDeath;
        }

        private void Update()
        {
            spriteRenderer.flipX = transform.position.x > _target.transform.position.x;
            var newPosition = Vector2.MoveTowards(rigidbody2D.position, _target.transform.position, movementSpeed * Time.fixedDeltaTime);
            rigidbody2D.MovePosition(newPosition);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var projectile = other.GetComponent<Projectile>();
            if (projectile is null) return;
            HandleDamageTaken(projectile.damage);
        }

        private void HandleDamageTaken(float damage)
        {
            Health.Damage(damage, gameObject);
            animator.SetTrigger(Hit);
        }

        private void HandleDeath()
        {
            Instantiate(expShardToDrop, transform.position, Quaternion.identity);
            animator.SetBool(Dead, true);
            enabled = false;
            boxCollider2D.enabled = false;
            capsuleCollider2D.enabled = false;
            Destroy(canvas.gameObject);
            Destroy(gameObject, 1.5f);
        }
    }
}
