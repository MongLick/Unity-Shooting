using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    [SerializeField] PoolManager poolManager;

    public static Manager Inst { get { return instance; } }
    public static PoolManager Pool { get { return instance.poolManager; } }
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
