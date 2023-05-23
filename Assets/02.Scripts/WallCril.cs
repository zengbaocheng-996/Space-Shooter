using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCril : MonoBehaviour
{
    public GameObject sparkEffect;
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            GameObject spark=(GameObject)Instantiate(sparkEffect, coll.transform.position, Quaternion.identity);
            Destroy(spark,spark.GetComponent<ParticleSystem>().duration+0.2f);
            Destroy(coll.gameObject);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
