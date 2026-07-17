using System;
using Entity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameMechanics
{
    public class DynamicEnemySpawner : MonoBehaviour
    {
        public float spawnCooldown = 3f;
        public float enemiesSpawnedAtOnce = 5f;
        public float distanceFromPlayer = 10f;
        
        [SerializeField] private Player player;
        [SerializeField] private GameObject enemyToSpawn; 
        
        private float _cooldownTimer;

        private void Update()
        {
            if (_cooldownTimer <= 0f)
            {
                for (var i = 0; i < enemiesSpawnedAtOnce; i++)
                {
                    Instantiate(enemyToSpawn, RandomizePositionAroundPlayer(distanceFromPlayer), Quaternion.identity);
                }
                _cooldownTimer = spawnCooldown;
            }
            else
            {
                _cooldownTimer -= Time.deltaTime;
            }
        }

        private Vector3 RandomizePositionAroundPlayer(float distanceFromPlayer)
        {
            var randomAngle = Random.Range(0f, Mathf.PI * 2);
            var offset = new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0) * distanceFromPlayer;
            return player.transform.position + offset;
        }
    }
}