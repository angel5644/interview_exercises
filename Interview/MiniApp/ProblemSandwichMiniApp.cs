using Interview.Core;
using Interview.Problems;

namespace Interview.MiniApp
{
    public class ProblemSandwichMiniApp : IMiniApp
    {
        public string DisplayName()
        {
            return "No. of students unable to eat - MiniApp";
        }

        void IMiniApp.Run()
        {
            var problemSandwiches = new ProblemSandwiches();

            var students = new int[] { 0, 0, 1 };
            var sandwiches = new int[] { 1, 0, 0 };

            var noStudents = problemSandwiches.CountStudents(students, sandwiches);

            Console.WriteLine("Students: {0}", System.Text.Json.JsonSerializer.Serialize(students));
            Console.WriteLine("Sandwiches: {0}", System.Text.Json.JsonSerializer.Serialize(sandwiches));
            Console.WriteLine("No. students unable to eat: {0}", noStudents);
        }
    }
}
