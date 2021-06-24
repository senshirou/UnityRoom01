using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCube : MonoBehaviour
{
    GameSystem _GameSystem;

    float EnemySpeedRate = -0.04f;

    float EnemyLife = 3;

    float EnemyLifeLost = 1;

    int EnemyPoint = 100;

    delegate void Dead();



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

    

    private void OnTriggerEnter(Collider other)
    {
        EnemyLife = other.gameObject.tag == ("Bullet") ? EnemyLife -= EnemyLifeLost : EnemyLife;
        
        if(other.gameObject.tag == "EnemyDeadPoint")
        {
            Destroy(gameObject);
        }

        else if (EnemyLife <= 0)
        {
            DestroyEnemy();
        }

        else
        {
            //‰½‚à‚µ‚È‚¢
        }
    }

    void DestroyEnemy()
    {
        _GameSystem.AddPoint(EnemyPoint);
        Destroy(gameObject);
    }

    void Des2()
    {

    }
}
