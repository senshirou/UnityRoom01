using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTest : MonoBehaviour
{
    [SerializeField] GameObject Parents1;
    [SerializeField] GameObject Parents2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Parents1 == null || Parents2 == null)
        {
            Destroy(gameObject);
        }
    }
}
