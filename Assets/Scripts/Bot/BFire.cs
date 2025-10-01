using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bfire : MonoBehaviour
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
            //recoil.Fire();
        }
    }

    void Shoot()
    {
        if (Physics.Raycast(MermiCikisNoktasi.transform.position, MermiCikisNoktasi.transform.forward, out hit, Menzil))
        {
            Debug.Log("Vurulan nesne: " + hit.transform.name);

            // 🔥 Vurulan objede Health script'i varsa hasar ver
            CHealth health = hit.transform.GetComponent<CHealth>();
            if (health != null)
            {
                health.hesaplananHealth(25f); // hasarı buradan ver
            }


        }
    }
}