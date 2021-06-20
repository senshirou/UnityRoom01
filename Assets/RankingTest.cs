using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingTest : MonoBehaviour
{

    int numberone =0;
    int numberoner;


    // Start is called before the first frame update
    void Start()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("first", numberone);
        //PlayerPrefs.Save();
        Debug.Log("Save" + numberone);
    }

    public void LoadData()
    {
        Debug.Log("Load" + PlayerPrefs.GetInt("first", -1));
    }

    public void Keisan()
    {

    }
}
