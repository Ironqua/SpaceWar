using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbullet : MonoBehaviour
{
    private float speed = 10;
    public GameObject htiprefab;
    private float effectduraction = 0.5f;



    private void Update()
    {
       transform.Translate(Vector2.up*speed*Time.deltaTime); // merminin  hareketi
        
    if (transform.position.y > 10) // bullet y deðerini geçtikten sonra false olur ve gitmeye devam etmez
        {
            gameObject.SetActive(false);
        }

    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
            collision.gameObject.GetComponent<enemymanager>().killenemy();
            gameObject.SetActive(false);
            UIMANAGER.updatescore(100);
            

        }
        if (collision.gameObject.CompareTag("asteroid"))
        {
            collision.gameObject.GetComponent<enemymanager>().Kill();
            gameObject.SetActive(false);
            UIMANAGER.updatescore(50);




            //Destroy(collision.gameObject);
            //Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("enemybullet"))
        {
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
            collision.gameObject.SetActive(false);  
            gameObject.SetActive(false);
            effects();
            
        }
    }
      private void effects()
    {
        GameObject effect=Instantiate(htiprefab, transform.position, Quaternion.identity, transform.parent);
        Destroy(effect, effectduraction);
    }

}
