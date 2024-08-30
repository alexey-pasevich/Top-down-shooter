using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TopDownShoot
{
    public class UITaskPanel : MonoBehaviour
    {
        [SerializeField] private GameObject m_item;
        [SerializeField] private TMP_Text m_text;

        private void Awake()
        {
            m_item.SetActive(false);
        }

        public void SetTask(string text)
        { 
            m_text.text = text;
            m_item.SetActive(!string.IsNullOrEmpty(text));
        }

        public void CompleteTask()
        { 
            m_item.SetActive(false);
        }
    }
}
