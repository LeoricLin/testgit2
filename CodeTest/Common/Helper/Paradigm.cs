using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 本类主要是用于学习.NET2.0的特性：泛型。三大好处：类型安全，增强性能，代码复用。
 * 泛型的概念--“通过参数化类型来实现在同一份代码上操作多种数据类型。利用“参数化类型”将类型抽象化，从而实现灵活的复用”。
 * 泛型约束分为三种：接口约束：泛型实参必须实现某个接口，接口约束可以有多个，基类型约束：泛型实参必须是某个派生类，注意：可以指定T：Class/T：strut ，此时T分别只能为引用类型或者值类型，基类型约束必须放在其他约束之前
 * 构造函数new（）约束：泛型实参必须具有可访问的五参数构造函数，new（）约束出现在where子句的最后。
 * 如果在类上定义泛型参数，但是可能在类种其他方法成员并没有用到泛型参数T， 很明显只有需要泛化的方法才会用到泛型参数，那些没有用到泛型参数的方法没有必要使用到泛型参数的。，这是只要定义泛型方法即可，
 * 不需要在 类上定义泛型参数T。
 * 泛型方法和普通方法没多大区别，仅仅在方法名后面加了"<T>"，接着是括号里面的参数，后面是限定语句。
 * 1.泛型集合是类型安全集合。使用泛型集合避免装箱和拆箱， 提供了更好的性能。
 * 2.为泛型类型变量设置默认值时常使用default关键字进行，如果T为引用类型，则为null，如果是值类型就是0。
 * 由子类向父类方向转换是协变，协变用于返回值类型用out关键字，只用于返回不做修改。
 * 由父类向子类方向转换是逆变，逆变用于方法的参数类型用in关键字，只用于转换不做返回。
 * in 和out关键字用于逆变和协变时，目前只能用于泛型接口和泛型委托中。
 */
namespace Common.Helper
{
    /// <summary>
    /// 定义协变的泛型委托，类型参数只用于返回。委托是一种类型，跟类一个级别。是用于定义对方法的引用
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public delegate T GetSome<out T>();
    public delegate string GetOne<in T>();
    public class Paradigm
    {
       
        /// <summary>
        /// 首先这里有一个给整型数组进行冒泡排序的方法，
        /// 那么在后面的发展中，有需要对另一种类型的数组进行冒泡排序，规则跟下面的方法一样。只是数据类型不一致。
        /// 那么这时候可以使用到泛型方法，把类型参数化。把方法的签名抽象出来，（方法的前面主要是方法名和参数列表）
        /// </summary>
        /// <param name="arr"></param>
        public void BubbleSort(int[] arr)
        {
            //这里gog当做animal去返回，发生了协变 子类向父类转换。
            GetSome<Gog> SS = new GetSome<Gog>(() => { return new Gog(); });
            GetSome<Animal> gog = SS;

            //这里的类型参数只用于输入，发生逆变， 父类向子类转换。
            GetOne<Animal> s1 = new GetOne<Animal>(() => { return ""; });
            GetOne<Gog> s2 = s1;

            string s = "";
            int length = arr.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public void BubbleSort<T>(T[] arr) where T : IComparable //定义泛型类， 这里“where T:IComparable” 是给类型参数T一个限制 -- 参数类型必须实现IComparable接口，否则无法通过编译
        {
            int length = arr.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }


        
        public void GetSomeThing(  Gog a)
        {
            Console.WriteLine("逆变");
        }
        

    }

    public class Animal
    {

    }
    public class Gog:Animal
    {

    }
}
