using Homework_StructuralDesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_StructuralDesignPatterns
{
    /// <summary>
    /// Базовый абстрактный класс для всех транспортных средств
    /// Содержит общие свойства: марка, модель, год выпуска, цена
    /// </summary>
    public abstract class Vehicle : IMyCloneable<Vehicle>, ICloneable
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        protected Vehicle(string brand, string model, int year, decimal price)
        {
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Year = year;
            Price = price;
        }

        /// <summary>
        /// Конструктор копирования для базового класса
        /// </summary>
        protected Vehicle(Vehicle other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            Brand = other.Brand;
            Model = other.Model;
            Year = other.Year;
            Price = other.Price;
        }

        /// <summary>
        /// Реализуем интерфейс IMyCloneable, а потом реализуем его в наследниках
        /// </summary>
        public abstract Vehicle Clone();


        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public override string ToString()
        {
            return $"{Brand} {Model} ({Year}) - ${Price:N0}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Vehicle other)
            {
                return Brand == other.Brand && Model == other.Model &&
                       Year == other.Year && Price == other.Price;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Brand, Model, Year, Price);
        }
    }
}
