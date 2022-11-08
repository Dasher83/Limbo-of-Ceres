using System;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.AudioScripts
{
    [Serializable]
    public class SoundEffect : CustomAudioClip
    {
        [SerializeField]
        private SoundEffectsEnum _id;

        public SoundEffectsEnum Id => _id;
    }
}
