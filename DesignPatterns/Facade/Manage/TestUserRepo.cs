using Interview.Delegates;
using Interview.DesignPatterns.Facade.Interfaces;

namespace Interview.DesignPatterns.Facade.Manage
{
    public class TestUserRepo : IUserRepo
    {
        public void AddUser(Person user)
        {
            Console.WriteLine("Inserting to the database, user: {0}", user.Name);
        }
    }
}
