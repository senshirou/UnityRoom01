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

    


    float NowScore = 0;
    float PointRate = 1.0f;
    float PointRateUp = 0.01f;


    

    

    // Start is called before the first frame update
    void Start()
    {
        PlayerLife.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerLife.value);
    }


    public void AddPoint(float Point)
    {
        
        PointRate += PointRateUp;
        NowScore += (Point * PointRate * (_Player.speed * 10));
       
        ScoreText.text = NowScore.ToString("F0");

    }

    public void PlayerLifeLost(float LifeLostPoint)
    {
        PlayerLife.value -= LifeLostPoint;
        if(PlayerLife.value == 0)
        {
            Destroy(PlayerObject);
        }
    }



}
