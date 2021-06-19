using BeeColonyCore;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utils;
using Random = UnityEngine.Random;

namespace Internal.Scripts.Core.Tilemaps
{
    public class GrassGenerator : MonoBehaviourBase
    {
        [SerializeField] private Tilemap tilemap;
        [SerializeField] private Tile[] grassPrefabs;
        [SerializeField] private float spawnRadius = 40f;
        [SerializeField] private uint count = 200;
        
        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            var position = new Vector3Int();
            for (int i = 0; i < count; i++)
            {
                position = new Vector3Int(
                    (int)Random.Range(-spawnRadius, spawnRadius),
                    (int)Random.Range(-spawnRadius, spawnRadius),
                    0);
                
                tilemap.SetTile(position, grassPrefabs[Random.Range(0, grassPrefabs.Length - 1)]);
            }
        }
    }
}