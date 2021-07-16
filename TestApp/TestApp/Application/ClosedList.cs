using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Application
{
    public class ClosedList<T> : List<T>, IClosedList<T>
    {
        private const string emptyListMessage = "Лист не содержит элементов!";

        public void MoveNext(int x = 1)
        {
            index += x;
            IndexBoundary();          
        }

        public void MoveBack(int x = 1)
        {
            index -= x;
            IndexBoundary();            
        }

        private void IndexBoundary()
        {
            if (index < 0)
            {
                index *= -1;
                index %= this.Count;
                index = this.Count - index;
            }
            else
                index %= this.Count;
        }

        public T Head 
        {
            get
            {
                if (this.Count != 0)
                    return this.First();
                else
                    throw new Exception(emptyListMessage);
            }
        }

        public T Current 
        {
            get 
            {
                if(this.Count != 0)
                    return this[index];                
                else
                    throw new Exception(emptyListMessage);
            } 
        }

        public T Previous 
        { 
            get
            {
                if (this.Count != 0)
                {
                    if (index == 0)
                        return this.LastOrDefault();
                    else
                        return this[index - 1];
                }
                else
                    throw new Exception(emptyListMessage);
            }
        }

        public T Next 
        { 
            get
            {
                if (this.Count != 0)
                {
                    if (index == this.Count - 1)
                        return this[0];
                    else
                        return this[index + 1];
                }
                else
                    throw new Exception(emptyListMessage);
            }
        }

        private int index = 0;

        private void GetMessage()
        {
            Console.WriteLine("Достигнут головной элемент");
        }

        public event EventHandler<T> HeadReached;
    }    
}
