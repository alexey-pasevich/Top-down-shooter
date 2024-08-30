using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class Player 
    {
        public Settings settings { private set; get; } = new Settings();

        private int m_curTaskIndex;
        public event System.Action<int> changeTask;

        public int currentTask
        {
            set
            {
                if (m_curTaskIndex != value)
                { 
                    m_curTaskIndex = value;
                    changeTask?.Invoke(m_curTaskIndex);
                }
            }
            get => m_curTaskIndex;
        }

        private int m_money = 1000;
        public event System.Action<int> changeMoney;

        public int money
        {
            set
            {
                if (m_money != value)
                {
                    m_money = value;
                    changeMoney?.Invoke(m_money);
                }
            }
            get => m_money;
        }

        public List<string> inventuory = new List<string>();

        public void Save()
        { 
            var json = JsonUtility.ToJson(settings);
            PlayerPrefs.SetString("player.settings", json);

            json = JsonUtility.ToJson(new PlayerData()
            { 
                taskIndex = m_curTaskIndex,
                money = money,
            });
            PlayerPrefs.SetString("player.data", json);

        }

        public void Load()
        {
            var json = PlayerPrefs.GetString("player.settings");
            if (!string.IsNullOrEmpty(json))
            {
                settings = JsonUtility.FromJson<Settings>(json);
            }

            json = PlayerPrefs.GetString("player.data");
            if (!string.IsNullOrEmpty(json))
            {
                var playerData = JsonUtility.FromJson<PlayerData>(json);
                m_money = playerData.money;
            }
        }

        public class Settings
        {
            public int musicVolume = 80;
            public int fxVolume = 80;
            public int quality = 6;
        }

        [System.Serializable]
        private class PlayerData
        {
            public int taskIndex;
            public int money;
            public List<string> inventuory;
        }
    }
}
