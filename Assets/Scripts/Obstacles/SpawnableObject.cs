using UnityEngine;

public abstract class SpawnableObject : MonoBehaviour
{
    protected int __ID;
    public int ID => __ID;

    public virtual void Set(int ID)
    {
        gameObject.SetActive(true);
        __ID = ID;
    }

    public virtual void Dispose()
    {
        gameObject.SetActive(false);
        ObstacleManager.Return(this);
    }
}