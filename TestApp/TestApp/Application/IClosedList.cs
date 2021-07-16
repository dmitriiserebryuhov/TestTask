using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Application
{
    /// <summary>
    /// Интерфейс для замкнутой коллекции объектов типа T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IClosedList<T> : IList<T>
    {
        /// <summary>
        /// Перемещение вперед по элементам коллекции на количесво шагов равное step.
        /// </summary>
        /// <param name="step">Количество шагов.</param>
        void MoveNext(int step = 1);

        /// <summary>
        /// Перемещение назад по элементам коллекции на количесво шагов равное step.
        /// </summary>
        /// <param name="step">Количество шагов.</param>
        void MoveBack(int step = 1);

        /// <summary>
        /// Возвращает элемент коллекции с нулевым индексом.
        /// </summary>
        T Head { get; }

        /// <summary>
        /// Возвращает текущий элемент.
        /// </summary>
        T Current { get; }

        /// <summary>
        /// Возвращает предыдущий элемент.
        /// </summary>
        T Previous { get; }

        /// <summary>
        /// Возвращает следующий элемент.
        /// </summary>
        T Next { get; }

        /// <summary>
        /// Событие, которое вызывается при прохождении через элемент с нулевым индексом при движении в любом направлении.
        /// </summary>
        event EventHandler<T> HeadReached;
    }
}
