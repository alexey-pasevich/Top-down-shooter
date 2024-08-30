using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public static class ScrollRectExt 
    {
        public static void FillItems<UIItem>(this Transform content, int dataCount, System.Action<int, UIItem> initFunc) where UIItem : MonoBehaviour
        { 
            var uiItems = content.GetComponentsInChildren<UIItem>(true);
            if (uiItems.Length == 0) 
            {
                return;
            }

            var uiPrefab = uiItems[0];
            int maxCount = Mathf.Max(dataCount, uiItems.Length);
            for (int i = 0; i < maxCount; i++)
            {
                UIItem uiItem;
                if (i < uiItems.Length)
                { 
                    uiItem = uiItems[i];
                }
                else
                {
                    uiItem = Object.Instantiate(uiPrefab, content);
                }

                if (i < dataCount)
                {
                    initFunc?.Invoke(i, uiItem);
                }
                uiItem.gameObject.SetActive(i < dataCount);
            }
        }
    }
}
