using QuarkAcademyJam1Team1.Scripts.Shared;
using System.Collections;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.AudioScripts
{
    public class AudioPlayer : MonoBehaviour
    {
        public static AudioPlayer instance;
        
        private AudioSource audioSource;
        [SerializeField]
        private Song[] songs;
        [SerializeField]
        private SoundEffect[] soundEffects;

        public Song GetCustomSong(SongsEnum songId)
        {
            foreach (Song _song in songs)
            {
                if (_song.Id == songId)
                {
                    return _song;
                }
            }
            return null;
        }

        public SoundEffect GetCustomSoundEffect(SoundEffectsEnum soundEffectId)
        {
            foreach (SoundEffect _soundEffect in soundEffects)
            {
                if (_soundEffect.Id == soundEffectId)
                {
                    return _soundEffect;
                }
            }
            return null;
        }

        private void Start()
        {
            if (instance != null)
            {
                return;
            }
            else
            {
                instance = this;
            }
            audioSource = GetComponent<AudioSource>();
            PlaySong(SongsEnum.EXAMPLE_SONG_1);
        }

        IEnumerator PlayAudioCorutine(CustomAudioClip audio, float delay, bool loop = false)
        {
            yield return new WaitForSeconds(delay);
            if (loop)
            {
                audioSource.Stop();
                audioSource.clip = audio.Clip;
                audioSource.volume = audio.Volume;
                audioSource.loop = true;
                audioSource.Play();
            }
            else
            {
                audioSource.PlayOneShot(audio.Clip, audio.Volume);
            }
        }

        public void StopSong()
        {
            audioSource.Stop();
        }

        public void PlaySong(SongsEnum songId, float delay = Constants.AudioPlayer.InBetweenSongsPauseLength)
        {
            audioSource.Stop();
            Song song = GetCustomSong(songId);
            StartCoroutine(PlayAudioCorutine(song, delay, loop: true));
        }

        public void PlaySoundEffect(SoundEffectsEnum soundEffectId, float delay = 0f)
        {
            SoundEffect soundEffect = GetCustomSoundEffect(soundEffectId);
            StartCoroutine(PlayAudioCorutine(soundEffect, delay));
        }
    }
}
