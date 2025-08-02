using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_StructuralDesignPatterns.Interfaces
{
    /// <summary>
    /// Пользовательский дженерик интерфейс для реализации паттерна Прототип
    /// Обеспечивает типобезопасное клонирование объектов
    /// </summary>
    /// <typeparam name="T">Тип клонируемого объекта</typeparam>
    public interface IMyCloneable<out T>
    {
        /// <summary>
        /// Создает копию объекта
        /// </summary>
        /// <returns>Клон объекта указанного типа</returns>
        T Clone();
    }
}
