using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanging : MonoBehaviour
{
    public GameObject[] weapons;
    private int i;

    void Start()
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }

    void Update()
    {
        weaponChange();
    }
    void weaponChange()
    {
        if (Input.GetKeyDown("1"))
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            i = 0;
        }
        else if (Input.GetKeyDown("2"))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
            weapons[2].SetActive(false);
            i = 1;

        }
        else if (Input.GetKeyDown("3"))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(true);
            i = 2;
        }
    }
    void animationAndSound()
    {
        Animation anime = weapons[i].GetComponent<Animation>();
        anime.Play("Ready");
    }
}
