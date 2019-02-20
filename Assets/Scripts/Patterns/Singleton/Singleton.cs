namespace Patterns
{
    public class Singleton<T> where T : class, new()
    {
        //a protected constructor
        protected Singleton()
        {
        }

        //public getter
        public static T Instance { get; private set; } = CreateInstance();

        private static T CreateInstance()
        {
            if (Instance == null)
                Instance = new T();

            return Instance;
        }

        //Setter used to inject an instance 
        public void InjectInstance(T _instance)
        {
            if (_instance != null)
                Instance = _instance;
        }
    }
}