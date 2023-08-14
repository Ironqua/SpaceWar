using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class objectpool : MonoBehaviour
{  
    [SerializeField]
    private Queue<GameObject> pooledobject; // listte kullanabilirdik---queue de kuyruk olu�turduk 
    public GameObject objectpoolPrefab;
    public int poolsize;
    private void Awake()
    {
        pooledobject = new Queue<GameObject>();   //�rnekledik 
        for(int i = 0; i < poolsize; i++)
        {
            GameObject obj =Instantiate(objectpoolPrefab); // mermiyi olu�turduk
            obj.SetActive(false);    
            pooledobject.Enqueue(obj); // �retti�imiz prefablar� s�raya soktuk koleksiyona ekledik
          
        }

    }

   public GameObject GetPooledObject()
    {
        // havuzdan �a��rmam�z i�in gerekli olan metot 
        GameObject obj=pooledobject.Dequeue();  // koleksiyondan ��kard�k 
        obj.SetActive(true); // aktif ettik 
        pooledobject.Enqueue(obj); // tekrar s�raya soktuk 
        return obj;
    }


}
    