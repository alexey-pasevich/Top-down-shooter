using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class ShopState : GameState
    {
        [SerializeField] private UIShopPanel m_shopPanel;

        private List<ShopItemData> list = new List<ShopItemData>()
            {
                new ShopItemData(){ id = "gun", price = 130},
                new ShopItemData(){ id = "pistol", price = 140},
            };

        private Player m_player;

        private void Start()
        {
            m_player = GameInstance.instance.player;
        }

        protected override void OnEnter()
        {
            m_shopPanel.Fill(list);
        }

        private void OnEnable()
        {
            m_shopPanel.onTryBuyItem += OnTryBuyItem;
        }

        private void OnDisable()
        {
            m_shopPanel.onTryBuyItem -= OnTryBuyItem;
        }

        private void OnTryBuyItem(string itemId)
        {
            Debug.Log($"Try buy! - {itemId}");

            var itemData = list.Find(x => x.id == itemId);
            if (itemData != null)
            {
                if (m_player.money > itemData.price)
                { 
                    m_player.money -= itemData.price;
                    m_player.inventuory.Add(itemId);
                    Debug.Log($"{itemId} BUY!!!");
                }
            }
        }

        public void Back()
        { 
            States.instance.Pop();
        }
    }
}
