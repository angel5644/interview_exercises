using Interview.Delegates;
using Interview.DesignPatterns.Facade.Interfaces;

namespace Interview.DesignPatterns.Facade.Manage
{
    public class TestEmailService : IEmailService
    {
        public void SendEmail(Person user)
        {
            Console.WriteLine("Sending email to user: {0}", user.Name);
        }
    }
}
