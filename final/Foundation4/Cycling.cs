public class Cycling : Activity
{
    private double speed;

    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
        {
            this.speed = speed;
        }

        public override double GetDistance() => (speed * Minutes) / 60;

        public override double GetSpeed() => speed;
        public override double GetPace() => 60 / speed;
}