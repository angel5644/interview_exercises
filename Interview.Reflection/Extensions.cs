
namespace Interview.Reflection
{
    public static class Extensions 
    {
        public static Dictionary<string, object> GetPrivateData(this PrivatePlayer test) 
        {
            var playerType = test.GetType();

            var fields = playerType.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var data = new Dictionary<string, object>();
            foreach ( var field in fields ) 
            {
                var value = field.GetValue(test);
                data.Add(field.Name, value);
            }

            return data;
        }
    }
}
