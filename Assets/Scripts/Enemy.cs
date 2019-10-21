using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    // Start is called before the first frame update
    Collider col;
    void Start()
    {
        gameObject.AddComponent<MeshCollider>().convex = true; //Adds a MeshCollider component to the enemy ship and makes it convex
        col.isTrigger.Equals(false);// Sets the colliders trigger to false
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnParticleCollision(GameObject enemy)
    {
        Instantiate(deathFX,transform.position, Quaternion.identity);// Creates a Enemy Death FX prefab into the world
        Destroy(gameObject);
    }    
}
