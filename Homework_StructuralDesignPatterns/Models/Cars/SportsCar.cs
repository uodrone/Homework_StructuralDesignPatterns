using Homework_StructuralDesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_StructuralDesignPatterns.Models.Cars
{
    /// <summary>
    /// Класс спортивного автомобиля, наследуется от Car
    /// Добавляет характеристики производительности:
    /// максимальная скорость, разгон до 100 км/ч, наличие турбо
    /// </summary>
    public class SportsCar : Car, IMyCloneable<SportsCar>
    {
        public int MaxSpeed { get; set; }
        public double Acceleration { get; set; }
        public bool HasTurbo { get; set; }

        public SportsCar(string brand, string model, int year, decimal price,
                         int doorsCount, string fuelType, bool isAutomatic,
                         int maxSpeed, double acceleration, bool hasTurbo)
            : base(brand, model, year, price, doorsCount, fuelType, isAutomatic)
        {
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
            HasTurbo = hasTurbo;
        }

        /// <summary>
        /// Конструктор копирования для SportsCar
        /// </summary>
        protected SportsCar(SportsCar other) : base(other)
        {
            MaxSpeed = other.MaxSpeed;
            Acceleration = other.Acceleration;
            HasTurbo = other.HasTurbo;
        }

        public override Vehicle Clone()
        {
            return new SportsCar(this);
        }

        SportsCar IMyCloneable<SportsCar>.Clone()
        {
            return new SportsCar(this);
        }

        public override string ToString()
        {
            return base.ToString() + $", Max Speed: {MaxSpeed} km/h, 0-100: {Acceleration}s, Turbo: {HasTurbo}";
        }

        public override bool Equals(object obj)
        {
            if (obj is SportsCar other && base.Equals(obj))
            {
                return MaxSpeed == other.MaxSpeed && Math.Abs(Acceleration - other.Acceleration) < 0.01 &&
                       HasTurbo == other.HasTurbo;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), MaxSpeed, Acceleration, HasTurbo);
        }
    }
}
