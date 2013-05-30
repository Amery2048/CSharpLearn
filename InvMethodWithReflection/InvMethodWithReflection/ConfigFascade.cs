using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace InvMethodWithReflection
{
    class ConfigFascade
    {
        [SettingAttribute(Discription="默认数据库连接字符串")]
        public string ConnectionString
        {
            set { Console.WriteLine("set ConnectionString method invoked,value: "+value); }
            get { return "get connectionString method invoked"; }
            //set { ConnectionString = value; }
            //get { return ConnectionString; }
        }
        [SettingAttribute(Discription="日志文件路径")]
        public string LogFilePath
        {
            set { Console.WriteLine("set LogFilePath method invoked,value: "+value); }
            get { return "get LogFilePath method invoked"; }
        }

        public string Get(String Name)
        {
            Type t=typeof(ConfigFascade);
            PropertyInfo propertyInfo = t.GetProperty(Name);
            if (propertyInfo != null)
            {
                MethodInfo getMethodInfo = t.GetProperty(Name).GetGetMethod();
                //setMethodInfo.Invoke(config, new object[] { "belial" });
                return (string)getMethodInfo.Invoke(this, null);
            }
            return null;
        }
        public void Set(String Name,String value)
        {
            Type t=typeof(ConfigFascade);
            PropertyInfo propertyInfo = t.GetProperty(Name);
            if (propertyInfo != null)
            {
                MethodInfo setMethodInfo = propertyInfo.GetSetMethod();
                setMethodInfo.Invoke(this, new object[] { value });
            }
            else throw new Exception("不存在配置项："+Name);
        }
        public static List<SettingAttribute> GetSettingAttributes()
        {
            List<SettingAttribute> attrs = new List<SettingAttribute>();
            Type t = typeof(ConfigFascade);
            PropertyInfo[] propertiesInfo = t.GetProperties();
            SettingAttribute attribute;
            foreach (PropertyInfo info in propertiesInfo)
            {
                attribute = info.GetCustomAttribute<SettingAttribute>(false);
                //保证得到正确的属性名字
                attribute.Name = info.Name;
                if (attribute != null) {
                    attrs.Add(attribute);
                }
            }
            return attrs;
        }
    }
}
