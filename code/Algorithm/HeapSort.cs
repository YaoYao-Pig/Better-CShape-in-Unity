using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better
{
    public partial class Algorithm
    {
        public static List<T> HeapSort<T>(List<T> list,Functor.Comparetor<T> comparetor)
        {
            Container.Priority_Queue<T> priority_Queue = new Container.Priority_Queue<T>(comparetor);
            priority_Queue.InserArray(list);

            List<T> result=new List<T>();
            while (!priority_Queue.IsEmpty())
            {
                result.Add(priority_Queue.Pop());
            }
            return result;
        }
    }
}
