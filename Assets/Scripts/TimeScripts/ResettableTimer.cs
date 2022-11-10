namespace QuarkAcademyJam1Team1.Scripts.TimeScripts
{
    public class ResettableTimer
    {
        private readonly float initialSettime;
        private float timeLeft;

        public ResettableTimer(float time)
        {
            initialSettime = time;
            timeLeft = time;
        }

        public float InitialSettime { get { return initialSettime; } }

        public void Countdown(float time)
        {
            timeLeft -= time;
        }

        public bool OutOfTime { get { return timeLeft < 0; } } 

        public void Reset()
        {
            timeLeft = initialSettime;
        }
    }
}
