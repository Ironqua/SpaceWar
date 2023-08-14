using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshipmove : MonoBehaviour
{

    public float movementSpeed = 0.5f; 
    private float direction = 3f; 

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        // Gemiyi belirli bir h�z ve y�nle hareket ettirme
        Vector3 newPosition = transform.position + new Vector3(movementSpeed * direction * Time.deltaTime, 0f, 0f);
        transform.position = newPosition;

        // E�er gemi sahnenin s�n�rlar�na ula��rsa y�n� tersine �evirme
        if (newPosition.x > 3f || newPosition.x < -3f)
        {
            direction *= -1f;
        }
    }
}


