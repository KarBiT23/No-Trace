using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    RaycastHit hit;
    public GameObject MermiCikisNoktasi;
    public bool AtesEdebilir;
    float GunTimer;
    public float TaramaHizi;
    public ParticleSystem MuzzleFlash;
    AudioSource SesKaynak;
    public AudioClip AtesSesi;
    public float Menzil;
    public Recoil recoil;

    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && AtesEdebilir && Time.time > GunTimer)
        {
            Shoot(); // 🔄 Metot adını değiştirdik
            GunTimer = Time.time + TaramaHizi;
            recoil.Fire();
        }
    }

    void Shoot()
    {
        if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out hit, Menzil))
        {
            MuzzleFlash.Play();

            if (AtesSesi != null && SesKaynak != null)
            {
                SesKaynak.clip = AtesSesi;
                SesKaynak.Play();
            }

            Debug.Log("Vurulan nesne: " + hit.transform.name);
        }
    }
}
