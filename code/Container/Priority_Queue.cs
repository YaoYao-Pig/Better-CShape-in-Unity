using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better
{

    namespace Container 
    {
        public class Priority_Queue<T>
        {
            private readonly int INITE_MAX_SIZE = 2;

            private int count;
            public int Count { get=>count; private set { count = value; } }
            private int capacity;
            public int Capacity { get=>capacity; private set { capacity = value; } }

            private Functor.Comparetor<T> comparetor;

            /// <summary>
            /// for node index i,the left child node is 2*i+1,and the right child node is 2*i+2
            /// </summary>
            private T[] data;
            
            public Priority_Queue()
            {
                Capacity = INITE_MAX_SIZE;
                data = new T[INITE_MAX_SIZE];
                Count = 0;
            }

            public Priority_Queue(Functor.Comparetor<T> comparetor):this()
            {
                this.comparetor = comparetor;
            }

            private void ReSize()
            {
                if (count >= capacity)
                {
                    T[] newData =new T[capacity * 2];
                    for(int i = 0; i < data.Length; ++i)
                    {
                        newData[i] = data[i];
                    }
                    data = newData;
                    capacity = 2 * capacity;
                }
            }

            public void Insert(T value)
            {
                if (Count >= Capacity)
                {
                    ReSize();
                }
                _Insert(value);
            }

            private void _Insert(T value)
            {
                data[count] = value;
                count++;
                Float(count - 1);
            }

            public bool IsEmpty()
            {
                return count==0?true:false;
            }
            public T Top()
            {
                if (count == 0) throw new Exception("Priority_Queue is empty");
                return data[0];
            }

            public T Pop()
            {
                T result=Top();
                data[0] = data[count - 1];
                count--;
                Down(0);
                return result;
            }

            private void Float(int index)
            {
                if (index == 0) return;
                GetFather(index, out int fatherIndex);
                if (comparetor(data[index], data[fatherIndex]))
                {
                    SwapNode(index, fatherIndex);
                    index = fatherIndex;
                    Float(index);
                }
                return;

            }
            private void Down(int index)
            {
                Utils.Value<T> leftChild = GetLeftChild(index,out int leftChildIndex);
                Utils.Value<T> rightChild = GetRightChild(index, out int rightChildIndex);
                if (leftChild.isNull && rightChild.isNull)
                {
                    return;
                }
                if (!leftChild.isNull && !rightChild.isNull)
                {
                    int targetIndex;
                    T targetNode;
                    if (comparetor(leftChild.value, rightChild.value))
                    {
                        targetIndex = leftChildIndex;
                        targetNode = leftChild.value;
                    }
                    else {
                        targetIndex = rightChildIndex;
                        targetNode = rightChild.value;
                    }
                    if (!comparetor(data[index], data[targetIndex]))
                    {
                        SwapNode(index, targetIndex);
                        index = targetIndex;
                        Down(index);
                    }

                }
                else if (leftChild.isNull && !rightChild.isNull && !comparetor(data[index], rightChild.value))
                {
                    SwapNode(index, rightChildIndex);
                    index = rightChildIndex;
                    Down(index);
                }
                else if (rightChild.isNull && !leftChild.isNull && !comparetor(data[index], leftChild.value))
                {
                    SwapNode(index, leftChildIndex);
                    index = leftChildIndex;
                    Down(index);
                }
            }

            private Utils.Value<T> GetFather(int child)
            {
                if (child == 0) return new Utils.Value<T>();
                else
                {
                    return new Utils.Value<T>(data[(child - 1) / 2]);
                }
            }

            private Utils.Value<T> GetFather(int child,out int fatherIndex)
            {
                fatherIndex = (child - 1) / 2;
                return GetFather(child);
            }

            private Utils.Value<T> GetLeftChild(int parent,out int index)
            {
                index= 2 * parent + 1;
                return GetLeftChild(parent);
            }
            private Utils.Value<T> GetLeftChild(int parent)
            {
                int testChildIndex = 2 * parent + 1;
                if (testChildIndex < count) return new Utils.Value<T>(data[testChildIndex]);
                return new Utils.Value<T>();
            }

            private Utils.Value<T> GetRightChild(int parent, out int index)
            {
                index = 2 * parent + 2;
                return GetRightChild(parent);
            }

            private Utils.Value<T> GetRightChild(int parent)
            {
                int testChildIndex = 2 * parent + 2;
                if (testChildIndex < count) return new Utils.Value<T>(data[testChildIndex]);
                return new Utils.Value<T>();
            }
            private void SwapNode(int index1,int index2)
            {
                T tmp = data[index1];
                data[index1] = data[index2];
                data[index2] = tmp;
            }
            public void InserArray(List<T> list)
            {
                foreach(T t in list)
                {
                    Insert(t);
                }
            }
        }
    }
}
