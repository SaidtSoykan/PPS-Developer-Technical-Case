using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour
{
    public GameObject tutorialText;
    void Start()
    {
        tutorialText.SetActive(true);
    }
    void LateUpdate()
    {
        if (tutorialText.activeSelf && Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3"))
        {
            tutorialText.SetActive(false);
        }
    }
}
