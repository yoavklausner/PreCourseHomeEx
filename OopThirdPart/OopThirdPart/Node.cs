using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopThirdPart
{
    internal class Node
    {
        protected readonly int _value;
        protected Node? _next;

        #region C'tors
        public Node(int value)
        {
            _value = value;
            _next = null;
        }

        public Node(int value, Node next)
        {
            _value = value;
            _next = next;
        }
        #endregion

        #region Getters & Setters
        public int Value => _value;
        public Node? Next { get => _next; set => _next = value; }
        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{_value}" + (_next != null ? $"->{_next}" : "\n");
        }

        public override bool Equals(object? obj)
        {
            return obj != null &&
                obj is Node &&
                ((Node)obj).Value == _value &&
                ((Node)obj).Next == _next;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
