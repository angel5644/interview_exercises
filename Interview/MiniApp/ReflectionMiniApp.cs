using Interview.Core;
using Interview.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.MiniApp
{
    public class ReflectionMiniApp : IMiniApp
    {
        public string DisplayName()
        {
            return "Get private class data using reflection - MiniApp (Reflection)";
        }

        public void Run()
        {
            var test = new PrivatePlayer();

            var data = test.GetPrivateData();

            foreach (var item in data)
            {
                Console.WriteLine("Private  name: {0}", item.Key);
                Console.WriteLine("Property value: {0}", item.Value?.ToString());
            }
        }
    }
}
