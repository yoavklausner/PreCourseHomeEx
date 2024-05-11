using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopThirdPart
{
    class LinkedList
    {
        private Node? _head;

        private Node? _tail;

        private Node? _max;

        private Node? _min;
        
        #region Private
        private Node? GetPreTail()
        {
            Node? current = _head;
            if (_head == null || _head.Equals(_tail)) return null;
            while (!_tail!.Equals(current!.Next)) current = current.Next; 
            //current cant be null because tail.(current.Next) will come before
            return current;
        }

        private void UpdateMaxMin(Node nominate)
        {
            if (_min == null || nominate.Value < _min.Value) _min = nominate;
            if (_max == null || nominate.Value > _max.Value) _max = nominate;
        }
        private void UpdateMaxMin()
        {
            Node? current = _head;
            if (current == null) _max = _min = null;
            _min = _max = current;
            while (current != null && current != _tail!.Next)
            {
                if (current.Value >= _max!.Value) _max = current;
                if (current.Value <= _min!.Value) _min = current;
                current = current.Next;
            }

        }
        #endregion

        #region Public

        public void Append(int value)
        {
            Node toAdd = new Node(value);
            if (_tail != null)
            {
                _tail.Next = toAdd;
                _tail = toAdd;
            }
            else
            {
                _head = toAdd;
                _tail = toAdd;
            }
            UpdateMaxMin(toAdd);
        }

        public void Prepend(int value)
        {
            Node toAdd = new Node(value);
            if (_head != null)
            {
                toAdd.Next = _head;
                _head = toAdd;
            }
            else
            {
                _head = toAdd;
                _tail = toAdd;
            }
            UpdateMaxMin(toAdd);
        }

        public int Pop()
        {
            int valueToReturn;
            if (_tail == null) throw new InvalidOperationException("Can't pop anything because LinkedList empty.\n");
            else
            {
                valueToReturn = _tail.Value;
                Node? preTail = GetPreTail();
                if (preTail == null) _tail = _head = null; //in this case the list length is 1 pre-pop
                else
                {
                    preTail.Next = null;
                    _tail = preTail;
                }
                if (valueToReturn == _max!.Value || valueToReturn == _min!.Value) UpdateMaxMin();
                return valueToReturn;
            }
        }
    
        public int Unqueue()
        {
            if (_head == null) throw new InvalidOperationException("Can't unqueue anything because LinkedList empty.\n");
            else
            {
                int valueToReturn = _head.Value;
                Node? newHead = _head.Next;
                _head.Next = null;
                _head = newHead;
                if (valueToReturn == _max!.Value || valueToReturn == _min!.Value) UpdateMaxMin();
                return valueToReturn;
            }
        }

        public virtual IEnumerable<int> ToList()
        {
            Node? current = _head;
            if (IsCircular()) throw new InvalidOperationException("Can't convert to list because is circular.");
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    
        public bool IsCircular()
        {
            Node? current;
            if (_tail == null) return false;
            else
            {
                current = _tail.Next;
                while (current != null && !current.Equals(_tail)) current = current.Next;
                if (current == null) return false;
                return true;
            } 
        }    
    
        public Node? GetMaxNode() { return _max; }
        public Node? GetMinNode() { return _min; }

        //extra method because GetMin\Max returns a linked node so this api enables to remove it.
        public void Remove(Node? node)
        {
            Node? current = _head;
            Node? prev = null;
            if (node != null && current != null)
            {
                while (current != null && !current.Equals(node)) 
                { 
                    prev = current;  
                    current = current.Next;
                }
                if (current != null)
                {
                    prev!.Next = current.Next;
                    current.Next = null;
                }
                if (node.Equals(_min) || node.Equals(_max)) UpdateMaxMin();
            }
        }

        public void Sort()
        {
            Node? oldHead = _head, oldTail = _tail, current, prev;
            if (_head != null) {
                IEnumerable<int> list = ToList();
                list = list.OrderBy(x => x);
                foreach (int i in list) { Append(i); }
                _head = oldTail!.Next;
                _min = _head;
                _max = _tail;
                //from here Im deleting previous order manually in case someone mess the refs
                oldTail.Next = null;
                current = oldHead!.Next;
                prev = oldHead;
                while (current != null)
                {
                    prev.Next = null;
                    prev = current;
                    current = current.Next;
                }
            }

        }
        #endregion


        #region Overrides

        public override string ToString()
        {
            return (_head != null? _head.ToString() : "Empty\n");
        }
        #endregion
    }
}
