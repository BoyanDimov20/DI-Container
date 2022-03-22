namespace ReflectionPlaying
{
    internal class IoCContainer
    {
        private readonly ICollection<object> instances = new HashSet<object>();
        private readonly Dictionary<Type, Instance> registeredServices = new Dictionary<Type, Instance>();


        public void AddSingleton<TInterface, TImplementation>() 
            where TImplementation : TInterface
        {
            RegisterService<TInterface, TImplementation>(Lifetime.Singleton);
            
            var instance = this.CreateInstance<TInterface>();
            this.instances.Add(instance);
        }

        public void AddTransient<TInterface, TImplementation>() 
            where TImplementation : TInterface
        {
            RegisterService<TInterface, TImplementation>(Lifetime.Transient);
        }

        public TInterface GetService<TInterface>()
        {
            var type = this.registeredServices[typeof(TInterface)];

            if (type == null)
                throw new ArgumentNullException("Not registered service");

            if (type.Lifetime == Lifetime.Singleton)
                return (TInterface)this.instances.FirstOrDefault(x => x.GetType() == type.Implementation);

            return this.CreateInstance<TInterface>();
        }

        public object GetService(Type interfaceType)
        {
            var type = this.registeredServices[interfaceType].Implementation;

            if (type == null)
                throw new ArgumentNullException("Not registered service");

            var instance = this.instances.FirstOrDefault(x => x.GetType() == type);

            return instance;
        }

        private TInterface CreateInstance<TInterface>()
        {
            var type = registeredServices[typeof(TInterface)].Implementation;

            if (type == null)
                throw new ArgumentNullException("Not registered service");

            var defaultConstructor = type.GetConstructors()[0];
            var defaultParameters = defaultConstructor.GetParameters();

            var parameters = defaultParameters.Select(p => GetService(p.ParameterType)).ToArray();

            return (TInterface)defaultConstructor.Invoke(parameters);
        }

        private void RegisterService<TInterface, TImplementation>(Lifetime lifetime)
        {
            this.registeredServices.Add(typeof(TInterface), new Instance
            {
                Lifetime = lifetime,
                Implementation = typeof(TImplementation)
            });
        }
    }
}
