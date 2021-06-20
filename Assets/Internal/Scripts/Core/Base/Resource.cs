using Utils;

namespace BeeColonyCore
{
    public abstract class Resource
    {
        public int Value { get; protected set; } = 0;

        public void Increase(int value) => Value += value;

        public TResource Decrease<TResource>(int value)
            where TResource : Resource
        {
            Value -= value;
            if (Value < 0) Value = 0;
            return (TResource)this;
        }
    }
}