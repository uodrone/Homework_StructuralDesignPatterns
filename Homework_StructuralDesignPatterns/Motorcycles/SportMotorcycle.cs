using Homework_StructuralDesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_StructuralDesignPatterns.Motorcycles
{
    /// <summary>
    /// Класс спортивного мотоцикла, наследуется от Motorcycle
    /// Добавляет спортивные характеристики:
    /// максимальная скорость, наличие ABS, режим трека
    /// </summary>
    public class SportMotorcycle : Motorcycle, IMyCloneable<SportMotorcycle>
    {
        public int MaxSpeed { get; set; }
        public bool HasABS { get; set; }
        public string TrackMode { get; set; }

        public SportMotorcycle(string brand, string model, int year, decimal price,
                              int engineCapacity, string motorcycleType, bool hasSidecar,
                              int maxSpeed, bool hasABS, string trackMode)
            : base(brand, model, year, price, engineCapacity, motorcycleType, hasSidecar)
        {
            MaxSpeed = maxSpeed;
            HasABS = hasABS;
            TrackMode = trackMode ?? throw new ArgumentNullException(nameof(trackMode));
        }

        /// <summary>
        /// Конструктор копирования для SportMotorcycle
        /// </summary>
        protected SportMotorcycle(SportMotorcycle other) : base(other)
        {
            MaxSpeed = other.MaxSpeed;
            HasABS = other.HasABS;
            TrackMode = other.TrackMode;
        }

        public override Vehicle Clone()
        {
            return new SportMotorcycle(this);
        }

        SportMotorcycle IMyCloneable<SportMotorcycle>.Clone()
        {
            return new SportMotorcycle(this);
        }

        public override string ToString()
        {
            return base.ToString() + $", Max Speed: {MaxSpeed} km/h, ABS: {HasABS}, Track Mode: {TrackMode}";
        }

        public override bool Equals(object obj)
        {
            if (obj is SportMotorcycle other && base.Equals(obj))
            {
                return MaxSpeed == other.MaxSpeed && HasABS == other.HasABS &&
                       TrackMode == other.TrackMode;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), MaxSpeed, HasABS, TrackMode);
        }
    }
}
