namespace Generators.Timing
{
    public class TimingAsteroidGenerator : TimingObjectGenerator<Asteroid>
    {
        public TimingAsteroidGenerator(PoolObjectGenerator<Asteroid> generator, float timing, int countPerTime) : base(generator, timing, countPerTime)
        {
        }     
    }
}
