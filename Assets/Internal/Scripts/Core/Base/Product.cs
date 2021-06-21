using UnityEngine;
using Utils;

namespace BeeColonyCore
{
    public abstract class Product
    {
        public Product()
        {
            Type = AvailableType.Flower;
            Value = 0;
        }
        
        public Product(AvailableType type, int value = 0)
        {
            Type = type;
            Value = value;
        }
        
        public enum AvailableType
        {
            Flower,
            Icy,
            Night,
            Bloody,
            Steel
        }
        
        public AvailableType Type { get; protected set; }
        public int Value { get; protected set; }

        public void Increase(int value) => Value += value;

        public TProduct Decrease<TProduct>(int value)
            where TProduct : Product, new()
        {
            var newProduct = new TProduct
            {
                Type = Type,
                Value = GetDecreaseValue(value)
            };
            return newProduct;
        }

        private int GetDecreaseValue(int value)
        {
            if (value > Value) return 0;
            Value -= value;
            return value;
        }
    }
}