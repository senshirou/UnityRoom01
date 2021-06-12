using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    internal float speed = 0.1f;

    float Movex;
    float Movez;

    //X���̈ړ�����
    float Limitx = 11f;

    //Z���̈ړ�����
    float Limitz1 = -2.0f;
    float Limitz2 = -14.5f;
    Vector3 PlayerMove;

    GameSystem _GameSystem;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMove = new Vector3(Movex, 0, Movez);
        _GameSystem = GameObject.Find("----ScriptSystemSpace----").GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Movex = Input.GetAxis("Horizontal") * speed;
        Movez = Input.GetAxis("Vertical") * speed;


        //�v���C���[�̓����𐧌�
        transform.position = transform.position.x >= Limitx ? new Vector3(Limitx, transform.position.y, transform.position.z) : transform.position += PlayerMove;
        transform.position = transform.position.x <= -Limitx ? new Vector3(-Limitx, transform.position.y, transform.position.z) : transform.position += PlayerMove;
        transform.position = transform.position.z >= Limitz1 ? new Vector3(transform.position.x, transform.position.y, Limitz1) : transform.position += PlayerMove;
        transform.position = transform.position.z <= Limitz2 ? new Vector3(transform.position.x, transform.position.y, Limitz2) : transform.position += PlayerMove;

        //�v���C���[�𓮂���
        transform.position += new Vector3(Movex, 0, Movez);

        Debug.Log(speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }

        else if(other.gameObject.tag == "SpeedUp")
        {
            
            speed += 0.1f;

            speed = speed >= 0.5f ? 0.4f : speed; 
            Destroy(other.gameObject);
        }

        else if(other.gameObject.tag == "SpeedDown")
        {
            speed -= 0.1f;
            speed = speed <= 0.1f ? 0.1f : speed;
            Destroy(other.gameObject);
        }

        else if(other.gameObject.tag == "Heart")
        {
            _GameSystem.RecoveryLife();
            Destroy(other.gameObject);
        }
    }
}
