using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class DialogState : GameState
    {
        [SerializeField] private UIDialogPanel m_dialogPanel;

        private DialogData m_dialogData;
        private int m_dialogIndex;

        private void OnEnable()
        {
            

            m_dialogPanel.onClick += DialogOnClick;
        }

        private void DialogOnClick()
        {
            if (TryShow(++m_dialogIndex))
            {
                return;
            }
            
            States.instance.Pop();
        }

        private void OnDisable()
        {

            m_dialogPanel.onClick -= DialogOnClick;
        }

        public void ShowDialog(string id)
        {
            m_dialogData = GameInstance.instance.dialogs.GetDialog(id);

            if (m_dialogData == null)
            {
                Debug.Log($"[DIalogState]: Dialog '{id}' not found!");
                States.instance.Pop();
                return;
            }
            m_dialogIndex = 0;

            TryShow(m_dialogIndex);
        }

        private bool TryShow(int index)
        {
            if (index >= m_dialogData.dialogs.Count)
            { 
                return false;
            }

            var dialog = m_dialogData.dialogs[index];
            m_dialogPanel.SetText(dialog.title, dialog.text);

            return true;
        }
    }
}
