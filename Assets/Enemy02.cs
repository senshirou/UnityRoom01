using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : EnemyBaseScript
{
    [SerializeField] GameObject CirclePoint;

    Rigidbody rb;

    GameSystem _GameSystem;

    float speed = 1.0f;

    float radius = 2.0f;

    float movex;

    float movez;

    // Start is called before the first frame update
    void Start()
    {
        _GameSystem = GameObject.Find("----ScriptSystemSpace----").GetComponent<GameSystem>();

        rb = GetComponent<Rigidbody>();

        EnemyLife = 5;

        EnemyLifeLost = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movex = radius * Mathf.Sin(Time.time * speed);
        movez = radius * Mathf.Cos(Time.time * speed);

        rb.MovePosition(new Vector3(CirclePoint.transform.position.x + movex, transform.position.y, CirclePoint.transform.position.z + movez));


    }

    void OnDestroy()
    {
        _GameSystem.AddPoint(300);

    }


    private void OnTriggerEnter(Collider other)
    {
        EnemyLife = other.gameObject.tag == ("Bullet") ? EnemyLife -= EnemyLifeLost : EnemyLife;

        if (EnemyLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
