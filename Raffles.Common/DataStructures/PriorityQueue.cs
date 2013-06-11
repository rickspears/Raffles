namespace Raffles.Common.DataStructures
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<TKey, TValue>
    {
        #region Constructors
        public PriorityQueue() :this(50, Comparer<TValue>.Default) { }
        public PriorityQueue(int size) :this(size, Comparer<TValue>.Default) { }
        public PriorityQueue(IComparer<TValue> comparer) :this(50,comparer) { }

        public PriorityQueue(int size, IComparer<TValue> comparer) {
            values = new KeyValuePair<TKey, TValue>[size];
            Comparer = comparer;
            Count = 0;
        }
        #endregion

        #region Fields
        private KeyValuePair<TKey, TValue>[] values;
        
        #endregion

        #region Properties
        public int Count { get; private set; }
        public IComparer<TValue> Comparer { get; private set; }
        #endregion

        #region Methods
        public void Insert(TKey key, TValue value) {
            Insert(new KeyValuePair<TKey, TValue>(key, value));
        }
        public void Insert(KeyValuePair<TKey, TValue> pair) {
            IncreaseSize();
            values[Count] = pair;
            BubbleUp(Count);
            Count += 1;
        }

        public TKey ExtractKey() {
            return ExtractPair().Key;
        }

        public KeyValuePair<TKey, TValue> ExtractPair() {
            KeyValuePair<TKey, TValue> root = values[0];
            Swap(0, Count - 1);
            values[Count - 1] = default(KeyValuePair<TKey, TValue>);
            Count -= 1;
            BubbleDown(0);
            return root;
        }
        #endregion

        #region Helper Methods

        private int Parent(int i) { return (i - 1) / 2; }
        private int LeftChild(int i) { return i * 2 + 1; }
        private int RightChild(int i) { return i * 2 + 2; }

        private void BubbleUp(int i) {
            if (i > 0
                && Comparer.Compare(values[i].Value, values[Parent(i)].Value) > 0) {
                    Swap(Parent(i), i);
                    BubbleUp(Parent(i));
            }
        }

        private void BubbleDown(int i) {
            if (HasChildren(i)) {
                int child = GetBetterChild(i);
                Swap(i, child);
                BubbleDown(child);
            }
        }

        private void Swap(int left, int right) {
            KeyValuePair<TKey, TValue> temp = values[left];
            values[left] = values[right];
            values[right] = temp;
        }

        private bool HasChildren(int i) {
            if (LeftChild(i) >= Count)
                return false;
            return true;
        }        

        private int GetBetterChild(int i) {
            if (values[RightChild(i)].Equals(default(KeyValuePair<TKey,TValue>)))
                return LeftChild(i);
            if (Comparer.Compare(values[LeftChild(i)].Value, values[RightChild(i)].Value) > 0)
                return LeftChild(i);
            return RightChild(i);
        }

        private void IncreaseSize() {
            if (Count >= values.Length)
                Array.Resize(ref values, values.Length * 4);
        }        
        #endregion
    }
}
