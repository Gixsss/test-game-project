using Entity;
using UnityEngine;

namespace Projectiles
{
	public class LightSplash : MonoBehaviour
	{
		[SerializeField] private float splashDamage = 50f;
		[SerializeField] private Animator animator;
		
		public void Start()
		{
			var animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
			Destroy(gameObject, animationLength);
		}
		
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Enemy"))
			{
				var enemy = other.GetComponent<Enemy>();
				enemy.Health.Damage(splashDamage, other.gameObject);
			}
		}
	}
}