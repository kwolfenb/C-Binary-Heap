using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class MaxBinaryHeap
    {
        List<int> values;
        MaxBinaryHeap(List<int> vals)
        {
            this.values = vals;
        }
        void Insert(int val)
        {
            this.values.Add(val);
            int valIdx = this.values.Count - 1;
            int parentIdx = (valIdx - 1) / 2;
            while (this.values[valIdx] > this.values[parentIdx])
            {
                this.values[valIdx] = this.values[parentIdx];
                this.values[parentIdx] = val;
                valIdx = parentIdx;
                parentIdx = (valIdx - 1) / 2;
                if (valIdx == 0) break;
            }
        }
        int? ExtractMax() // remove largest value and return;
        {
            if (this.values.Count == 0) return null;
            int result = this.values[0];
            int last = this.values[this.values.Count - 1];
            this.values[0] = last;
            this.values.RemoveAt(this.values.Count - 1);
            int idx = 0;
            int leftChild = 1;
            int rightChild = 2;
            int count = this.values.Count;
            while (true)
            {
                bool swap = false;
                if (leftChild >= count) break;
                if (rightChild >= count)
                {
                    if (last < this.values[leftChild])
                    {
                        this.values[idx] = this.values[leftChild];
                        this.values[leftChild] = last;
                        swap = true;
                    }
                }
                if (leftChild < count && rightChild < count)
                {
                    if (this.values[leftChild] > this.values[rightChild])
                    {
                        if (last < this.values[leftChild])
                        {
                            this.values[idx] = this.values[leftChild];
                            this.values[leftChild] = last;
                            swap = true;
                        }
                    }
                    else if (this.values[rightChild] > this.values[leftChild])
                    {
                        if (last < this.values[rightChild])
                        {
                            this.values[idx] = this.values[rightChild];
                            this.values[rightChild] = last;
                            swap = true;
                        }
                    }
                }
                idx = this.values.IndexOf(last);
                rightChild = (idx * 2) + 2;
                leftChild = (idx * 2) + 1;
                if (!swap) break;
            }
            return result;
        }
        static void Main()
        {
            var list = new List<int> { 86, 80, 75, 49, 6, 65, 35, 1, 5, 2, 3, 54 };
            MaxBinaryHeap heap = new MaxBinaryHeap(list);
            foreach (var x in heap.values) Console.WriteLine(x);
            Console.WriteLine("-----");
            heap.ExtractMax();
            foreach (var x in heap.values) Console.WriteLine(x);
            heap.ExtractMax(); heap.ExtractMax(); heap.ExtractMax(); heap.ExtractMax(); heap.ExtractMax(); heap.ExtractMax(); heap.ExtractMax(); heap.ExtractMax(); heap.ExtractMax(); heap.ExtractMax(); heap.ExtractMax(); heap.ExtractMax();
            Console.WriteLine("remaining");
            foreach (var x in heap.values) Console.WriteLine(x);

        }
    }
}
