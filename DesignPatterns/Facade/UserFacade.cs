using Interview.Delegates;
using Interview.DesignPatterns.Facade.Interfaces;

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
}
