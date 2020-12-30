using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    // Unity specific singleton.
    static ObstacleManager instance;
    void Awake()
    {
        instance = this;
        pool = new Stack<SpawnableObject>[objects.Length];
        for(int i = 0; i < pool.Length; i++)
            pool[i] = new Stack<SpawnableObject>();
    }

    public GameObject[] objects;
    Stack<SpawnableObject>[] pool;



    public static SpawnableObject Get(int ID)
    {
        if(instance.pool[ID].Count > 0)
            return instance.pool[ID].Pop();

        return GameObject.Instantiate(instance.objects[ID]).GetComponent<SpawnableObject>();
    }

    public static void Return(SpawnableObject poolObject)
    {
        instance.pool[poolObject.ID].Push(poolObject);
    }
}
