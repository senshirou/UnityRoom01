using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float BulletSpeed = 0.1f;
    GameSystem _GameSystem;

    // Start is called before the first frame update
    void Start()
    {
        _GameSystem = GameObject.Find("----ScriptSystemSpace----").GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * BulletSpeed;
        Invoke(nameof(DestroyPenalty), 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Enemy")
       {
            Destroy(gameObject);
       }
    }

    //4�b��ɃI�u�W�F�N�g��j�󂵂ēG�ɓ�����Ȃ��y�i���e�B�[���s
    void DestroyPenalty()
    {
        _GameSystem.PointRateDown();
        Destroy(gameObject);
    }
}
