using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TopDownShoot
{
    public class UIPlayerInfoPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_moneyText;


        private void Start()
        {
            Refresh(GameInstance.instance.player.money);
        }

        private void OnEnable()
        {
            //Debug.Assert(GameInstance.instance);
            //Debug.Assert(GameInstance.instance?.player != null);

            if (GameInstance.instance && GameInstance.instance.player != null)
            {
                GameInstance.instance.player.changeMoney += Refresh;
            }
        }

        private void OnDisable()
        {
            GameInstance.instance.player.changeMoney -= Refresh;
        }

        private void Refresh(int money)
        { 
            m_moneyText.text = money.ToString();
        }
    }
}
