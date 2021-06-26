using UnityEngine;

namespace BeeColonyCore.UI.Birth
{
    public class MenusShowController : MonoBehaviour
    {
        [SerializeField] private float moveTime = 1f;
        
        public void Inverse(Menu menu)
        {
            if (menu.IsActive)
            {
                Hide(menu);
                return;
            }

            Show(menu);
        }
        
        public void Show(Menu menu)
        {
            menu.OffsetMax = menu.StartOffsetMax;
            menu.OffsetMin = menu.StartOffsetMin;
            menu.IsActive = true;
        }

        public void Hide(Menu menu)
        {
            var offset = menu.OffsetMax.y - menu.GetReferenceResolution().y;
            menu.OffsetMax = new Vector2(menu.OffsetMax.x, menu.GetReferenceResolution().y);
            menu.OffsetMin = new Vector2(menu.OffsetMin.x, offset);
            menu.IsActive = false;
        }
    }
}