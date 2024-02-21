using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTester : MonoBehaviour
{
    [SerializeField] PooledObject bulletPrefab;
    [SerializeField] PooledObject effectPrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randPos = Random.insideUnitSphere * 10f;
            Quaternion randRot = Random.rotation;
            PooledObject bullet = Manager.Pool.GetPool(bulletPrefab, randPos, randRot);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Vector3 randPos = Random.insideUnitSphere * 10f;
            Quaternion randRot = Random.rotation;
            PooledObject effect = Manager.Pool.GetPool(effectPrefab, randPos, randRot);
        }
    }
}
