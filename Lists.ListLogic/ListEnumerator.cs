using System.Collections;
using System;

namespace Lists.ListLogic
{
    internal class ListEnumerator : IEnumerator
    {
        private Node _head;
        private int _pos;

        public ListEnumerator(Node head)
        {
            _head = head;
            _pos = -1;
        }

        public object Current => (_pos == -1) ? throw new NullReferenceException(nameof(_head)) : _head.DataObject;

        public bool MoveNext()
        {
            if (_pos == -1 && _head != null)
            {
                _pos = 0;
            }
            else
            {
                if (_head != null && _head.Next != null)
                {
                    _pos++;
                    _head = _head.Next;
                }
                else
                {
                    _pos = -1;
                }
            }

            return _pos != -1;
        }

        public void Reset()
        {
            _pos = -1;
        }
    }
}