using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;

    private Transform tr;
    public Texture[] textures;

    private int hitCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        int idx = Random.Range(0, textures.Length);
        GetComponentInChildren<MeshRenderer>().material.mainTexture = textures[idx];
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BULLET")
        {
            Destroy(coll.gameObject);
            if (++hitCount >= 3)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        
        GameObject spark=(GameObject)Instantiate(expEffect, tr.position, Quaternion.identity);

        Collider[] colls = Physics.OverlapSphere(tr.position, 10.0f);
        foreach (Collider coll in colls)
        {
            Rigidbody rbody = coll.GetComponent<Rigidbody>();
            if (rbody != null)
            {
                rbody.mass = 1.0f;
                rbody.AddExplosionForce(1000.0f, tr.position,10.0f,300.0f);
            }
        }
        Destroy(spark,spark.GetComponent<ParticleSystem>().duration);

        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
