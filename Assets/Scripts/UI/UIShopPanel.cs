using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class UIShopPanel : MonoBehaviour
    {
        public event System.Action<string> onTryBuyItem;

        [SerializeField] private Transform content;
        private List<UIShopItem> m_uiItems = new List<UIShopItem>();

        private void Clear()
        { 
            foreach (var item in m_uiItems)
            {
                item.onClick -= OnItemClick;
                item.gameObject.SetActive(false);
            }
        }

        public void Fill(List<ShopItemData> list)
        { 
            Clear();

            content.FillItems<UIShopItem>(list.Count, (index, uiItem) =>
            {
                var item = list[index];

                uiItem.Init(item.id, item.price, null, item.id);
                uiItem.onClick += OnItemClick;
                m_uiItems.Add(uiItem);
            });
            
        }

        private void OnItemClick(string id)
        {
            onTryBuyItem?.Invoke(id);
        }

        
    }

    public class ShopItemData
    {
        public string id;
        public int price;
    }
}
