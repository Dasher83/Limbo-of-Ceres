using System;
using UnityEngine;

namespace LimboOfCeres.Scripts.AudioScripts
{
    [Serializable]
    public class Song : CustomAudioClip
    {
        [SerializeField]
        private SongsEnum _id;

        public SongsEnum Id => _id;
    }
}
