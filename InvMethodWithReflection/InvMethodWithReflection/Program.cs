using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace InvMethodWithReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(ConfigFascade);
            ConfigFascade config = Activator.CreateInstance<ConfigFascade>();
            PropertyInfo[] propertiesInfo = t.GetProperties();

            List<SettingAttribute> attributes = new List<SettingAttribute>();
            SettingAttribute attribute;
            foreach (PropertyInfo info in propertiesInfo)
            {
                Console.WriteLine(info.ToString());

                attribute = info.GetCustomAttribute<SettingAttribute>(false);
                if (attribute != null) {
                    Console.WriteLine("\t Name:{0} Discription:{1}", info.Name, attribute.Discription);
                    attributes.Add(attribute);
                    MethodInfo getMethodInfo = t.GetProperty(info.Name).GetGetMethod();
                    MethodInfo setMethodInfo = t.GetProperty(info.Name).GetSetMethod();
                    string result=(string)getMethodInfo.Invoke(config,null);
                    Console.WriteLine("\t{0}",result);
                    setMethodInfo.Invoke(config,new object[]{"belial"});
                    Console.WriteLine("\n");
                }
            }
            DateTime start;
            DateTime end;
            TimeSpan span;
            int n = 1000;
            start = DateTime.Now;
            //性能测试
            //while (n > 0)
            //{
            //    config.ConnectionString = "hello";
            //    string a=config.ConnectionString;
            //    n--;
            //}
            //end = DateTime.Now;
            //span = new TimeSpan(end.Ticks - start.Ticks);
            //Console.WriteLine("total seconds: " + span.TotalSeconds);
            //n = 1000;
            //start = DateTime.Now;
            //attribute = attributes[1];
            //while (n > 0)
            //{
            //    config.GetSetting(attribute.Name);
            //    config.SetSetting(attribute.Name, "hello");
            //    n--;
            //}
            end = DateTime.Now;
            span = new TimeSpan(end.Ticks - start.Ticks);
            //Console.WriteLine("total seconds: " + span.TotalSeconds);
            //try
            //{
            //    config.SetSetting("ksd", "hello");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            Console.ReadLine();
        }
    }
}
