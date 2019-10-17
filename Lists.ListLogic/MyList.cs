using System;
using System.Collections;

namespace Lists.ListLogic
{
    /// <summary>
    /// Die Liste verwaltet beliebige Elemente und implementiert
    /// das IList-Interface und damit auch ICollection und IEnumerable
    /// </summary>
    public class MyList : IList
    {
        Node _head;

        #region IList Members

        /// <summary>
        /// Ein neues Objekt wird in die Liste am Ende
        /// eingefügt. Etwaige Typinkompatiblitäten beim Vergleich werden
        /// nicht behandelt und lösen eine Exception aus.
        /// </summary>
        /// <param name="value">Einzufügender Datensatz</param>
        /// <returns>Index des Werts in der Liste</returns>
        public int Add(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Node newNode = new Node(value);
            int idx = 0;

            if (_head == null)
            {
                _head = newNode;
            }
            else if (_head.Next == null)
            {
                _head.Next = newNode;
                idx = 1;
            }
            else
            {
                Node run = _head;
                idx = 1;

                while (run.Next != null)
                {
                    idx++;
                    run = run.Next;
                }

                run.Next = newNode;
            }

            return idx;
        }

        /// <summary>
        /// Die Liste wird geleert. Die Elemente werden einfach ausgekettet.
        /// Der GC räumt dann schon auf.
        /// </summary>
        public void Clear()
        {
            _head = null;
        }

        /// <summary>
        /// Gibt es den gesuchten DataObject zumindest ein mal?
        /// </summary>
        /// <param name="value">gesuchter DataObject</param>
        /// <returns></returns>
        public bool Contains(object value)
        {
            bool contains = false;
            Node run = _head;

            while (run != null)
            {
                if (run.DataObject.Equals(value))
                    contains = true;

                run = run.Next;
            }

            return contains;
        }

        /// <summary>
        /// Der DataObject wird gesucht und dessen Index wird zurückgegeben.
        /// </summary>
        /// <param name="value">gesuchter DataObject</param>
        /// <returns>Index oder -1, falls der DataObject nicht in der Liste ist</returns>
        public int IndexOf(object value)
        {
            int idx = 0;
            Node run = _head;

            while (run != null && !run.DataObject.Equals(value))
            {
                idx++;
                run = run.Next;
            }

            return (run != null) ? idx : -1;
        }

        /// <summary>
        /// DataObject an bestimmter Position in Liste einfügen.
        /// Es ist auch erlaubt, einen DataObject hinter dem letzten Element
        /// (index == count) einzufügen.
        /// </summary>
        /// <param name="index">Einfügeposition</param>
        /// <param name="value">Einzufügender DataObject</param>
        public void Insert(int index, object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (index >= 0 && index <= Count)
            {
                Node newNode = new Node(value);

                if (index == 0)
                {
                    newNode.Next = _head;
                    _head = newNode;
                }
                else
                {
                    Node run = _head;

                    for (int i = 1; i < index; i++)
                    {
                        run = run.Next;
                    }

                    newNode.Next = run.Next;
                    run.Next = newNode;
                }
            }
        }

        /// <summary>
        /// Wird nicht verwendet ==> Immer false
        /// </summary>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Wird nicht verwendet ==> Immer false
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Ein DataObject wird aus der Liste entfernt, wenn es ihn 
        /// zumindest ein mal gibt.
        /// </summary>
        /// <param name="value">zu entfernender DataObject</param>
        public void Remove(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (_head != null && this.Contains(value))
            {
                if (_head.DataObject.Equals(value))
                {
                    _head = _head.Next;
                }
                else
                {
                    Node run = _head;

                    while (run.Next != null && !run.Next.DataObject.Equals(value))
                    {
                        run = run.Next;
                    }

                    if (run != null)
                        run.Next = run.Next.Next;
                }
            }
        }

        /// <summary>
        /// Der DataObject an der Position Index wird entfernt.
        /// Gibt es die Position nicht, geschieht nichts.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                if (_head != null)
                {
                    if (index == 0)
                    {
                        _head = _head.Next;
                    }
                    else
                    {
                        Node run = _head;

                        for (int i = 1; i < index; i++)
                        {
                            run = run.Next;
                        }

                        run.Next = run.Next.Next;
                    }
                }
                else
                {
                    throw new ArgumentNullException(nameof(_head));
                }
            }
        }

        /// <summary>
        /// Indexer zum Einfügen und Lesen von Werten an
        /// gesuchten Positionen.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                Node run = _head;

                for (int i = 0; i < index && run != null; i++)
                {
                    run = run.Next;
                }

                return run.DataObject;
            }
            set
            {
                Insert(index, value);

                if (index == 0)
                {
                    RemoveAt(1);
                }
                else
                {
                    RemoveAt(index + 1);
                }
            }
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Werte in ein bereits angelegtes Array kopieren.
        /// Ist das übergebene Array zu klein, oder stimmt der
        /// Startindex nicht, geschieht nichts.
        /// </summary>
        /// <param name="array">Zielarray, existiert bereits</param>
        /// <param name="index">Startindex</param>
        public void CopyTo(Array array, int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node run = _head;

            if (_head != null)
            {
                int idxCounter = 0;

                if (index > 0)
                {
                    for (int i = 0; i < index && run != null; i++)
                    {
                        idxCounter++;
                        run = run.Next;
                    }
                }

                if (Count - idxCounter <= array.Length)
                {
                    for (int i = 0; run != null; i++)
                    {
                        array.SetValue(run.DataObject, i);
                        run = run.Next;
                    }
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_head));
            }
        }

        /// <summary>
        /// Die Anzahl von Elementen in der Liste wird immer 
        /// explizit gezählt und ist nicht redundant gespeichert.
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                Node run = _head;

                while (run != null)
                {
                    count++;
                    run = run.Next;
                }

                return count;
            }
        }

        /// <summary>
        /// Multithreading wird nicht verwendet
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Multithreading wird nicht verwendet
        /// </summary>
        public object SyncRoot
        {
            get { return null; }
        }

        #endregion

        public IEnumerator GetEnumerator()
        {
            return new ListEnumerator(_head);
        }

        public static void Sort(MyList myList, IComparer comparer)
        {
            if (myList._head != null)
            {
                int result;

                for (int i = 0; i < myList.Count; i++)
                {
                    for (int j = 0; j < myList.Count - 1; j++)
                    {
                        IComparable object1 = myList[j] as IComparable;
                        IComparable object2 = myList[j + 1] as IComparable;

                        if (object1 == null)
                            throw new ArgumentNullException(nameof(object1));
                        if (object2 == null)
                            throw new ArgumentNullException(nameof(object2));

                        if (comparer != null)
                        {
                            result = comparer.Compare(object1, object2);
                        }
                        else
                        {
                            result = object1.CompareTo(object2);
                        }

                        if (result == 1)
                        {
                            object tmp = myList[j];
                            myList[j] = myList[j + 1];
                            myList[j + 1] = tmp;
                        }
                    }
                }
            }
        }

        public static void Sort(MyList myList)
        {
            Sort(myList, null);
        }

        //TEST
    }
}
