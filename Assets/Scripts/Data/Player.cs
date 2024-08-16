using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class Player 
    {
        public Settings settings { private set; get; } = new Settings();


        public class Settings
        {
            public int musicVolume = 80;
            public int fxVolume = 80;
            public int quality = 6;
        }

        public void Save()
        { 
            var json = JsonUtility.ToJson(settings);
            PlayerPrefs.SetString("player.settings", json);
        }

        public void Load()
        {
            var json = PlayerPrefs.GetString("player.settings");
            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            settings = JsonUtility.FromJson<Settings>(json);
        }
    }
}
