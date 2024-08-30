using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownShoot
{
    public class UIShopItem : MonoBehaviour
    {
        public event System.Action<string> onClick;
        private string m_id;

        [SerializeField] private Image m_icon;
        [SerializeField] private TMP_Text m_textName;
        [SerializeField] private TMP_Text m_priceText;

        public void Init(string id, int price, Sprite icon, string textName)
        { 
            m_id = id;
            m_icon.sprite = icon;
            m_textName.text = textName;

            m_priceText.text = price.ToString();
        }

        public void Click()
        {
            onClick?.Invoke(m_id);
        }

        internal void Init(string id1, string price, object value, string id2)
        {
            throw new NotImplementedException();
        }
    }
}
