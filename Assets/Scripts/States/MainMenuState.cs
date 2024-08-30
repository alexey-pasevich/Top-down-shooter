using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownShoot
{
    public class MainMenuState : GameState
    {
        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        }

        public void LoadLevel()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void GoToSettings()
        { 
            States.instance.Push<SettingsState>();
        }

        public void GoToShop()
        {
            States.instance.Push<ShopState>();
        }
    }
}
