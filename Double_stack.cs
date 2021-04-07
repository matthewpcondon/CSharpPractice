
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
static void Main()
{ // 

            DoubleStack ds = new DoubleStack(5);
            ds.push1(1);
            ds.push1(2);
            ds.push1(3);
            ds.push1(4);
            ds.push1(5);
            ds.push2(6);
            ds.push2(7);
            ds.push2(8);
            ds.push2(9);
            ds.push2(0);
    
            Console.WriteLine(ds.pop1()); // should give 5
            Console.WriteLine(ds.pop2()); // 0
            Console.WriteLine(ds.pop1()); // 4
            Console.WriteLine(ds.pop2()); // 9
            Console.WriteLine(ds.pop1()); // 3
            Console.WriteLine(ds.pop2()); // 8
            Console.WriteLine(ds.pop1()); // 2
            Console.WriteLine(ds.pop2()); // 7
            Console.WriteLine(ds.pop1()); // 1
            Console.WriteLine(ds.pop2()); // 6
}
    class DoubleStack
{
        // implement double stack using single array
        // odd-numbered indices have the first stack's elements,
        // even-numbered indices have second-stack's elements
        private int[] arr;
        private int secondSize;
        private int firstSize;
        public DoubleStack(int stackMax)
        {
            arr = new int[2 * stackMax ];
            firstSize = -1;
            secondSize = -2;
        }
        public void push1(int newInt)
        {
            if (firstSize < arr.Length - 1)
            {
                firstSize += 2;
                arr[firstSize] = newInt;
            }
            else
            {
                throw new RaymondSaidSoException("Stack overflow");
            }
        }
        public void push2(int newInt)
        {
            if (secondSize < arr.Length - 2)
            {
                secondSize += 2;
                arr[secondSize] = newInt;
            }
            else
            {
                throw new RaymondSaidSoException("stack overflow");
            }
        }
        public int pop1()
        {
            if (firstSize >= 1)
            {
                int answer = arr[firstSize];
                firstSize -= 2;
                return answer;
            }
            else
            {
                throw new RaymondSaidSoException("stack overflow");
            }
        }
        public int pop2()
        {
            if (secondSize >= 0)
            {
                int answer = arr[secondSize];
                secondSize -= 2;
                return answer;
            }
            else
            {
                throw new RaymondSaidSoException("stack overflow");
            }
        }
}
