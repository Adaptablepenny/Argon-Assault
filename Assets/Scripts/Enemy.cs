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
        gameObject.AddComponent<MeshCollider>().convex = true;
        col.isTrigger.Equals(false);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnParticleCollision(GameObject enemy)
    {
        Instantiate(deathFX,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }    
}
