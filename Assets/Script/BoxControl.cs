using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    public GameObject block;
    Rigidbody rigidbody;
    public Vector3 Default;
    public TandomObjectSpawner spawner;
    public event Action<int> OnObjectSpawned;

    int currentSpawnCount = 0;
    bool Use = false;
    // Start is called before the first frame update
    void Start()
    {
       
        rigidbody = this.GetComponent<Rigidbody>();
        Default = block.transform.position;
    }

    // Update is called once per frame
    private void OnEnable()
    {
        if(spawner!=null)
        {
            spawner.OnObjectSpawned += UpdateObjectSpawned;
        }
    }
    private void OnDisable()
    {
        if (spawner != null)
        {
            spawner.OnObjectSpawned -= UpdateObjectSpawned;
        }
    }
    void UpdateObjectSpawned(int count)
    {
        currentSpawnCount = count;
    }
    
    void Update()
    {
            transform.position += Vector3.back * 10 * Time.deltaTime;

        if(this.transform.position.z<=-30)
        {
            Destroy(this.gameObject);
        }
        
    }
}
