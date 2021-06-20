using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShotandLife : MonoBehaviour
{
    [SerializeField] GameObject PlayerBullet;

    [SerializeField] GameSystem _GameSystem;


    //�v���C���[�̃_���[�W����
    //�v���C���[�ɒe���ڐG�������Ă��鎞��
    float PlayerTriggerTime = 0f;

    //�v���C���[���e�ɐڐG�������ă_���[�W���󂯂Ȃ�����
    float PlayerTriggerTimeLimit = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Instantiate(PlayerBullet, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerTriggerTime += Time.deltaTime;

        if(other.gameObject.tag == "Enemy" && PlayerTriggerTime <= PlayerTriggerTimeLimit)
        {
            _GameSystem.PlayerLifeLost(10);
        }

        PlayerTriggerTime = PlayerTriggerTime >= PlayerTriggerTimeLimit ? 0f : PlayerTriggerTime;
    }

    

}
