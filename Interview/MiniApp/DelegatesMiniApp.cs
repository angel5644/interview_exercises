using Interview.Core;
using Interview.Delegates;
using System.Text.Json;

namespace Interview.MiniApp
{
    public class DelegatesMiniApp : IMiniApp
    {
        public string DisplayName()
        { 
            return "Order Persons - Miniapp (Delegates)";
        }

        void IMiniApp.Run()
        {
            var persons = new Person[]
            {
                new Person { Name = "Alice", Age = 11 },
                new Person { Name = "Jane", Age = 10}
            };

            Console.WriteLine("Ordering persons by age ascending");

            var orderedPersons = DelegatePerson.OrderPersons(persons, (ps) => ps.OrderBy(_ => _.Age).ToArray());

            foreach (var person in orderedPersons)
            {
                Console.WriteLine("Person:" + JsonSerializer.Serialize(person));
            }
        }
    }
}
