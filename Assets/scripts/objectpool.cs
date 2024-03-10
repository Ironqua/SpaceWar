using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class objectpool : MonoBehaviour
{  
    [SerializeField]
    private Queue<GameObject> pooledobject; 
    public GameObject objectpoolPrefab;
    public int poolsize;
    private void Awake()
    {
        pooledobject = new Queue<GameObject>();   
        for(int i = 0; i < poolsize; i++)
        {
            GameObject obj =Instantiate(objectpoolPrefab);
            obj.SetActive(false);    
            pooledobject.Enqueue(obj); 
          
        }

    }

   public GameObject GetPooledObject()
    {
      
        GameObject obj=pooledobject.Dequeue(); 
        obj.SetActive(true); 
        pooledobject.Enqueue(obj); 
        return obj;
    }


}
    
