using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reflect1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Entity entity = new Entity("hhm");
            string key = "fun1";
            Type type = entity.GetType();
            //新建一个实例对象
            Object o = System.Activator.CreateInstance<Entity>();
            
            var infos = type.GetProperties();
            var mes = type.GetMethods();
            foreach(var info in infos){
                //获取Entity的属性值 类型，get与set方法的获取办法。此处是System.String OK_Name
                Console.WriteLine(info);
                //添加attribute后
                var arrs = info.GetCustomAttributes(typeof(FildAttribute),false);
                foreach(var arr in arrs){
                    string s = ((FildAttribute)arr).F_Name;
                    Console.WriteLine("参数名{0}",s);
                }
            }

            foreach(var me in mes){
                Console.WriteLine("method: {0}",me);
                var arrs = me.GetCustomAttributes(typeof(FildAttribute), false);
                foreach (var arr in arrs)
                {
                    string s = ((FildAttribute)arr).F_Name;
                    Console.WriteLine("参数名{0}", s);
                    if(s.Equals(key)){
                        me.Invoke(o,null);
                        
                    }
                }
            }
            Console.ReadKey();
        }
    }
    [Fild("My Entity","Class")]
    class Entity
    {
        [Fild("OK_name","propretie")]
        private string name;
        public string OK_Name
        {
            get{ return name;}
            set{this.name = value;}
        }
        public Entity(string name)
        {
            this.name = name;
        }
        public Entity()
        {
        }
        [Fild("fun1","function")]
        public void fun1() {
            Console.WriteLine("say hello to {0}",name);
        }
        [Fild("fun2", "function")]
        public int fun2() {
            return name.Length;
        }
        [Fild("fun3", "function")]
        public string fun3() {

            return name + "string";
        }
        [Fild("fun4", "function")]
        public void fun4(string _name) {
            Console.WriteLine(_name+"message to"+name);
        }
   
    }
    [AttributeUsage(AttributeTargets.All)]
    class FildAttribute : System.Attribute
    {
        private string _name;
        private string _type;
        public string F_Name{
            get{ return _name;}
            set{this._name = value;}
        }
        public string F_Style {
            get { return _type; }
            set { this._type = value; }
        }

        public FildAttribute(string _name,string _type)
        {
            this._name = _name;
            this._type = _type;
        }
    }

}
