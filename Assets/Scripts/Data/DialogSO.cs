using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TopDownShoot
{
    [CreateAssetMenu(fileName = "DialogSO", menuName = "TopDownShoot/DialogSO")]
    public class DialogSO : ScriptableObject
    {
        [SerializeField] private List<DialogData> dialogs;

        public DialogData GetDialog(string id)
        {
            return dialogs.Find(dialog => dialog.id == id);
        }

        [ContextMenu("Save")]
        public void SaveToJson()
        {
            TempData data = new TempData()
            {
                dialogs = dialogs,
            };

            var json = JsonUtility.ToJson(data);
            File.WriteAllText(Path.Combine(Application.dataPath, "Scripts/json.json"), json);
        }

        [SerializeField]
        private class TempData
        { 
            public List<DialogData> dialogs;
        }
    }

    [System.Serializable]
    public class DialogData
    {

        [System.Serializable]
        public class Dialog
        {
            public string title;
            public string text;
        }

        public string id;
        public List<Dialog> dialogs;
    }
}
