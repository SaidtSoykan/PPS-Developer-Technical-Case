using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour
{
    public GameObject tutorialText, tutorialText2;
    void Start()
    {
        tutorialText.SetActive(true);
        tutorialText2.SetActive(true);
    }
    void LateUpdate()
    {
        if (tutorialText.activeSelf && Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3"))
        {
            tutorialText.SetActive(false);
        }
        if(tutorialText2.activeSelf && Input.GetKeyDown("4") || Input.GetKeyDown("5") || Input.GetKeyDown("6"))
        {
            tutorialText2.SetActive(false);
        }
    }
}
