using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace BeeColonyCore.UI.Birth
{
    public class Menu : MonoBehaviourBase
    {
        public bool IsActive = false;
        
        public Vector2 StartOffsetMin { get; private set; }
        public Vector2 StartOffsetMax { get; private set; }

        public Vector2 OffsetMin
        {
            get => new Vector2(rectTransform.offsetMin.x, rectTransform.offsetMin.y);
            set => rectTransform.offsetMin = value;
        }

        public Vector2 OffsetMax
        {
            get => new Vector2(-rectTransform.offsetMax.x, -rectTransform.offsetMax.y);
            set => rectTransform.offsetMax = -value;
        }

        [SerializeField] private Canvas parentCanvas;
        
        private RectTransform rectTransform;
        private CanvasScaler canvasScaler;

        private void Awake()
        {
            rectTransform = GetSafeComponent<RectTransform>();
            canvasScaler = parentCanvas.gameObject.GetSafeComponent<CanvasScaler>();

            StartOffsetMax = OffsetMax;
            StartOffsetMin = OffsetMin;
        }

        public Vector2 GetReferenceResolution()
        {
            rectTransform.offsetMax = rectTransform.offsetMax;
            
            return canvasScaler.referenceResolution;
        }
    }
}