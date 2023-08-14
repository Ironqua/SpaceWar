using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class shipcontroller : MonoBehaviour
{


    public GameObject bulletprefab;
    public bool isshooting;
    private float cooldown = 0.5f;

    #region movement 
    public float speed;
    public float minx;
    public float miny;
    public float maxy;
    public float maxx;
    #endregion

    [SerializeField] private objectpool objectPool = null; // objectpool classýný aldýk
    public float health;
    float maxHealth = 100f;
    public Slider healthSlider;
   public  GameObject explosion;
    public GameObject htiprefab;
    private float effectduraction = 0.5f;
    
    private float minCooldown = 0.1f; // Minimum ateþ hýzý
    private float cooldownDecreaseRate = 0.05f; // Her ateþ sonrasý hýzlanma miktarý

    public GameObject gameOverPanel;

    private void Start()
    {
        healthSlider.value = health;
    }

    private void Update()
    {

        #region movement 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, vertical, 0f) * Time.deltaTime * speed;
        Vector3 newposition=transform.position+ move;

        newposition.x = Mathf.Clamp(newposition.x, minx, maxx);
        newposition.y= Mathf.Clamp(newposition.y, miny, maxy);

        transform.position = newposition;


        #endregion

        #region shoot
        if (Input.GetKey(KeyCode.Space) && !isshooting)
        {
            StartCoroutine(Shoot());
        }

        #endregion
    }

    private IEnumerator Shoot()
    {     
        #region BULLET --BULLETI OLUÞTURDUK-object pool
        isshooting = true;
        
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;



        yield return new WaitForSeconds(cooldown);
        isshooting = false;
        cooldown -= cooldownDecreaseRate;

        // Minimum cooldown deðerini kontrol et
        if (cooldown < minCooldown)
        {
            cooldown = minCooldown;
        }
        #endregion 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemybullet"))
        {
            Debug.Log("hit;");
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            takedamage(25f);
            efectsbullet();
           


        }
        if (collision.gameObject.CompareTag("asteroid"))
        {
            Debug.Log("asteroid hit");
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            takedamage(100f);
            efects();
            Time.timeScale = 0f;
            

        }
        if (collision.gameObject.CompareTag("health"))
        {
            Debug.Log("can");
            collision.gameObject.SetActive(false);
            addhealth(25);

        }

    }

    public void takedamage(float amount)
    {
        health -= amount;
        healthSlider.value = health;    
        if (health == 0)
        {
            efects();
            Time.timeScale = 0f; // Oyunu durdur
            gameOverPanel.SetActive(true);
        }
        
    }
 
    public void efects()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void efectsbullet()
    {
        GameObject effect=Instantiate(htiprefab, transform.position, Quaternion.identity, transform.parent);
        Destroy(effect, effectduraction);

    }

    public void addhealth(int amount)
    {
        if (health < 100)
        {

            health += amount;
            if (health >= 100)
            {
                health = 100;
                UIMANAGER.updatescore(100);
            }
            healthSlider.value = health;
           
        }

    }



}
