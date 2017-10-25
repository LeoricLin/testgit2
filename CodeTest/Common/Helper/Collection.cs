using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Common.Helper
{
    /*
    * 本演示类主要用于演示集合类型的各类特点和方法。 2017年10月18日22:42:45
    */
    public class Collection
    {

        public void DoSomeThing()
        {
            List<int> arr = new List<int>();
            //设置集合元素总数，如果元素添加后个数超过设置的总数，这个容积总是会成2倍的方式增长。
            arr.Capacity = 20;
            //插入集合，显式的指定插入元素的位置。
            arr.Insert(1, 2);
            //插入集合，显式自定插入集合的位置。
            arr.InsertRange(4, new int[] {1,2,3,4 });
            //实现了IList和IList<T>接口的所有类型都提供了一个索引器，所以可以索引来访问集合中的有元素。
            //实现了ICollection接口的所有类型都有个count属性来访问集合中元素的个数。
            //所有实现了IEnumerable接口的类型，都可以进行遍历。
            arr.Remove(1);//移除指定元素
            arr.RemoveAt(0);//移除指定位置的元素。
            arr.Exists(s => s > 2);
            arr.AsReadOnly();//返回一个只读集合。

            //定义一个队列，队列支持先进先出的原则。
            Queue<int> que1 = new Queue<int>();
            que1.Count();//返回队列里的有元素个数，
            que1.Enqueue(1);//将一个元素添加到队列的尾部。
            que1.Dequeue();//返回队列中头部的元素，并移除它。
            que1.Peek();//返回队列中头部元素，但不会移除它。

            //与队列相反的是栈  后进先出
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);//将元素添加到栈的尾部。
            stack1.Pop();//从栈的尾部获取最近添加的元素，并从栈中移除。

            

        }
    }
}
