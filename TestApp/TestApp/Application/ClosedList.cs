using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Application
{
    /// <summary>
    /// Реализация замкнутой коллекции объектов типа T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ClosedList<T> : List<T>, IClosedList<T>
    {
        private const string emptyListMessage = "Лист не содержит элементов!";
        private const string negativeStep = "Число шагов долно быть положительным числом!";

        /// <summary>
        /// Индекс текущего элемента
        /// </summary>
        private int index = 0;

        /// <summary>
        /// Перемещение вперед по элементам коллекции на количесво шагов равное step.
        /// step не может быть отрицательным числом.
        /// </summary>
        /// <param name="step">Количество шагов.</param>
        public void MoveNext(int step = 1)
        {
            if(this.Count == 0)
                throw new Exception(emptyListMessage);

            if (step < 0)
                throw new Exception(negativeStep);

            index += step;            
            
            while (index >= this.Count)
            {
                HeadReached += GetMessage();
                HeadReached?.Invoke(this, this.Head);
                index -= this.Count();
            }
        }

        /// <summary>
        /// Перемещение назад по элементам коллекции на количесво шагов равное step.
        /// step не может быть отрицательным числом.
        /// </summary>
        /// <param name="step">Количество шагов.</param>
        public void MoveBack(int step = 1)
        {
            if (this.Count == 0)
                throw new Exception(emptyListMessage);

            if (step < 0)
                throw new Exception(negativeStep);

            index -= step;

            while (index < 0)
            {
                if (index + step != 0)
                    HeadReached += GetMessage();                
                HeadReached?.Invoke(this, this.Head);
                index += this.Count();
            }

            if(index == 0)
            {
                HeadReached += GetMessage();
                HeadReached?.Invoke(this, this.Head);
            }
        }

        /// <summary>
        /// Возвращает элемент коллекции с нулевым индексом.
        /// </summary>
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

        /// <summary>
        /// Возвращает текущий элемент.
        /// </summary>
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

        /// <summary>
        /// Возвращает предыдущий элемент.
        /// </summary>
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

        /// <summary>
        /// Возвращает следующий элемент.
        /// </summary>
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
        
        /// <summary>
        /// Выводит сообщение о достижении головного элемента.
        /// </summary>
        /// <returns></returns>
        private EventHandler<T> GetMessage()
        {
            Console.WriteLine("Достигнут головной элемент");
            return null;
        }

        /// <summary>
        /// Событие, которое вызывается при прохождении через элемент с нулевым индексом при движении в любом направлении.
        /// </summary>
        public event EventHandler<T> HeadReached;
    }    
}
