using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateArea : MonoBehaviour
{

    [SerializeField] GameObject InstantiateObject;

    [SerializeField] GameObject CubeEnemy02;

    [SerializeField] Vector3 InstantiateVector3;

    [SerializeField] GameObject SpeedUp;

    [SerializeField] GameObject SpeedDown;

    [SerializeField] GameObject LazerEnemy;


    float times01;
    float times02;
    float LazerEnemyTime;

    float SpeedTime;

    
    

    int AreaNumber;
    int SpeedUpX = 5;
    int SpeedDownX = -5;

    GameObject InstantiateAreas;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        times01 += Time.deltaTime;

        times02 += Time.deltaTime;

        SpeedTime += Time.deltaTime;

        LazerEnemyTime += Time.deltaTime;

        //Debug.Log(LazerEnemyTime);



        AreaNumber = Random.Range(-10, 10);


        if(times01 >= 1f)
        {
            Instantiate(InstantiateObject, new Vector3(AreaNumber,InstantiateVector3.y,InstantiateVector3.z),transform.rotation);
            times01 = 0f;
        }


        else if (times02 >= 10f)
        {
            Instantiate(CubeEnemy02, new Vector3(AreaNumber, InstantiateVector3.y, InstantiateVector3.z), transform.rotation);
            times02 = 5f;
        }

        else if(SpeedTime >= 30f)
        {
            Instantiate(SpeedUp, new Vector3(SpeedUpX, InstantiateVector3.y, InstantiateVector3.z), transform.rotation);
            Instantiate(SpeedDown, new Vector3(SpeedDownX, InstantiateVector3.y, InstantiateVector3.z), transform.rotation);
            SpeedTime = 6f;
        }

        else if(LazerEnemyTime >= 50)
        {
            Instantiate(LazerEnemy, new Vector3(AreaNumber, InstantiateVector3.y, InstantiateVector3.z), transform.rotation);
            LazerEnemyTime = 40f;

        }

        

        

        
    }
}
