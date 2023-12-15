using System.Collections;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    [SerializeField] float secondsBeforeDelete;

    GameObject ballStopper;
    private void Start()
    {
        ballStopper = GameObject.FindGameObjectWithTag("Ball Stopper");
    }

    private void OnTriggerEnter(Collider other)
    {
        RemoveBallFromEverywhere(other.gameObject);
        StartCoroutine(BallDestroy(other.gameObject));
    }

    void RemoveBallFromEverywhere(GameObject ball)
    {
        ballStopper.GetComponent<BallStopper>().numberOfBalls--;
        ballStopper.GetComponent<BallStopper>().ballsRbList.Remove(ball);
    }

    IEnumerator BallDestroy(GameObject ball)
    {
        yield return new WaitForSeconds(secondsBeforeDelete);
        Destroy(ball);
    }
}
