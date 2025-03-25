using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject levelOnePrefab; // Reference to the prefab of LevelOne
    private GameObject currentLevelOne; // Reference to the currently instantiated LevelOne

    public GameObject levelTwoPrefab;

     private GameObject currentLevelTwo; // Reference to the currently instantiated LevelOne

    public static GameManager Instance { get; private set; }

    public GameObject ShootingGameHomePage;

    public GameObject portfolioPage;

      public GameObject shootingGameLevelSelectPage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set the Singleton instance
         //   DontDestroyOnLoad(gameObject); // Optional: Keep this object across scenes
        }
        else
        {
         //   Destroy(gameObject); // Destroy duplicate instances
        }
    }
    



    // Instantiate the LevelOne GameObject
    public void LevelOneInstantiate()
    {
        if (levelOnePrefab != null && currentLevelOne == null)
        {
            currentLevelOne = Instantiate(levelOnePrefab, levelOnePrefab.transform.position, levelOnePrefab.transform.rotation);
        }
        else
        {
            Debug.LogWarning("LevelOne is already instantiated or prefab is not assigned.");
        }
    }
     public void LevelTwoInstantiate()
    {
        if (levelTwoPrefab!= null && currentLevelTwo == null)
        {
            currentLevelTwo = Instantiate(levelTwoPrefab, levelTwoPrefab.transform.position, levelTwoPrefab.transform.rotation);
        }
        else
        {
            Debug.LogWarning("LevelOne is already instantiated or prefab is not assigned.");
        }
    }

    // Disable the currently instantiated LevelOne and reinstantiate it
    public void LevelOneReInstantiate()
    {
        GameObject[] floatingTexts = GameObject.FindGameObjectsWithTag("Text");
        foreach (GameObject floatingText in floatingTexts)
        {
            Destroy(floatingText);
        }

        // Destroy all objects with the name "DemonEye(Clone)"
        GameObject[] demonEyes = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject demonEye in demonEyes)
        {
            Destroy(demonEye);
        }


        // If LevelOne is already instantiated, destroy it
        if (currentLevelOne != null)
        {
            Destroy(currentLevelOne);
        }

        // Instantiate a new LevelOne from the prefab
        currentLevelOne = Instantiate(levelOnePrefab, levelOnePrefab.transform.position, levelOnePrefab.transform.rotation);

         Debug.Log("LevelOne has been reset and re-instantiated.");
    }
     public void LevelTwoReInstantiate()
    {
        GameObject[] floatingTexts = GameObject.FindGameObjectsWithTag("Text");
        foreach (GameObject floatingText in floatingTexts)
        {
            Destroy(floatingText);
        }

        // Destroy all objects with the name "DemonEye(Clone)"
        GameObject[] demonEyes = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject demonEye in demonEyes)
        {
            Destroy(demonEye);
        }


        // If LevelOne is already instantiated, destroy it
        if (currentLevelTwo != null)
        {
            Destroy(currentLevelTwo);
        }

        // Instantiate a new LevelOne from the prefab
        currentLevelTwo = Instantiate(levelTwoPrefab, levelTwoPrefab.transform.position, levelTwoPrefab.transform.rotation);

         Debug.Log("LevelOne has been reset and re-instantiated.");
    }

    public void shootingGameHomePage()
    {
        // shootingGameRestartPageDisable.SetActive(false);
        portfolioPage.SetActive(true);
        ShootingGameHomePage.SetActive(true);
    }

    public void shootingPageDisable()
    {
        ShootingGameHomePage.SetActive(false);
    }
    
    public void HomePage()
    {
        // shootingGameRestartPageDisable.SetActive(false);
        portfolioPage.SetActive(true);
       
    }
    public void DestroyLevelOne()
    {
        // Destroy all objects with the tag "Text"
        GameObject[] floatingTexts = GameObject.FindGameObjectsWithTag("Text");
        foreach (GameObject floatingText in floatingTexts)
        {
            Destroy(floatingText);
        }

        // Destroy all objects with the tag "Enemy"
        GameObject[] demonEyes = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject demonEye in demonEyes)
        {
            Destroy(demonEye);
        }

         GameObject[] Bulls = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bulls in Bulls)
        {
            Destroy(bulls);
        }
       
        // Destroy the currently instantiated LevelOne
         if (currentLevelOne != null)
        {
            Destroy(currentLevelOne);
          //  Destroy(currentLevelTwo);
        }

        Debug.Log("LevelOne and all related objects have been destroyed.");
    }
     public void DestroyLevelTwo()
    {
        // Destroy all objects with the tag "Text"
        GameObject[] floatingTexts = GameObject.FindGameObjectsWithTag("Text");
        foreach (GameObject floatingText in floatingTexts)
        {
            Destroy(floatingText);
        }

        // Destroy all objects with the tag "Enemy"
        GameObject[] demonEyes = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject demonEye in demonEyes)
        {
            Destroy(demonEye);
        }

         GameObject[] Bulls = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bulls in Bulls)
        {
            Destroy(bulls);
        }
       
        // Destroy the currently instantiated LevelOne
         if (currentLevelTwo != null)
        {
            Destroy(currentLevelTwo);
           // Destroy(currentLevelOne);
        }

        Debug.Log("LevelOne and all related objects have been destroyed.");
    }

    public void LevelPage()
    {
        portfolioPage.SetActive(true);
        shootingGameLevelSelectPage.SetActive(false);
        DestroyLevelOne();
        
    }
    public void LevelPage2()
    {
        portfolioPage.SetActive(true);
        shootingGameLevelSelectPage.SetActive(false);
        
        DestroyLevelTwo();
    }
    
}
