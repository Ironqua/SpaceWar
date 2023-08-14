    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    private float speed = 10;


    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime); // merminin  hareketi

        if (transform.position.y < -8) // bullet y deðerini geçtikten sonra false olur ve gitmeye devam etmez
        {
            Destroy(gameObject);
        }
    }

    
}
