using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerEnemy : EnemyBaseScript
{


    // Start is called before the first frame update
    void Start()
    {
        EnemyLife = 10;

        EnemyLifeLost = 1;

        EnemyPoint = 500;

        _Gamesystem = GameObject.Find("----ScriptSystemSpace----").GetComponent<GameSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyLife = other.gameObject.tag == ("Bullet") ? EnemyLife -= EnemyLifeLost : EnemyLife;

        if (EnemyLife <= 0)
        {
            DestroyEnemy();
        }

        if(other.gameObject.tag == "EnemyDeadPoint")
        {
            Destroy(gameObject);
        }

        else if(EnemyLife <= 0)
        {

        }
    }

    void DestroyEnemy()
    {
        _Gamesystem.AddPoint(EnemyPoint);
        Destroy(gameObject);
    }

    
}
