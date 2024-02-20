using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] int damage;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem hitEffect;

    public void Fire()
    {
        muzzleFlash.Play();
        if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out RaycastHit hitInfo, maxDistance))
        {
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hitInfo.distance, Color.red, 0.1f);
            Debug.Log(hitInfo.collider.gameObject.name);
            
            IDamagable damagable = hitInfo.collider.GetComponent<IDamagable>();
            damagable?.TakeDamage(damage);

            Rigidbody rigid = hitInfo.collider.GetComponent<Rigidbody>();
            if(rigid != null)
            {
                rigid.AddForceAtPosition(-hitInfo.normal * 10f, hitInfo.point, ForceMode.Impulse);
            }

            ParticleSystem effect = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            effect.transform.parent = hitInfo.transform;
        }
        else
        {
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red, 0.1f);
        }
    }
}