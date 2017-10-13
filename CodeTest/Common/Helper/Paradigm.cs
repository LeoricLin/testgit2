using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 本类主要是用于学习.NET2.0的特性：泛型。
 * 泛型的概念--“通过参数化类型来实现在同一份代码上操作多种数据类型。利用“参数化类型”将类型抽象化，从而实现灵活的复用”。
 * 如果在类上定义泛型参数，但是可能在类种其他方法成员并没有用到泛型参数T， 很明显只有需要泛化的方法才会用到泛型参数，那些没有用到泛型参数的方法没有必要使用到泛型参数的。，这是只要定义泛型方法即可，
 * 不需要在 类上定义泛型参数T。
 * 泛型方法和普通方法没多大区别，仅仅在方法名后面加了"<T>"，接着是括号里面的参数，后面是限定语句。
 */
namespace Common.Helper
{
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
    }
}
