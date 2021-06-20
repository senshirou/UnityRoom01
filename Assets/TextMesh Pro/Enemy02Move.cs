using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Move : MonoBehaviour
{
    [SerializeField] GameObject CubeEnemy;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * 0.01f;

        if(CubeEnemy == null)
        {
            Destroy(gameObject);
        }
    }
}
