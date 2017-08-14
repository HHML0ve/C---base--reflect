using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace reflect1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Reflection.MemberInfo info = typeof(Entity);
            //显示附加到类 Entity 上的自定义特性
            object[] objs = info.GetCustomAttributes(true);
            foreach(var obj in objs){
                Console.WriteLine(obj);
            }
            Entity entity = new Entity("hhm");
            Type type = entity.GetType();
            foreach (MethodInfo m in type.GetMethods())
            {
                foreach(Attribute a in m.GetCustomAttributes(typeof(FildAttribute),false)){
                    FildAttribute fild = (FildAttribute)a;
                    if(null!=fild){
                        //fild.F_Name是attribute设置的名字，m.Name是函数的名字
                        Console.WriteLine("fild.F_Name{0},Name{1}",fild.F_Name,m.Name);
                        Console.WriteLine(fild.F_Style);
                    }
                }
            
            }
            Console.ReadKey();
        }
        [Fild("My Entity", "Class")]
        class Entity
        {
            [Fild("OK_name", "propretie")]
            private string name;
            public string OK_Name
            {
                get { return name; }
                set { this.name = value; }
            }
            public Entity(string name)
            {
                this.name = name;
            }
            public Entity()
            {
            }
            [Fild("funA", "function")]
            public void fun1()
            {
                Console.WriteLine("say hello to {0}", name);
            }
            [Fild("funB", "function")]
            public int fun2()
            {
                return name.Length;
            }
            [Fild("funC", "function")]
            public string fun3()
            {

                return name + "string";
            }
            [Fild("funD", "function")]
            public void fun4(string _name)
            {
                Console.WriteLine(_name + "message to" + name);
            }

        }
       // [AttributeUsage(AttributeTargets.All)]
        [AttributeUsage(AttributeTargets.Class |
   AttributeTargets.Constructor |
   AttributeTargets.Field |
   AttributeTargets.Method |
   AttributeTargets.Property,
   AllowMultiple = true)]
        class FildAttribute : System.Attribute
        {
            private string _name;
            private string _type;
            public string F_Name
            {
                get { return _name; }
                set { this._name = value; }
            }
            public string F_Style
            {
                get { return _type; }
                set { this._type = value; }
            }

            public FildAttribute(string _name, string _type)
            {
                this._name = _name;
                this._type = _type;
            }
        }
    }
}
