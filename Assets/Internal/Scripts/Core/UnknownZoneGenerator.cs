using UnityEngine;
using Utils;

namespace BeeColony.Core.Bees
{
    public class UnknownZoneGenerator : MonoBehaviourBase
    {
        [SerializeField] private GameObject unknownZonePrefab;
        [SerializeField] private float unknownZoneLength = 8f;
        [SerializeField] private float radius = 40f;

        private void Start()
        {
            Generate();
        }

        public void Generate()
        {
            var position = new Vector3Int();
            int count = Mathf.CeilToInt(radius / unknownZoneLength) * 2;
            var parent = gameObject.CreateEmpty().transform;
            parent.name = "UnknownZoneContainer";

            for (var y = -count; y < count; y++)
            {
                for (var x = -count; x < count; x++)
                {
                    if((x > -2 && x < 2) && (y < 2 && y > -2)) continue;

                    var newUnZone = Instantiate(unknownZonePrefab, 
                        new Vector2(x * unknownZoneLength / 2, y * unknownZoneLength / 2),
                        Quaternion.identity,
                        parent);
                }
            }
        }
    }
}