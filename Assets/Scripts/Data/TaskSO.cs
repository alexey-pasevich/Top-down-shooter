using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    [CreateAssetMenu(fileName = "TaskSO", menuName = "TopDownShoot/TaskSO")]
    public class TaskSO : ScriptableObject
    {
        [SerializeField] private List<TaskData> m_tasks;

        public int IndexOf(string id) => m_tasks.FindIndex(x => x.id == id);

        public string GetTaskDescription(int index)
        {
            if (index >= 0 && index < m_tasks.Count)
            {
                return m_tasks[index].description;
            }

            return string.Empty;
        }

        [System.Serializable]
        private class TaskData
        {
            public string id;
            public string description;
        }
    }
}
