using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyshoot : MonoBehaviour
{

    public GameObject enemyBulletPrefab;
    public float cooldown = 7f;

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while (true) 
        {
            Shoot();
            yield return new WaitForSeconds(cooldown);
        }
    }

    private void Shoot()
    {
        Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);

    }


}





