using Homework_StructuralDesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_StructuralDesignPatterns.Cars
{
    /// <summary>
    /// Класс автомобиля, наследуется от Vehicle
    /// Добавляет специфичные для автомобиля свойства:
    /// количество дверей, тип топлива, тип коробки передач
    /// </summary>
    public class Car : Vehicle, IMyCloneable<Car>
    {
        public int DoorsCount { get; set; }
        public string FuelType { get; set; }
        public bool IsAutomatic { get; set; }

        public Car(string brand, string model, int year, decimal price, int doorsCount, string fuelType, bool isAutomatic): base(brand, model, year, price)
        {
            DoorsCount = doorsCount;
            FuelType = fuelType ?? throw new ArgumentNullException(nameof(fuelType));
            IsAutomatic = isAutomatic;
        }

        /// <summary>
        /// Конструктор копирования для Car
        /// Вызывает конструктор копирования родительского класса
        /// </summary>
        protected Car(Car other) : base(other)
        {
            DoorsCount = other.DoorsCount;
            FuelType = other.FuelType;
            IsAutomatic = other.IsAutomatic;
        }

        /// <summary>
        /// Реализация клонирования для базового типа Vehicle
        /// </summary>
        public override Vehicle Clone()
        {
            return new Car(this);
        }

        /// <summary>
        /// Типизированная реализация клонирования для Car
        /// </summary>
        Car IMyCloneable<Car>.Clone()
        {
            return new Car(this);
        }

        public override string ToString()
        {
            return base.ToString() + $", Doors: {DoorsCount}, Fuel: {FuelType}, Auto: {IsAutomatic}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Car other && base.Equals(obj))
            {
                return DoorsCount == other.DoorsCount && FuelType == other.FuelType &&
                       IsAutomatic == other.IsAutomatic;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), DoorsCount, FuelType, IsAutomatic);
        }
    }
}
