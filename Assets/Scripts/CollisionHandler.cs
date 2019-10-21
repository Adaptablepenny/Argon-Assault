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
        StartDeathSequence();
        deathFX.SetActive(true);
    }

    void LoadLevel()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currScene);
    }
    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        Invoke("LoadLevel", levelLoadDelay);
        
        
    }
}
