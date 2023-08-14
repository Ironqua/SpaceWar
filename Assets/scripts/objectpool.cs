using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class objectpool : MonoBehaviour
{  
    [SerializeField]
    private Queue<GameObject> pooledobject; // listte kullanabilirdik---queue de kuyruk oluþturduk 
    public GameObject objectpoolPrefab;
    public int poolsize;
    private void Awake()
    {
        pooledobject = new Queue<GameObject>();   //örnekledik 
        for(int i = 0; i < poolsize; i++)
        {
            GameObject obj =Instantiate(objectpoolPrefab); // mermiyi oluþturduk
            obj.SetActive(false);    
            pooledobject.Enqueue(obj); // ürettiðimiz prefablarý sýraya soktuk koleksiyona ekledik
          
        }

    }

   public GameObject GetPooledObject()
    {
        // havuzdan çaðýrmamýz için gerekli olan metot 
        GameObject obj=pooledobject.Dequeue();  // koleksiyondan çýkardýk 
        obj.SetActive(true); // aktif ettik 
        pooledobject.Enqueue(obj); // tekrar sýraya soktuk 
        return obj;
    }


}
    