using System;
using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.AudioScripts
{
    [Serializable]
    public class Song : CustomAudioClip
    {
        [SerializeField]
        private SongsEnum _id;

        public SongsEnum Id => _id;
    }
}
