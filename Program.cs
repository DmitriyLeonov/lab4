using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> set1 = new Set<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            Set<int> set2 = new Set<int>() { 8, 9, 10, 11, 15, 16, 17, 18, 19 };
            set2++;
            Set<int> set3 = set1 + set2;
            Set<int> set4 = new Set<int>() { 1, 2, 3, 4, 5, 6, 7 };
            if (set4 <= set1)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            int power = set2;
            Console.WriteLine(power);
            Console.WriteLine(set1 % 1);
            Console.Read();
        }
    }

    public class Set<T> : IEnumerable<int>
    {
        private List<int> _items = new List<int>();
        public int Count => _items.Count;
        static Random rnd = new Random();

        public void Add(int item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }

        public static Set<T> operator ++(Set<T> item)
        {
            item.Add(rnd.Next(0, 8000));
            return item;
        }

        public void Remove(int item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (!_items.Contains(item))
            {
                throw new KeyNotFoundException("Элемент не найден");
            }
            _items.Remove(item);
        }

        public static Set<int> operator +(Set<T> set1, Set<int> set2)
        {
            if(set1 == null || set2 == null)
            {
                throw new ArgumentNullException();
            }

            var resultSet = new Set<int>();
            var items = new List<int>();
            if (set1._items != null && set1._items.Count > 0)
            {
                items.AddRange(new List<int>(set1._items));
            }

            if (set2._items != null && set2._items.Count > 0)
            {
                items.AddRange(new List<int>(set2._items));
            }
            resultSet._items = items.Distinct().ToList();
            return resultSet;
        }

        public static Set<int> Intersection(Set<int> set1, Set<int> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }

            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            var resultSet = new Set<int>();

            if (set1.Count < set2.Count)
            {
                foreach (var item in set1._items)
                {
                    if (set2._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in set2._items)
                {
                    if (set1._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }

            return resultSet;
        }

        public static bool operator <=(Set<T> set1, Set<T> set2)
        {
            if (set1.Count() > set2.Count())
            {
                return false;
            }else 
            {
                for (int i = 0; i < set1.Count; i++)
                {
                    if (!set2.Contains(set1.ElementAt(i)))
                        return false;
                }
            }
            return true;
        }

        public static bool operator >=(Set<T> set1, Set<T> set2)
        {
            if (set1.Count() < set2.Count())
            {
                return false;
            }
            else
            {
                for (int i = 0; i < set1.Count; i++)
                {
                    if (!set2.Contains(set1.ElementAt(i)))
                        return false;
                }
            }
            return true;
        }

        public static implicit operator int(Set<T> set)
        {
            return set.Count();
        }

        public static int operator %(Set<T> set, int position)
        {
            return set.ElementAt(position);
        }

        public static bool Subset(Set<int> set1, Set<int> set2)
        {
            if (set1 == null)
            {
                throw new ArgumentNullException(nameof(set1));
            }

            if (set2 == null)
            {
                throw new ArgumentNullException(nameof(set2));
            }

            var result = set1._items.All(s => set2._items.Contains(s));
            return result;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
