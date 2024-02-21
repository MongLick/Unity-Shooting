using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPooler pooler;
    [SerializeField] bool autoRelease;
    [SerializeField] float releaseTime;

    private void OnEnable()
    {
        if (autoRelease)
        {
            releaseRoutine = StartCoroutine(ReleaseRoutine());
        }
    }

    Coroutine releaseRoutine;

    IEnumerator ReleaseRoutine()
    {
        yield return new WaitForSeconds(2f);
        Release();
    }

    public void Release()
    {
        if(pooler != null)
        {
            pooler.ReturnPool(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
