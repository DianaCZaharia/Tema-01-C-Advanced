using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaS1
{
    public class Set<T>
    {
        public Set()
        {
            myList = new List<T>();
        }

        private List<T> myList;
        public T this[int index] 
        {
            get { return myList[index]; }
            set 
            { 
                if((Contains(value)==true) && !myList[index].Equals(value))
                {
                    throw new Exception("Numarul exista deja.");
                }
                myList[index] = value; 
            }
        }
        public void Insert(T item)
        {
            if (Contains(item)==true)
            {
                throw new Exception("Avem dublura!");
            }
            myList.Add(item);
        }

        public void Remove(T item)
        {
            myList.Remove(item);
        }
        public bool Contains(T item)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public Set<T> Merge(Set<T> other)
        {

            for (int i = 0; i < other.myList.Count; i++)
            {
                if(Contains(other[i]) == false)
                {
                    this.Insert(other[i]);
                }
                else
                {
                    throw new Exception("Elementul exista deja in lista.");
                }
            }
            return this;
            //P1 iterez lista 2(others)
            //P2 In for-ul din lista 2, Contains(myList2[i])==false
            //P3 in if, daca e false, face this.Instert(other[i])
            //p4 (else) arunca exceptie.
            //P5 return this dupa iesirea din for.
        }
        public Set<T> Filter(Predicate<T> filtredLogic) 
        {
            var mySubSet = new Set<T>();
            for (int i = 0; i < myList.Count; i++)
            {
                if (filtredLogic.Invoke(myList[i]))
                {
                    mySubSet.Insert(myList[i]);
                }

            }
            return mySubSet;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Set<int> mySet;
            mySet = new Set<int>();
            mySet.Insert(1);
            mySet.Insert(2);
            mySet.Insert(3);
            //mySet[0] = 1;
            var filtredResult=mySet.Filter( (x) => x%2==0 );
            //Set<int> mySet2;
            //mySet2 = new Set<int>();
            //mySet2.Insert(3);
            //var result = mySet2.Contains(3);
            //Console.WriteLine(result);
            Set<int> mySet2;
            mySet2 = new Set<int>();
            Set<int> myMergedSet;
            myMergedSet = new Set<int>();
            mySet2.Insert(4);
            mySet2.Insert(5);
            mySet2.Insert(6);
            myMergedSet = mySet.Merge(mySet2);
            Console.WriteLine(myMergedSet);
        }
    }
}