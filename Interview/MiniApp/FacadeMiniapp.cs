using Interview.Core;
using Interview.Delegates;
using Interview.DesignPatterns.Facade;
using Interview.DesignPatterns.Facade.Interfaces;
using Interview.DesignPatterns.Facade.Manage;

namespace Interview.MiniApp
{
    public class FacadeMiniapp : IMiniApp
    {
        private readonly IEmailService emailService;
        private readonly IUserRepo userRepo;
        private readonly IUserValidator userValidator;
        private readonly UserFacade userFacade;

        public FacadeMiniapp()
        {
            emailService = new TestEmailService();
            userRepo = new TestUserRepo();
            userValidator = new TestUserValidator();
            userFacade = new UserFacade(emailService, userRepo, userValidator);
        }

        public string DisplayName()
        {
            return "Register User - MiniApp (Facade Pattern)";
        }

        public void Run()
        {
            var newUser = new Person() { Name = "Vic", Age = 11 };

            var isRegistered = userFacade.RegisterUser(newUser);

            if (isRegistered)
            {
                Console.WriteLine("User: {0} was registered", System.Text.Json.JsonSerializer.Serialize(newUser));
            }
            else
            {
                Console.WriteLine("Register user failed");
            }
        }
    }
}
