using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HitCheck : MonoBehaviour
{
    [SerializeField] float secondsBeforeDelete;
    [SerializeField] Text scoreText;

    int score = 0;
    GameObject ballStopper;
    private void Start()
    {
        ballStopper = GameObject.FindGameObjectWithTag("Ball Stopper");
    }

    private void OnTriggerEnter(Collider other)
    {
        RemoveBallFromEverywhere(other.gameObject);
        AddScore();
        StartCoroutine(BallDestroy(other.gameObject));
    }

    void RemoveBallFromEverywhere(GameObject ball)
    {
        ballStopper.GetComponent<BallStopper>().numberOfBalls--;
        ballStopper.GetComponent<BallStopper>().ballsRbList.Remove(ball);
    }

    void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    IEnumerator BallDestroy(GameObject ball)
    {
        yield return new WaitForSeconds(secondsBeforeDelete);
        Destroy(ball);
    }
}
