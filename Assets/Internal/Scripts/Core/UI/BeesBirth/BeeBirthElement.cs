using BeeColonyCore.Bees;
using BeeColonyCore.Spawners;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace BeeColonyCore.UI.Birth
{
    public class BeeBirthElement : MonoBehaviourBase
    {
        [SerializeField] private Text name;
        [SerializeField] private Image image;
        [SerializeField] private Button spawnButton;

        public void Construct(Bee bee, BeeSpawner beeSpawner)
        {
            name.text = bee.GetName();
            image.sprite = bee.GetSprite();
            spawnButton.onClick.AddListener(() => beeSpawner.AddToSpawnQueue(bee));
        }
    }
}