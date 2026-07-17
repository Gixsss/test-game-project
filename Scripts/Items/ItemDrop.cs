using Entity;
using Items.Data;
using UnityEngine;

namespace Items
{
	public class ItemDrop : MonoBehaviour
	{
		public ItemData[] itemsData;
		public float hoverAmplitude = 0.1f;
		public float hoverFrequency = 1.5f;

		public float magnetRange = 2.5f;
		public float acceleration = 8f;

		private Vector3 _startPos;
		private Transform _playerTransform;
		private float _currentSpeed;
		private bool _isMagnetActive;

		public void Start()
		{
			_startPos = transform.position;
			_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		}

		public void Update()
		{
			if (!_isMagnetActive)
			{
				Hover();
				CheckDistance();
			}
			else
			{
				MoveToPlayer();
			}
		}

		private void Hover()
		{
			var offset = Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;
			transform.position = _startPos + new Vector3(0, offset, 0);
		}

		private void CheckDistance()
		{
			if (Vector2.Distance(transform.position, _playerTransform.position) <= magnetRange) _isMagnetActive = true;
		}

		private void MoveToPlayer()
		{
			_currentSpeed += acceleration * Time.deltaTime;
			transform.position = Vector2.MoveTowards(
				transform.position,
				_playerTransform.position,
				_currentSpeed * Time.deltaTime
			);
			if (Vector2.Distance(transform.position, _playerTransform.position) < 0.05f) Pickup();
		}

		private void Pickup()
		{
			var playerGO = GameObject.FindGameObjectWithTag("Player");
			var player = playerGO.GetComponent<Player>();
			var itemData = itemsData[Random.Range(0, itemsData.Length)];
			player.Inventory.AddItem(new Item(itemData));
			Destroy(gameObject);
		}
	}
}