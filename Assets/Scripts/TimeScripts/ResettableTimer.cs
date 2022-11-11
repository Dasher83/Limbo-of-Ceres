using UnityEngine;

namespace QuarkAcademyJam1Team1.Scripts.TimeScripts
{
    public class ResettableTimer
    {
        private float nextTimeToCountdown;
        private float timeLeft;

        public ResettableTimer(float time)
        {
            nextTimeToCountdown = time;
            timeLeft = time;
        }

        public float NextTimeToCountdown
        {
            get {
                return nextTimeToCountdown;
            }
            set {
                if(Mathf.Approximately(nextTimeToCountdown, 0))
                {
                    return;
                }
                if(nextTimeToCountdown < 0)
                {
                    nextTimeToCountdown = value * -1;
                    return;
                }
                nextTimeToCountdown = value;
            }
        }

        public void Countdown(float time)
        {
            timeLeft -= time;
        }

        public bool OutOfTime { get { return timeLeft < 0; } } 

        public void Reset(float time = 0f)
        {
            if(time != 0)
            {
                NextTimeToCountdown = time;
            }
            timeLeft = nextTimeToCountdown;
        }
    }
}
