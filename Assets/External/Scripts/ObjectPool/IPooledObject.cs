namespace ObjectPool
{
    public interface IPooledObject
    {
        ObjectPooler.ObjectInfo.BeeType Type { get; }
    }
}