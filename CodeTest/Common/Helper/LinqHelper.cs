using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    /*
     * 本帮助类主要用于学习linq 2017年10月13日23:30:57
     */
    public class LinqHelper
    {
        /// <summary>
        /// 传统定义字段与属性的对应关系。其实跟下面的自动属性是一样的作用。
        /// </summary>
        private int _firstFile;
        public int FirstFile
        {
            get { return this._firstFile; }
            set { this._firstFile = value; }
        }
        /// <summary>
        /// 自动属性。 其实在编译器编译代码的时候， 帮我们定义了私有字段，生成IL代码。就像上面的传统定义字段和属性的方式。
        /// </summary>
        public int Autopropertity { get; set; }

        public void DoSomeThing()
        {
            LinqHelper s = new LinqHelper() { FirstFile = 1 };//这里使用了C#3.0引入的对象初始化的功能。
            //首先来讲在定义隐式类型时，必须是定义和赋值同时进行，不然编译器无法在后面推断是什么类型。
            //var firstvalible; 这样定义是不合法的。
            var firstvalible = 1;
            firstvalible++;
            var secondValibel = "11";
            firstvalible = secondValibel.Length;
            var myobj = new object();
            myobj.GetType();
            //这样定义隐式类型不会降低性能。编译器根据变量的值，推到出变量的类型，才会产生IL代码。
            //创建一个对象，一定要先定义这个对象的类型吗，不一定。 这时候就要想到匿名类型。
            var obj = new { ID = Guid.NewGuid(), MyTitle = "匿名类型" };
            Console.WriteLine(obj.ID);
            Console.WriteLine(obj.MyTitle);
            Console.ReadKey();
            //这个匿名类型在网站开发中，序列化和反序列化json对象时很有用。
            
        }
    }
}
