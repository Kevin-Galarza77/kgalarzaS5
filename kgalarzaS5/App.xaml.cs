namespace kgalarzaS5
{
    public partial class App : Application
    {
        public static Repositories.PersonRepository personRepository_ { get; set; }
        
        public App(Repositories.PersonRepository personRepository)
        {
            InitializeComponent();
            personRepository_ = personRepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vHome());
        }
    }
}