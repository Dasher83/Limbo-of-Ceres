using System;
using UnityEngine;

namespace LimboOfCeres.Scripts.AudioScripts
{
    [Serializable]
    public class SoundEffect : CustomAudioClip
    {
        [SerializeField]
        private SoundEffectsEnum _id;

        public SoundEffectsEnum Id => _id;
    }
}
