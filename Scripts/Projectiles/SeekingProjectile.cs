using Projectiles.Common;
using UnityEngine;

namespace Projectiles
{
	public class SeekingProjectile : Projectile
	{
		public float angleOffset = 30f; // launch offset angle (degrees)
		public float maxTurnSpeed = 10f; // degrees per second
		public float seekRange = 15f; // how far it can "see" enemies

		private Transform _target;

		protected override void Start()
		{
			base.Start();
			var baseDirection = Utils.GetMousePosition() - (Vector2)transform.position;
			baseDirection = Quaternion.Euler(0, 0, angleOffset) * baseDirection;
			transform.rotation = Quaternion.LookRotation(Vector3.forward, baseDirection);
			Rigidbody.linearVelocity = baseDirection.normalized * speed;
			_target = FindNearestEnemy();
		}

		private void Update()
		{
			if (_target is null)
			{
				_target = FindNearestEnemy();
				return;
			}
			Vector2 toTarget = (Vector2)_target.position - (Vector2)transform.position;
			if (toTarget.sqrMagnitude < 0.01f) return;
			float desired = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg - 90f;
			float current = transform.eulerAngles.z;
			float newAngle = Mathf.MoveTowardsAngle(current, desired, maxTurnSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Euler(0, 0, newAngle);
			Rigidbody.linearVelocity = transform.up * speed;
		}

		private Transform FindNearestEnemy()
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			Transform closest = null;
			float minDist = Mathf.Infinity;

			foreach (var e in enemies)
			{
				float dist = Vector2.Distance(transform.position, e.transform.position);
				if (dist < minDist && dist <= seekRange)
				{
					minDist = dist;
					closest = e.transform;
				}
			}

			return closest;
		}
	}
}