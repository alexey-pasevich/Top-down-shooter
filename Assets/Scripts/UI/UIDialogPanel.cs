using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class UIDialogPanel : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_Text m_titleText;
        [SerializeField] private TMPro.TMP_Text m_mainText;

        public event System.Action onClick;
        public void SetText(string title, string text)
        {
            m_titleText.text = title;
            m_mainText.text = text;
        }

        public void OnClick()
        { 
            onClick?.Invoke();
        }
    }
}
