using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private Dictionary<string, ObjectPooler> poolDic = new Dictionary<string, ObjectPooler>();

    public void CreatePool(PooledObject prefab, int size)
    {
        GameObject poolGameObject = new GameObject($"Pool_{prefab.gameObject.name}");
        ObjectPooler objectPooler = poolGameObject.AddComponent<ObjectPooler>();
        objectPooler.CreatePool(prefab, size);

        poolDic.Add(prefab.gameObject.name, objectPooler);
    }

    public PooledObject GetPool(PooledObject prefab, Vector3 position, Quaternion rotation)
    {
        return poolDic[prefab.gameObject.name].GetPool(position, rotation);
    }

    public void RemovePool(PooledObject prefab)
    {
        ObjectPooler objectPooler = poolDic[prefab.gameObject.name];

        if (objectPooler != null)
        {
            Destroy(objectPooler);
        }

        poolDic.Remove(prefab.gameObject.name);
    }
}
