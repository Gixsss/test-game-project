using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private TileBase floorTile;
    [SerializeField] private TileBase wallTile;
    [SerializeField] private int width = 30;
    [SerializeField] private int height = 20;
    [SerializeField] private int centerWeight = 3;
    [SerializeField] private int connectorWeight = 3;
    [SerializeField] private float decayChance = 0.5f;

    private Tilemap _tilemap;
    private static readonly Vector2Int[] FourDirections =
    {
        Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left
    };

    private void Start()
    {
        var gridGameObject = new GameObject("Grid");
        var grid = gridGameObject.AddComponent<Grid>();
        grid.cellSize = new Vector3(1, 1, 0);
        var tilemapGameObject = new GameObject("Tilemap");
        tilemapGameObject.transform.SetParent(gridGameObject.transform);
        _tilemap = tilemapGameObject.AddComponent<Tilemap>();
        var tilemapRenderer = tilemapGameObject.AddComponent<TilemapRenderer>();
        tilemapRenderer.sortingOrder = -10;
        GenerateMap();
    }

    private void GenerateMap()
    {
        foreach (var weighedTile in GenerateWeighedMap())
        {
            _tilemap.SetTile((Vector3Int)weighedTile.Position, weighedTile.Weight == 1 ? wallTile : floorTile);
        }
    }

    private HashSet<WeighedTile> GenerateWeighedMap()
    {
        var weighedMap = new HashSet<WeighedTile>();
        var emergencyStop = 0;
        var queue = new Queue<WeighedTile>();
        queue.Enqueue(new WeighedTile(Vector2Int.zero, centerWeight));
        while (queue.Count > 0 && emergencyStop < 1000000)
        {
            emergencyStop++;
            var weighedTile = queue.Dequeue();
            if (weighedMap.Add(weighedTile))
            {
                if (weighedTile.Weight <= 1) continue;
                foreach (var direction in FourDirections)
                {
                    var tileToAdd = new WeighedTile(
                        weighedTile.Position + direction,
                        weighedTile.Weight - (Random.value < decayChance ? 1 : 0)
                    );
                    queue.Enqueue(tileToAdd);
                }
            }
        }
        return weighedMap;
    }
    
    private struct WeighedTile : IEquatable<WeighedTile>
    {
        public Vector2Int Position;
        public readonly int Weight;

        public WeighedTile(Vector2Int position, int weight)
        {
            Position = position;
            Weight = weight;
        }

        public bool Equals(WeighedTile other)
        {
            return Position.Equals(other.Position);
        }

        public override bool Equals(object obj)
        {
            return obj is WeighedTile other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }
    }
}