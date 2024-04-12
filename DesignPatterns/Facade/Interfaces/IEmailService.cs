using Interview.Delegates;

namespace Interview.DesignPatterns.Facade.Interfaces
{
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
}
