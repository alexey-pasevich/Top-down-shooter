using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownShoot
{
    public class UISettingsPanel : MonoBehaviour
    {
        [SerializeField] private Slider m_musicVolume;
        [SerializeField] private Slider m_fxVolume;
        [SerializeField] private TMPro.TMP_Dropdown m_quality;

        public event System.Action<int> onQualityChanged;
        public event System.Action<int> onMusicVolumeChanged;
        public event System.Action<int> onFxVolumeChanged;

        private void Awake()
        {
            m_quality.ClearOptions();
            m_quality.AddOptions(new List<string>() { "Very Low", "Low", "Medium", "High", "Very High", "Ultra" });
        }

        private void Start()
        {
            m_quality.onValueChanged.AddListener(index => onQualityChanged?.Invoke(index));
            m_musicVolume.onValueChanged.AddListener(value => onMusicVolumeChanged?.Invoke(Mathf.RoundToInt(value * 100)));
            m_fxVolume.onValueChanged.AddListener(value => onFxVolumeChanged?.Invoke(Mathf.RoundToInt(value * 100)));
        }

        public void SetMusic(int volume)
        { 
            m_musicVolume.value = volume / 100f;
        }
        public void SetFx(int volume)
        {
            m_fxVolume.value = volume / 100f;
        }
        public void SetQuality(int index)
        {
            m_quality.value = index;
        }
    }
}
