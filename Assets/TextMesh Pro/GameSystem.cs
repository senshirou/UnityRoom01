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

        //プレイヤーのライフ設定
        PlayerLife.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PointRate);
    }

    //敵を倒してポイントが上がった時の挙動
    //1.ポイントのレートが0.01あがる
    //2.スコアに加算されるポイントは敵キャラのポイント*ポイントレート*(プレイヤーのスピード*10)
    public void AddPoint(float Point)
    {
        

        PointRate += PointRateMoves;

        NowScore += (Point * PointRate * (_Player.speed * 10));
       
        ScoreText.text = NowScore.ToString("F0");
        PointRateText.text = PointRate.ToString("F2");

    }


    //プレイヤーのライフがゼロになるとプレイヤーが破壊される
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
