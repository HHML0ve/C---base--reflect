using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace reflect1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "fun4";
            
            Entity entity = new Entity("hhm");
            Type type = entity.GetType();
            Object o = System.Activator.CreateInstance(type);
            foreach (MethodInfo m in type.GetMethods())
            {
                foreach (Attribute a in m.GetCustomAttributes(typeof(FildAttribute), false))
                {
                    FildAttribute fild = (FildAttribute)a;
                    if (null != fild)
                    {
                        //m所代表的是Entity的方法的返回值类型与名字，参数
                        //Console.WriteLine(m);
                        //fild.F_Name是attribute设置的名字，m.Name是函数的名字
                        // Console.WriteLine("fild.F_Name{0},Name{1}", fild.F_Name, m.Name);
                        // Console.WriteLine(fild.F_Style);
                        if(key.Equals(m.Name)){
                            Console.WriteLine("OK {0}",m);
                            //借助实例0运行。如果是静态方法可以改成null
                            m.Invoke(o,new object[]{"Tina"});
                        }
      
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
                Console.WriteLine( "message to" + _name);
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
