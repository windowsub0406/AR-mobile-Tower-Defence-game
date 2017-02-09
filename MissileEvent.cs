using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MissileEvent : MonoBehaviour {
    public Text SCOREText = null;
    int total_score = 0;
    public string tmp_score;
    // Use this for initialization
    void Start()
    {
        SCORE_Manager(0);
    }

    public void SCORE_Manager(int score)
    {
        total_score += score;
        tmp_score = total_score.ToString();
        SCOREText.text = "SCORE : " + tmp_score;
    }
}
