using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    /*
     * 本委托演示类主要用于学习委托的一些特点和定义 2017年10月14日21:15:43
     * 委托是一种类型，跟类一个级别。是用于定义对方法的引用，表示着某一类方法（返回类型，参数列表）
     * 在常见的泛型委托中，有三种：1.Predicate委托。 2.Action委托，有0带16个输入参数，无返回值。3.Func委托，有返回值，且可以有0到16个输入参数。
     * 使用到委托就不得不提到匿名方法，在.NET2.0之后，就可以使用匿名方法。
     * 那么在使用了匿名方法之后。这是出现了lambda表达式。
     */
    public class DelegateDemo
    {

        public void DemoDelegate()
        {
            //这里定义了一个委托变量，引用了 直接返回true 的方法。那么说S这个变量是对这个匿名方法的引用。
            TheFirstDelegate<int> s = new TheFirstDelegate<int>(k => { return true; });
            //这是.net定义的一个泛型委托，返回bool类型，只有一个类型参数。
            //这个委托定义的是对某个具体类型是否满足方法的条件，返回bool等一系列方法的抽象。
            Predicate<int> sa = new Predicate<int>(a => { return false; });
            List<int> arr = new List<int> {1,2,3,4,5,6,7 };
            //这里是使用传统的匿名方法，
            arr.ForEach(new Action<int>(delegate (int a) { Console.WriteLine(a); }));
            //这里是使用lambda表达式。=>是lambda运算符，由于a是输入参数，编译器可以自动推断出它是什么类型。
            //Console.WriteLine(a)是执行语句，如果有多条执行语句，就需要使用{}括起来。如果有返回值，则需要使用return
            arr.ForEach(new Action<int>(a => Console.WriteLine(a)));
          

        }
        public void DoSomeThing()
        {
            var arr = new List<int>() {1,2,3,4,5,6,7 };
            //这里创建MoreOrLessDelegate委托类型的实例，实际上是定义d1委托引用变量，指向RutrenTrue方法。
            var d1 = new MoreOrLessDelegate(this.RutrenTrue);
            //这里调用方法，把指向RutrenTrue方法引用的d1委托类型变量传入到该方法的委托参数中。
            //那么在实际的调用中也是调用RutrenTrue这个方法。
            Print(arr, d1);
            var d2 = new Predicate<string>(this.RutrenTrue);
            //.net定义的无返回值的泛型委托。是对无返回值的一类方法的引用。
            var d3 = new Action<int>(delegate (int a) { });
            //.net定义的有返回值的泛型委托。是对有返回值的一类方法的引用。
            var d4 = new Func<string, bool>(this.RutrenTrue);

            //定义匿名方法。
            //那么匿名方法的好处在意可读性强，不用跳转到具体的方法体看，因为定义时就已经定义了方法体。
            //还有一个好处就是，可以在这里访问到arr集合变量，但是如果定义传统的方法，然后在方法里引用arr集合
            //那么arr必须是类级别的私有变量才能访问的到，
            var d5 = new Predicate<int>(delegate (int item) 
            {
                //如果是在传统的定义中，那么arr集合必须是类级别的变量，才能访问的到。
                Console.WriteLine(arr.Count);
                return false;
            });

        }

        public bool RutrenTrue(string something)
        {
            return true;
        }
        /// <summary>
        /// 这个方法中需要一个委托参数，这个委托是一个对方法的引用，引用的方法必须是指定的返回值和参数列表。
        /// 相当于对指定返回值和参数列表的方法的抽象。
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="d"></param>
        static void Print(List<int> arr, MoreOrLessDelegate d)
        {
            foreach (var item in arr)
            {
                if(d(""))
                    Console.WriteLine(item);
            }
        }
    }


    /// <summary>
    /// 这里定义了一个泛型委托，委托是对方法的引用，跟类一个级别，就是一个类型。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pars"></param>
    /// <returns></returns>
    public delegate bool TheFirstDelegate<in T>(T pars);
    public delegate Boolean MoreOrLessDelegate(string paramter);
}
