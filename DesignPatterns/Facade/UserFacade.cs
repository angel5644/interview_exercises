using Interview.Delegates;

namespace Interview.DesignPatterns.Facade
{
    /// <summary>
    /// The Facade Design Pattern provides a unified interface to a set of interfaces in a subsystem. 
    /// It simplifies the usage of complex underlying operations by presenting a clear and minimized interface to external clients. 
    /// Just like the face of a building hides its internal complexities, the facade hides the intricacies of the subsystems.
    /// Benefits:
    /// - Simplifies client code by providing a high-level interface.
    /// - Encapsulates subsystem complexities.
    /// - Promotes maintainability and readability.
    /// </summary>
    public class UserFacade
    {
        private readonly IEmailService emailService;
        private readonly IUserRepo userRepo;
        private readonly IUserValidator userValidator;

        public UserFacade(IEmailService emailService, IUserRepo userRepo, IUserValidator userValidator)
        {
            this.emailService = emailService;
            this.userRepo = userRepo;
            this.userValidator = userValidator;
        }

        public bool RegisterUser(Person user)
        {
            // Validate user
            if (!userValidator.Validate(user))
            {
                return false;
            }

            // Add person to the repo
            userRepo.AddUser(user);

            // Send email
            emailService.SendEmail(user);

            return true;
        }
    }

    // Kept the rest of the interfaces and classes in here for simplicity
    public interface IEmailService
    {
        void SendEmail(Person user);
    }
    public interface IUserRepo
    {
        void AddUser(Person user);
    }
    public interface IUserValidator
    {
        bool Validate(Person user);
    }

    public class TestEmailService : IEmailService
    {
        public void SendEmail(Person user)
        {
            Console.WriteLine("Sending email to user: {0}", user.Name);
        }
    }

    public class TestUserRepo : IUserRepo
    {
        public void AddUser(Person user)
        {
            Console.WriteLine("Inserting to the database, user: {0}", user.Name);
        }
    }

    public class TestUserValidator : IUserValidator
    {
        public bool Validate(Person user)
        {
            Console.WriteLine("Validating user: {0}", user.Name);

            return true;
        }
    }
}
