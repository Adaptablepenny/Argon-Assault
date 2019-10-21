using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] float levelLoadDelay = 2f;
    
    void OnTriggerEnter(Collider ship)
    {
        StartDeathSequence();//Function to start a death sequence
        deathFX.SetActive(true);//Enables the GameObject attached to the script to give an explos VFX and SFX (plays on awake)
        //todo possibly make the explosion gameObject instatiate instead.
    }

    void LoadLevel()// Reloads the level
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene);
    }
    private void StartDeathSequence()//Calls the OnPlayerDeath function from the player controller
    {
        SendMessage("OnPlayerDeath");
        Invoke("LoadLevel", levelLoadDelay);//Calls the LoadLevel function after the set levelLoadDelay (2 seconds)
        
        
    }
}
