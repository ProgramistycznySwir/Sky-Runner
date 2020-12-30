using UnityEngine;

public abstract class SpawnableObject : MonoBehaviour
{
    protected int __ID;
    public int ID => __ID;

    public virtual void Set(int ID) => __ID = ID;

    public virtual void Dispose() => ObstacleManager.Return(this);
}
