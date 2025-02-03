using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BoxControl manager = FindObjectOfType<BoxControl>();
        TandomObjectSpawner List = FindObjectOfType<TandomObjectSpawner>();
        if(manager!=null)
        {
            manager.RemoveClone(other.gameObject,List.GetSpawnedObjects());
        }
        
    }
}
