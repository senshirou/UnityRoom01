using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    GameSystem _GameSystem;

    float BulletSpeed = 0.1f;

    float BulletDestroyTimeLimit = 4f;

    float BulletDestroyTime = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        _GameSystem = GameObject.Find("----ScriptSystemSpace----").GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        BulletDestroyTime += Time.deltaTime;
        transform.position += transform.forward * BulletSpeed;
        if(BulletDestroyTime >= BulletDestroyTimeLimit)
        {
            _GameSystem.PointRateDown();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Enemy")
       {
            Destroy(gameObject);
       }
    }
}
