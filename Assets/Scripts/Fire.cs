using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fire : MonoBehaviour
{
    RaycastHit hit;
    public ParticleSystem flash;
    public ParticleSystem bomb;
    public ParticleSystem smoke;
    AudioSource ssound;
    public AudioClip fireSound, readySound, bombSound, smokeSound;
    public float range;
    private static int bulletNumber = 0, hitNumber = 0;
    public TextMeshProUGUI usedBullets, hits;
    private bool bombType = false, fastType = false, smokeType = false;
    public GameObject bombButton, fastButton, smokeButton, explosion, fog;

    void Start()
    {
        ssound = GetComponent<AudioSource>();
        ssound.clip = readySound;
        ssound.Play();
    }
    
    void Update()
    {
        if (Input.GetKeyDown("4"))
        {
            if(bombType == false)
            {
                bombType = true;
                bombButton.SetActive(true);
            }
            else
            {
                bombType = false;
                bombButton.SetActive(false);
            }
            
        }
        else if (Input.GetKeyDown("5"))
        {
            if (fastType == false)
            {
                fastType = true;
                fastButton.SetActive(true);
            }
            else
            {
                fastType = false;
                fastButton.SetActive(false);
            }
        }
        else if (Input.GetKeyDown("6"))
        {
            if (smokeType == false)
            {
                smokeType = true;
                smokeButton.SetActive(true);
            }
            else
            {
                smokeType = false;
                smokeButton.SetActive(false);
            }
        }
        if (Input.GetMouseButton(0))
        {
            
            switch (this.tag)
            {
                case "Pistol":
                    PistolFire();
                    break;
                case "Shotgun":
                    ShotgunFire();
                    break;
                case "Machine":
                    MachineFire();
                    break;
            }
        }
        usedBullets.text = "Bullets: " + bulletNumber;
        hits.text = "Hits: " + hitNumber;
    }
    void OnEnable()
    {
        ssound.clip = readySound;
        ssound.Play();
    }
    void PistolFire()
    {
        if(bombType == true)
        {
            StartCoroutine(BombTime());
        }
        if(fastType == true)
        {
            FastTime();
        }
        if(smokeType == true)
        {
            StartCoroutine(SmokeTime());
        }
        if(bombType == false && fastType == false && smokeType == false)
        {
            MachineFire();
        }
    }
    void ShotgunFire()
    {
        Animation anime = this.GetComponent<Animation>();
        if (anime.IsPlaying("Fire"))
        {
            return;
        }
        bulletNumber += 5;
        flash.Play();
        ssound.clip = fireSound;
        ssound.Play();
        anime["Fire"].wrapMode = WrapMode.Once;
        anime.Play("Fire");
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range);
        if (hit.transform.CompareTag("Target"))
        {
            Debug.Log(hit.transform.name);
            hitNumber += 1;
        }
        for (int i = 0; i < 4; i++)
        {
            Vector3 position = new Vector3(Camera.main.transform.forward.x + Random.Range(-10.0f, 10.0f), Camera.main.transform.forward.y + Random.Range(-10.0f, 10.0f), Camera.main.transform.forward.z + Random.Range(-10.0f, 10.0f));
            Physics.Raycast(Camera.main.transform.position, position, out hit, range);
            if (hit.transform.CompareTag("Target"))
            {
                Debug.Log(hit.transform.name);
                hitNumber += 1;
            }
        }
    }
    void MachineFire()
    {
        Animation anime = this.GetComponent<Animation>();
        if (anime.IsPlaying("Fire"))
        {
            return;
        }
        bulletNumber += 1;
        flash.Play();
        ssound.clip = fireSound;
        ssound.Play();
        anime["Fire"].wrapMode = WrapMode.Once;
        anime.Play("Fire");
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range);
        if (hit.transform.CompareTag("Target"))
        {
            Debug.Log(hit.transform.name);
            hitNumber += 1;
        }
    }
    IEnumerator BombTime()
    {
        yield return new WaitForSeconds(3);
        Animation anime = this.GetComponent<Animation>();
        bulletNumber += 1;
        bomb.Play();
        ssound.clip = bombSound;
        ssound.Play();
        anime["Fire"].wrapMode = WrapMode.Once;
        anime.Play("Fire");
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range);
        Instantiate(explosion, hit.transform.position, Quaternion.identity);
        if (hit.transform.CompareTag("Target"))
        {
            Debug.Log(hit.transform.name);
            hitNumber += 1;
        }
    }
    void FastTime()
    {
        Animation anime = this.GetComponent<Animation>();
        bulletNumber += 1;
        flash.Play();
        ssound.clip = fireSound;
        ssound.Play();
        anime["Fire"].wrapMode = WrapMode.Once;
        anime.Play("Fire");
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range);
        if (hit.transform.CompareTag("Target"))
        {
            Debug.Log(hit.transform.name);
            hitNumber += 1;
        }
    }
    IEnumerator SmokeTime()
    {
        Animation anime = this.GetComponent<Animation>();
        bulletNumber += 1;
        smoke.Play();
        ssound.clip = smokeSound;
        ssound.Play();
        anime["Fire"].wrapMode = WrapMode.Once;
        anime.Play("Fire");
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range);
        Instantiate(fog, hit.transform.position, Quaternion.identity);
        if (hit.transform.CompareTag("Target"))
        {
            Debug.Log(hit.transform.name);
            hitNumber += 1;
        }
        yield return new WaitForSeconds(1);
    }
}
