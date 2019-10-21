using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    ScoreBoard scoreBoard;


    // Start is called before the first frame update
    void Start()
    {
        AddMeshCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();

    }

    private void AddMeshCollider()
    {
        Collider col = gameObject.AddComponent<MeshCollider>(); //Adds a MeshCollider to the gameObject
        gameObject.AddComponent<MeshCollider>().convex = true;//Adds convex to the mesh collider
        col.isTrigger = false;// Sets the colliders trigger to false, this also keeps spitting on nullreferenceexceptions
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnParticleCollision(GameObject enemy)
    {
        scoreBoard.AddScore(scorePerHit);
        GameObject fx = Instantiate(deathFX,transform.position, Quaternion.identity);// Creates a Enemy Death FX prefab into the world
        fx.transform.parent = parent;
        Destroy(gameObject);
        

    }    
}
