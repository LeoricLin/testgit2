using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    /*
     * 本帮助类主要用于学习linq 2017年10月13日23:30:57
     * IEnumerable接口是LINQ特性的核心接口，只有实现了该接口的集合，才能执行LINQ操作。
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

        public void DoAgain()
        {
            //LINQ演示方法。
            List<int> arr = new List<int> {1,2,3,4,5,6,7,8,9 };
            var result = arr.Where(a => { return a > 3; }).Sum();
            Console.WriteLine(result);
            Console.ReadKey();
            //where扩展方法，需要传入一个func<int,bool>类型的泛型委托，
            //这个类型的委托需要出入参数和一个布尔类型的返回值。
            //直接使用lambda表达式定义方法。把大于3的集合筛选出来，然后进行汇总。
            //上面的代码也可以写成如下：
            var s = (from v in arr where v > 3 select v).Sum();
            Console.WriteLine(s);
            Console.ReadKey();
            //使用where进行过滤，使用select进行投影，将筛选出来的每个元素投影到一个新集合中，新集合是一个IEnumerable<T>
            //可以使用查询表达式。
            var s1 = (from v in arr where v > 3 select v).Sum() * 3;
            /*
             * from [type] id in source
　　　　　　[join [type] id in source on expr equals expr [into subGroup]]
　　　　　　[from [type] id in source | let id = expr | where condition]
　　　　　　[orderby ordering,ordering,ordering...]
　　　　　　select expr | group expr by key
　　　　　　[into id query]
             */
            //第一行：type是可选选，ID是集合中的一项，source是一个集合，如果集合中的类型与type执行的类型不同则导致强制类型转换。
            //第二行：一个查询表达式中可以有0个或多个join子句，这个里的source可以是一个全新集合，也可以是自己
            //expr是一个表达式，[into subGroup]subGroup是一个中间变量，它继承自IGrouping，代表一个分组。
            //可以通过这个变量得到这一组包含的对象个数，已经这一组对象的键。
            var result1 = from a in arr
                         join b in arr on a equals b into orders
                         select new { id = a, count = orders.Count() };
            //第三行：一个查询表达式中可以有1个或多个from子句，
            //一个查询表达式中可以有0个或多个let 子句。let子句可以创建一个临时变量。
            var result2 = from a in arr
                          let number = a % 2 == 0
                          where a > 2 && number
                          orderby a,a,a
                          select a;
            //这里使用let在每个元素添加一个字段，指示是否能被2整除。
            //然后把大于2并且能被2整除的元素投影到新的序列中。
            //第四行：一个查询表达式可以有0个或多个排序，每个排序方式以逗号隔开。
            //第五行：一个查询表达式必须以select或者group by结束。 SELECT后跟要检索的内容，group by 是对检索的内容进行分组。
            //第六行：最后一个into子句的作用是将前面的语句的结果作为后面语句操作的数据源。

        }
    }
}
