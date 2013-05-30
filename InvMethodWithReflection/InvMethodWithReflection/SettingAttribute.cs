using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMethodWithReflection
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    class SettingAttribute :Attribute
    {
        //在提取属性的时候赋值为属性名字
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //属性描述，用于UI显示
        private string discription;
        public string Discription
        {
            get { return discription; }
            set { discription = value; }
        }
    }
}
