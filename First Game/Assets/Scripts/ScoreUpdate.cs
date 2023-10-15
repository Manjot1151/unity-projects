using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public Camera cam;

    public static int score;
    Text textObj;
    void Awake()
    {
        score = 0;
        textObj = GetComponent<Text>();
    }
    void FixedUpdate()
    {

        if (!Bird.isDead)
            textObj.text = score.ToString();
        else
        {
            textObj.alignment = TextAnchor.MiddleCenter;
            textObj.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 5);
            textObj.text = "Score: " + score + "\n<size=50><i>Press space to restart!</i></size>";
        }
    }
}
