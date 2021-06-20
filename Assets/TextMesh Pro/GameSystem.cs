using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    [SerializeField] Slider PlayerLife;

    [SerializeField] Player _Player;

    [SerializeField] GameObject PlayerObject;

    [SerializeField] TextMeshProUGUI PointRateText;

    


    float NowScore = 0;
    float PointRate = 1.0f;
    float PointRateMoves = 0.01f;

    float PlayerLifeMove = 20;


    

    

    // Start is called before the first frame update

    
    void Start()
    {
        PointRateText.text = PointRate.ToString("F2");
        ScoreText.text = NowScore.ToString("F0");

        //�v���C���[�̃��C�t�ݒ�
        PlayerLife.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerLife.value);
    }

    //�G��|���ă|�C���g���オ�������̋���
    //1.�|�C���g�̃��[�g��0.01������
    //2.�X�R�A�ɉ��Z�����|�C���g�͓G�L�����̃|�C���g*�|�C���g���[�g*(�v���C���[�̃X�s�[�h*10)
    public void AddPoint(float Point)
    {
        
        PointRate += PointRateMoves;
        NowScore += (Point * PointRate * (_Player.speed * 10));
       
        ScoreText.text = NowScore.ToString("F0");
        PointRateText.text = PointRate.ToString("F2");

    }


    //�v���C���[�̃��C�t���[���ɂȂ�ƃv���C���[���j�󂳂��
    public void PlayerLifeLost(float LifeLostPoint)
    {
        PlayerLife.value -= LifeLostPoint;
        if(PlayerLife.value == 0)
        {
            Destroy(PlayerObject);
            RankingLoaderCall();
        }
    }

    public void PointRateDown()
    {
        PointRate = PointRate >= 1.01f ? PointRate -= PointRateMoves : 1.0f;
        PointRateText.text = PointRate.ToString("F2");
    }

    public void RecoveryLife()
    {
        PlayerLife.value += PlayerLifeMove;
    }

    public void RankingLoaderCall()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(NowScore);
    }


}
