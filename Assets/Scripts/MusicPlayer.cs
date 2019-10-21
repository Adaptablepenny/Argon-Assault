using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    

    private void Awake()
    {

        //This could probably become a method, this just makes it if we load on level 1 we still get music
        //checks to see if there is more than 1 music player, if there is it will destroy one of them and let the other live
        //Savage.
       int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if(numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



   
}
