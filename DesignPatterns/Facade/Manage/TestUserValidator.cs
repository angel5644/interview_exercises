using Interview.Delegates;
using Interview.DesignPatterns.Facade.Interfaces;

namespace Interview.DesignPatterns.Facade.Manage
{
    public class TestUserValidator : IUserValidator
    {
        public bool Validate(Person user)
        {
            Console.WriteLine("Validating user: {0}", user.Name);

            return true;
        }
    }
}
