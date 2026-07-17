using UnityEngine;
using Random = UnityEngine.Random;

namespace Projectiles
{
	public class LightProjectile : MonoBehaviour
	{
		[SerializeField] private float projectileSpeed = 10f;
		[SerializeField] private GameObject lightSplash;
		[SerializeField] private float arcAngle = 45f;
		[SerializeField] private Rigidbody2D rb;
		
		private Vector3 _destination;
		private float _randomizedAngle;
		private float _initialDistance;
		
		public void Awake()
		{
			_destination = Utils.GetMousePosition();
			_randomizedAngle = Random.Range(-arcAngle, arcAngle);
			_initialDistance = Vector3.Distance(transform.position, _destination);
			rb.SetRotation(rb.rotation + _randomizedAngle);
			rb.linearVelocity = Vector2.up * projectileSpeed;
		}

		public void Update()
		{
			if (Vector3.Distance(transform.position, _destination) < 0.5f)
			{
				Instantiate(lightSplash, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}

		public void FixedUpdate()
		{
			rb.SetRotation(Quaternion.LookRotation(Vector3.forward, _destination - transform.position)
			               * Quaternion.AngleAxis((Vector3.Distance(transform.position, _destination) / _initialDistance) * _randomizedAngle, Vector3.forward));
			rb.linearVelocity = transform.up * projectileSpeed;
		}
	}
}