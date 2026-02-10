using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4
{
    internal class LinkedListVector : IVectorable
    {
        class Node
        {
            internal double element = 0;
            internal Node? link = null;
        }
        Node? first;
        public LinkedListVector() : this(5)
        {
        }
        public LinkedListVector(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Node? curr = new Node();
                curr.link = first;
                first = curr;
            }
        }
        public double this[int id]
        {

            get
            {
                try
                {
                    Node? curr = first;
                    for (int i = 0; i < id; i++)
                    {
                        curr = curr?.link;
                    }
                    return curr.element;
                }
                catch(IndexOutOfRangeException )
                {
                    Console.WriteLine("Такого индекса не существует.");
                    return 0;
                }
                catch(Exception )
                {
                    Console.WriteLine("Такого индекса не существует.");
                    return 0;
                }

            }
            set
            {
                try
                {
                    Node? curr = first;
                    for (int i = 0; i < id; i++)
                    {
                        curr = curr?.link;
                    }
                    curr.element = value;
                }
                catch (IndexOutOfRangeException )
                {
                    Console.WriteLine("Такого индекса не существует.");                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Такого индекса не существует.");                   
                }
            }
        }
        public int Length
        {
            get
            {
                int n = 1;
                Node? curr = first;
                while (curr.link != null)
                {
                    n++;
                    curr = curr.link;
                }
                return n;
            }
        }
        public void DeleteFromEnd()
        {
            if (first != null)
            {
                if (first.link != null)
                {
                    Node findend = first.link;
                    while (findend.link.link != null)
                    {
                        findend = findend.link;
                    }
                    findend.link = null;
                }
                else first = null;
            }
            else { throw new IndexOutOfRangeException(); }

        }
        public void DeleteFromStart()
        {
            if (first != null)
            {
                if (first.link != null) first = first.link;
                else first = null;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void AddToStart()
        {
            Node between_element = first;
            first = new Node();
            first.link = between_element;
        }
        public void AddToTheEnd()
        {
            if (first == null)
            {
                first = new Node();
            }
            else
            {
                Node findEnd = first;
                while (findEnd.link != null)
                {
                    findEnd = findEnd.link;
                }
                findEnd.link = new Node();
            }
        }
        public void AddElement(int id)
        {
            Node UserIndex = first;
            int i = 0;
            while (true)
            {
                if (i + 1 == id)
                {
                    if (UserIndex.link == null)
                    {
                        UserIndex.link = new Node();
                    }
                    else
                    {
                        Node betw = UserIndex.link;
                        UserIndex.link = new Node();
                        UserIndex.link.link = betw;
                    }
                    break;
                }

                if (UserIndex.link == null)
                {
                    throw new ArgumentOutOfRangeException();
                }

                UserIndex = UserIndex.link;
                i++;
            }
        }
        public void DeleteElement(int id)
        {
            Node? UserIndex = first;
            int i = 0;
            if (first == null)
            {
                throw new IndexOutOfRangeException();
            }
            if (id != 0)
            {
                while (true)
                {
                    if (i + 1 == id && UserIndex.link != null)
                    {
                        if (UserIndex.link.link == null)
                        {
                            UserIndex.link = null;
                        }
                        else
                        {
                            UserIndex.link = UserIndex.link.link;
                        }
                        break;
                    }
                    if (UserIndex.link == null)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    UserIndex = UserIndex.link;
                    i++;
                }
            }
            else DeleteFromStart();
        }
        public double GetNorm()
        {
            double sum = 0.0;
            for (int i = 0; i < this.Length; i++)
            {
                sum += this[i] * this[i];
            }
            return Math.Sqrt(sum);
        }
        public override string ToString()
        {
            string vector_string = "";
            for (int i = 0; i < this.Length; i++)
            {
                vector_string += this[i].ToString() + " ";
            }
            return $"Число координат вектора: {this.Length} Координаты вектора: {vector_string}";
        }
    }
}
