using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helper;
using Common.Model;
using System.Collections;

namespace CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "我现在要提交代码到我的github版本库中。";
            //string s1 = "我又来提交测试了。aaaaaa";
            //string s2 = "不在宿舍里做的修改。sss ";
            //Console.WriteLine("hello world.");
            //Console.ReadKey();

            Paradigm demo = new Paradigm();
            int[] arr = new int[] { 1, 5, 6, 7, 9, 2, 4 };
            demo.BubbleSort<int>(arr);
            string str = string.Empty;
            for (int i = 0; i < arr.Length; i++)
                str += arr[i] + ",";
            Console.WriteLine("Current array value is {0}", str.Trim(','));
            Paradigm demomoive = new Paradigm();
            Moive[] moiveArr = new Moive[] 
            {
                new Moive ("少林寺",4M),
                new Moive ("华城",4M),
                new Moive ("上海滩",5M),
            };
            demomoive.BubbleSort<Moive>(moiveArr);

            Console.ReadKey();
        }
        static void Main1( string [] args)
        {
            //通常情况下如果不使用泛型集合类， 那么在往非泛型集合类中添加元素时，会将元素装箱，后面再从集合里去取元素时，又会进行拆箱的操作
            ArrayList list = new ArrayList();
            int listSize = 1000000;
            long startTime = DateTime.Now.Ticks;
            for (int i = 0; i < listSize; i++)
                list.Add(i);
            int value;
            for (int i = 0; i < listSize; i++)
                value = (int)list[i];
            long endTime = DateTime.Now.Ticks;
            Console.WriteLine("使用arraylist，耗时：{0}Ticks", endTime - startTime);
            List<int> s = new List<int>();
            long paraditStartTime = DateTime.Now.Ticks;
            for (int i = 0; i < listSize; i++)
                s.Add(i);
            for (int i = 0; i < listSize; i++)
                value = s[i];
            long paraditEndTime = DateTime.Now.Ticks;
            Console.WriteLine("使用泛型结合，耗时：{0}Ticks", paraditEndTime - paraditStartTime);
            Console.ReadKey();
            //经过测试，泛型集合比普通集合的执行速度快了2倍。
        }
    }
}
