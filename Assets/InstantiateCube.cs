using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCube : MonoBehaviour
{
    GameSystem _GameSystem;

    float EnemySpeedRate = -0.01f;

    float EnemyLife = 3;

    float EnemyLifeLost = 1;

    // Start is called before the first frame update
    void Start()
    {
        _GameSystem = GameObject.Find("----ScriptSystemSpace----").GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * EnemySpeedRate;
    }

    void OnDestroy()
    {
        _GameSystem.AddPoint(100);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyLife = other.gameObject.tag == ("Bullet") ? EnemyLife -= EnemyLifeLost : EnemyLife;
        
        if(EnemyLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
