using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class SettingsState : GameState
    {
        [SerializeField] private UISettingsPanel m_settingsPanel;

        private Player.Settings settings => GameInstance.instance.player.settings;

        private void OnEnable()
        {
        
            var settings = GameInstance.instance.player.settings;

            m_settingsPanel.SetMusic(settings.musicVolume);
            m_settingsPanel.SetFx(settings.fxVolume);
            m_settingsPanel.SetQuality(settings.quality);

            m_settingsPanel.onQualityChanged += onQualityChanged;
            m_settingsPanel.onMusicVolumeChanged += onMusicVolumeChanged;
            m_settingsPanel.onFxVolumeChanged += onFxVolumeChanged;
            m_settingsPanel.onTryBack += OnTryBack;
        }

        public void OnTryBack()
        {

            States.instance.Pop();
        }

        private void onFxVolumeChanged(int obj)
        {
            settings.fxVolume = obj;
        }

        private void onMusicVolumeChanged(int obj)
        {
            settings.musicVolume = obj;
        }

        private void onQualityChanged(int index)
        {
            settings.quality = index;
        }

        private void OnDisable()
        {
          

            m_settingsPanel.onQualityChanged -= onQualityChanged;
            m_settingsPanel.onMusicVolumeChanged -= onMusicVolumeChanged;
            m_settingsPanel.onFxVolumeChanged -= onFxVolumeChanged;
            m_settingsPanel.onTryBack -= OnTryBack;

            GameInstance.instance.ApplySettings();
        }
    }
}
