using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneFlow : MonoBehaviour
{
    [SerializeField] PooledObject bulletPrefab;
    [SerializeField] PooledObject effectPrefab;
    private void OnEnable()
    {
        Loading();
    }

    private void OnDisable()
    {
        UnLoading();
    }

    public void Loading()
    {
        Manager.Pool.CreatePool(bulletPrefab, 5);
        Manager.Pool.CreatePool(effectPrefab, 10);
    }    

    public void UnLoading()
    {
        Manager.Pool.RemovePool(bulletPrefab);
        Manager.Pool.RemovePool(effectPrefab);
    }
}
