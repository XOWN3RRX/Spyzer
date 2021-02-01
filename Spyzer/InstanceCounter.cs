namespace Spyzer
{
    public class InstanceCounter
    {
        public static InstanceCounter _instance;
        private static object locker = new object();

        private int _instances = 0;

        public static InstanceCounter Instance
        {
            get
            {
                lock (locker)
                {
                    if (_instance == null)
                    {
                        _instance = new InstanceCounter();
                    }

                    return _instance;
                }
            }
        }

        public int Instances
        {
            get
            {
                lock(locker)
                {
                    return _instances;
                }
            }
        }

        private InstanceCounter() { }

        public void Increment()
        {
            lock (locker)
            {
                _instances++;
            }
        }

        public void Decrement()
        {
            lock (locker)
            {
                _instances--;
            }
        }
    }
}
