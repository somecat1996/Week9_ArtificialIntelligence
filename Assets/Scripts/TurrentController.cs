using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentController : MonoBehaviour
{
    public float projectileSpeed = 50f;
    private float rateOfFire = 0.25f;
    public float targetUpdateFrequency = 0.5f;

    public TargetSelector targetSelector;
    private Transform currentTarget;
    private bool isFiring = false;

    private IEnumerator FindTarget()
    {
        while (isActiveAndEnabled)
        {
            currentTarget = targetSelector.Target;
            yield return new WaitForSeconds(targetUpdateFrequency);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(FindTarget());
    }

    private IEnumerator FireBullet()
    {
        while (currentTarget)
        {
            GameObject gameObject = ObjectPoolManager.Instance.Pool.Get();

            gameObject.transform.position = transform.position + transform.forward * 2.0f;

            Vector3 direction = (currentTarget.position - transform.position).normalized;
            gameObject.GetComponent<Rigidbody>().velocity = direction;

            yield return new WaitForSeconds(rateOfFire);
        }

        isFiring = false;
    }

    private void Update()
    {
        if (currentTarget)
        {
            transform.LookAt(currentTarget);

            if (!isFiring)
            {
                isFiring = true;
                StartCoroutine(FireBullet());
            }
        }
    }
}
