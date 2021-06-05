using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float BulletSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * BulletSpeed;
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Enemy")
       {
            Destroy(gameObject);
       }
    }
}
