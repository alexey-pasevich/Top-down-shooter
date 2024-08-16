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

        protected override void OnEnable()
        {
            base.OnEnable();
            var settings = GameInstance.instance.player.settings;

            m_settingsPanel.SetMusic(settings.musicVolume);
            m_settingsPanel.SetFx(settings.fxVolume);
            m_settingsPanel.SetQuality(settings.quality);

            m_settingsPanel.onQualityChanged += onQualityChanged;
            m_settingsPanel.onMusicVolumeChanged += onMusicVolumeChanged;
            m_settingsPanel.onFxVolumeChanged += onFxVolumeChanged;
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

        protected override void OnDisable()
        {
            base.OnDisable();

            m_settingsPanel.onQualityChanged -= onQualityChanged;
            m_settingsPanel.onMusicVolumeChanged -= onMusicVolumeChanged;
            m_settingsPanel.onFxVolumeChanged -= onFxVolumeChanged;

            GameInstance.instance.ApplySettings();
        }

        public void Back()
        {
            States.instance.Pop();
        }
    }
}
