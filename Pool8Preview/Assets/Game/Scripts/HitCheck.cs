using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HitCheck : MonoBehaviour
{
    [SerializeField] float secondsBeforeDelete;
    [SerializeField] Text scoreText;

    GameObject globalScore;
    GameObject ballStopper;
    void Start()
    {
        ballStopper = GameObject.FindGameObjectWithTag("Ball Stopper");
        globalScore = GameObject.FindGameObjectWithTag("Global Score");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            AddScore();
            RemoveBallFromEverywhere(other.gameObject);
            StartCoroutine(BallDestroy(other.gameObject));
        }
    }

    void RemoveBallFromEverywhere(GameObject ball)
    {
        ballStopper.GetComponent<BallStopper>().numberOfBalls--;
        ballStopper.GetComponent<BallStopper>().ballsRbList.Remove(ball);
    }

    void AddScore()
    {
        globalScore.GetComponent<GlobalScore>().score++;
        scoreText.text = Convert.ToString(globalScore.GetComponent<GlobalScore>().score);
    }

    IEnumerator BallDestroy(GameObject ball)
    {
        yield return new WaitForSeconds(secondsBeforeDelete);
        Destroy(ball);
    }
}
