using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopThirdPart
{
    class LinkedList
    {
        protected Node? _head;

        private Node? _tail;

        private Node? _max;

        private Node? _min;
        
        #region C'tors
        public LinkedList() { _head = null; _tail = null; _max = null; _min = null; }

        public LinkedList(Node? node) { _head = node; _tail = node; _max = null; _min = null; }
        #endregion

        #region Private
        private Node? GetPreTail()
        {
            Node? current = _head;
            if (_head == null || _head.Equals(_tail)) return null;
            while (!_tail.Equals(current.Next)) current = current.Next;
            return current;
        }

        private void UpdateExtremum(Node nominate)
        {
            if (_min == null || nominate.Value < _min.Value) _min = nominate;
            if (_max == null || nominate.Value > _max.Value) _max = nominate;
        }
        private void UpdateExtremum()
        {
            Node? current = _head;
            if (_max != null && _min != null)
            while (current != null)
            {
                if (current.Value >= _max.Value) _max = current;
                if (current.Value <= _min.Value) _min = current;
                current = current.Next;
            }
        }
        #endregion

        #region Public
        public Node? Head => _head;

        public void Append(int value)
        {
            Node toAdd = new Node(value);
            if (_tail != null)
            {
                _tail.Next = toAdd;
                _tail = _tail.Next;
            }
            else
            {
                _head = toAdd;
                _tail = _head;
            }
            UpdateExtremum(toAdd);
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
            UpdateExtremum(toAdd);
        }

        public int Pop()
        {
            int valueToReturn;
            if (_tail == null) throw new InvalidOperationException("Can't pop anything because LinkedList empty.\n");
            else
            {
                valueToReturn = _tail.Value;
                Node? preTail = GetPreTail();
                if (preTail == null) _tail = _head = null;
                else
                {
                    preTail.Next = null;
                    _tail = preTail;
                }
                if (valueToReturn == _max.Value || valueToReturn == _min.Value) UpdateExtremum();
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
                if (valueToReturn == _max.Value || valueToReturn == _min.Value) UpdateExtremum();
                return valueToReturn;
            }
        }

        public virtual IEnumerable<int> ToList()
        {
            Node? current = _head;
            List<int> list = new List<int>();
            while (current != null && _head.Equals(current.Next))
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
                List<int> list = (List<int>)ToList();
                current = _tail.Next;
                while (current != null)
                    if (list.Contains(current.Value)) return true;
                return false;
            } 
        }    
    
        public Node? GetMaxNode() { return _max; }
        public Node? GetMinNode() { return _min; }

        public void Sort()
        {
            List<int> list = (List<int>)ToList();
            list.Sort();
            LinkedList newList = new LinkedList();
            foreach (int i in list) newList.Append(i);
            _head = newList._head;
            _tail = newList._tail;
            _max = newList._max;
            _min = newList._min;
        }
        #endregion
    }
}
