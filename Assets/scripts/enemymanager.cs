using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymanager : MonoBehaviour
{
    public int scorevalue;
    public GameObject explosion;
    


    public void Kill()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void killenemy()
    {
        Destroy(gameObject);
        Instantiate(explosion,transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
