using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;

    public Transform firePos;

    public AudioClip fireSfx;
    private AudioSource source = null;
    public MeshRenderer muzzleFlash;
    void Fire()
    {
        CreateBullet();
        source.PlayOneShot(fireSfx,0.9f);
        StartCoroutine(this.ShowMuzzleFlash());
    }

    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
    }

    IEnumerator ShowMuzzleFlash()
    {
        float scale = Random.Range(1.0f, 2.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale;
        Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
        muzzleFlash.transform.localRotation = rot;
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.01f, 0.03f));
        muzzleFlash.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis("Fire1")==1.0f
        // Input.GetKeyDown(KeyCode.JoystickButton5)
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            Fire();
        }
    }
}
