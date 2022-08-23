using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fire : MonoBehaviour
{
    RaycastHit hit;
    public ParticleSystem flash;
    AudioSource ssound;
    public AudioClip fireSound, readySound;
    public float range;
    private static int bulletNumber = 0, hitNumber = 0;
    public TextMeshProUGUI usedBullets, hits;

    void Start()
    {
        ssound = GetComponent<AudioSource>();
        ssound.clip = readySound;
        ssound.Play();
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            fire();
        }
        usedBullets.text = "Bullets: " + bulletNumber;
        hits.text = "Hits: " + hitNumber;
    }
    void OnEnable()
    {
        ssound.clip = readySound;
        ssound.Play();
    }
    void fire()
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
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Target")
            {
                Debug.Log(hit.transform.name);
                hitNumber += 1;
            }
            
        }
            
    }
}
