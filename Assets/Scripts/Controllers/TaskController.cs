using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class TasksController : MonoBehaviour
    {
        [SerializeField] private TaskSO m_tasks;
        [SerializeField] private UITaskPanel m_tasksPanel;

        private Player m_player;
        private TriggerDetector m_triggerDetector;

        public void Init(Character character, Player player)
        {
            character.TryGetComponent(out m_triggerDetector);
            m_player = player;
        }

        private void OnEnable()
        {
            if (m_triggerDetector)
            {
                m_triggerDetector.onTriggerEnter += OnTriggerEnter;
            }

            if (m_player != null)
            {
                m_player.changeTask += RefreshTaskUI;
                RefreshTaskUI(m_player.currentTask);
            }
        }

        private void OnDisable()
        {
            if (m_triggerDetector)
            {
                m_triggerDetector.onTriggerEnter -= OnTriggerEnter;
            }

            if (m_player != null)
            {
                m_player.changeTask -= RefreshTaskUI;
            }
        }

        private void RefreshTaskUI(int taskIndex)
        {
            var taskDesc = m_tasks.GetTaskDescription(taskIndex);
            m_tasksPanel.SetTask(taskDesc);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent<TaskComponent>(out var task))
            {
                int index = m_tasks.IndexOf(task.id);
                if (index == m_player.currentTask)
                {
                    States.instance.Push<DialogState>().ShowDialog(task.id);
                    m_player.currentTask++;
                }
            }
        }
    }

}
