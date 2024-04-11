
namespace Interview.Problems
{
    public class ProblemSandwiches
    {
        public int CountStudents(int[] students, int[] sandwiches) 
        {
            // We need to rever the sandwiches so when its taken from the stack, the right order is picked
            var stackSandwiches = new Stack<int>(sandwiches.Reverse());

            var queueStudents = new Queue<int>(students);

            var conditionMet = false;
            var studentsChecked = 0;

            while(conditionMet == false)
            {
                var currentStudent = queueStudents.Dequeue();
                var topSandwich = stackSandwiches.Peek();

                // Check if the student prefers the sandwich
                if (currentStudent == topSandwich)
                {
                    // If the student prefers the sandwich, sandwich is taken from the stack
                    stackSandwiches.Pop();
                    studentsChecked = 0;
                }
                else
                {
                    // Othersiwe, the student is added to the end of the queue, the sandwich remains in stack
                    queueStudents.Enqueue(currentStudent);
                    studentsChecked++;
                }

                var noStudentWantTopSandwich = studentsChecked == queueStudents.Count;

                // If all the remaining students did not like the top sandwich or no more students, exit
                conditionMet = noStudentWantTopSandwich || queueStudents.Count == 0;
            }

            return queueStudents.Count;
        }
    }
}
