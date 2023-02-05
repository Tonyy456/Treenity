using UnityEditor;
using UnityEngine;

/*
 * Contributors: Anthony D'Alesandro
 * 
 * This allows you to move the rect transform corners to the anchor points or vice versa.
 */
namespace UnholyGround.UI
{
    public class AnchorHack : Editor
    {
        [MenuItem("uGUI/Stretch To Parent #q")]
        static void StretchToParent()
        {
            foreach (Transform transform in Selection.transforms)
            {
                RectTransform t = transform as RectTransform;

                if (t == null) return;

                t.anchorMin = new Vector2(0, 0);
                t.anchorMax = new Vector2(1, 1);
                t.offsetMin = t.offsetMax = new Vector2(0, 0);
            }
        }

        [MenuItem("uGUI/Stretch To AnchorsP #p")]
        static void StretchAnchors()
        {
            foreach (Transform transform in Selection.transforms)
            {
                RectTransform t = transform as RectTransform;
                RectTransform tp = transform.parent.GetComponent<RectTransform>();
                if (t == null || tp == null) return;

                Debug.Log($"Old values:\n anchorMin:{t.anchorMin} anchorMax: {t.anchorMax}");
                t.anchorMin += t.offsetMin / tp.rect.size;
                t.anchorMax += (t.offsetMax / tp.rect.size);
                t.offsetMin = t.offsetMax = new Vector2(0, 0);
            }
        }
    }
}
