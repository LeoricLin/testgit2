using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Moive:IComparable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(object obj)
        {
            //compareto方法是比较两个操作时的大小， 当前面一个操作数和第二个操作一样大时，返回0，如果第一个比第二个小返回-1，如果第一个比第二个大返回1
            return this.Price.CompareTo(((Moive)obj).Price);
        }
        public Moive(string name,decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
