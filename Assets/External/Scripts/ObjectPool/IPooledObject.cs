namespace ObjectPool
{
    public interface IPooledObject
    {
        ObjectPooler.ObjectInfo.ObjectType Type { get; }
    }
}