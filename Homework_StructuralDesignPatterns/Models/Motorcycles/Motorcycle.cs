using Homework_StructuralDesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_StructuralDesignPatterns.Models.Motorcycles
{
    /// <summary>
    /// Класс мотоцикла, наследуется от Vehicle + добавляет специфичные для мотоцикла свойства
    /// </summary>
    public class Motorcycle : Vehicle, IMyCloneable<Motorcycle>
    {
        public int EngineCapacity { get; set; }
        public string MotorcycleType { get; set; }
        public bool HasSidecar { get; set; }

        public Motorcycle(string brand, string model, int year, decimal price, int engineCapacity, string motorcycleType, bool hasSidecar): base(brand, model, year, price)
        {
            EngineCapacity = engineCapacity;
            MotorcycleType = motorcycleType ?? throw new ArgumentNullException(nameof(motorcycleType));
            HasSidecar = hasSidecar;
        }

        /// <summary>
        /// Конструктор копирования для Motorcycle
        /// </summary>
        protected Motorcycle(Motorcycle other) : base(other)
        {
            EngineCapacity = other.EngineCapacity;
            MotorcycleType = other.MotorcycleType;
            HasSidecar = other.HasSidecar;
        }

        public override Vehicle Clone()
        {
            return new Motorcycle(this);
        }

        Motorcycle IMyCloneable<Motorcycle>.Clone()
        {
            return new Motorcycle(this);
        }

        public override string ToString()
        {
            return base.ToString() + $", Engine: {EngineCapacity}cc, Type: {MotorcycleType}, Sidecar: {HasSidecar}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Motorcycle other && base.Equals(obj))
            {
                return EngineCapacity == other.EngineCapacity && MotorcycleType == other.MotorcycleType &&
                       HasSidecar == other.HasSidecar;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), EngineCapacity, MotorcycleType, HasSidecar);
        }
    }

}
