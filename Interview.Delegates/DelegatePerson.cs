
namespace Interview.Delegates
{
    public static class DelegatePerson
    {
        public delegate Person[] OrderPersonsDelegate(Person[] person);

        static Person[] OrderByAgeAscending(Person[] persons)
        {
            return persons.OrderBy(a => a.Age).ToArray();
        }

        public static Person[] OrderPersons(Person[] persons, OrderPersonsDelegate orderPersonsDelegate)
        {
            var personsRes = orderPersonsDelegate?.Invoke(persons);

            return personsRes?.ToArray() ?? new Person[] { };
        }
    }
}
