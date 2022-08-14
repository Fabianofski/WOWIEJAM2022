using System;
using System.Collections;
using System.Collections.Generic;
using F4B1.Audio;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Audio;

namespace F4B1.UI
{
    public class AudioSlider : MonoBehaviour
    {

        [SerializeField] private AudioMixer mixer;
        [SerializeField] private float soundCooldown = .3f;
        [SerializeField] private SoundEvent playSoundEvent;
        [SerializeField] private Sound valueChangedSound;
        private bool _soundAlreadyPlayed;

        public void SetMixerVolume(float volume)
        {
            PlayerPrefs.SetFloat(mixer.name, volume);
            PlayerPrefs.Save();
            
            volume = Mathf.Log(volume) * 20;
            mixer.SetFloat("volume", volume);

            if (_soundAlreadyPlayed || !valueChangedSound) return;
            
            playSoundEvent.Raise(valueChangedSound);
            _soundAlreadyPlayed = true;
            Invoke(nameof(ResetSoundCooldown), soundCooldown);
        }

        private void ResetSoundCooldown()
        {
            _soundAlreadyPlayed = false;
        }
        
    }
}
