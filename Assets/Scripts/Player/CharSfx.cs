using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    public class CharSfx : MonoBehaviour
    {
        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private List<AudioClip> m_stepAudioClips;
        [SerializeField] private AudioClip m_landAudioClips;


        public void OnFootstep()
        {
            if (m_AudioSource != null)
            {
                var index = Random.Range(0, m_stepAudioClips.Count);
                m_AudioSource.PlayOneShot(m_stepAudioClips[index]);
            }
        }
        public void OnLand()
        {
            m_AudioSource.PlayOneShot(m_landAudioClips);
        }

    }
}
