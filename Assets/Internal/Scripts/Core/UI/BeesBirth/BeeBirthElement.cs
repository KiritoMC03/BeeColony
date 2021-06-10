using BeeColony.Core.Bees.Base;
using BeeColony.Core.Spawners;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace BeeColony.Core.UI.Birth
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
            spawnButton.onClick.AddListener(() => beeSpawner.Spawn(bee));
        }
    }
}