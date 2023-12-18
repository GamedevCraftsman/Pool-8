using System.Collections;
using UnityEngine;

public class CueBlow : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] GameObject cue;
    [SerializeField] int waitForSeconds;
    [SerializeField] Transform ballPoint;
    [SerializeField] int mouseButton;
    [SerializeField] int stopSpeed;

    GameObject ballStopper;
    Rigidbody cueRb;
    void Start()
    {
        cueRb = GetComponent<Rigidbody>();
        ballStopper = GameObject.FindGameObjectWithTag("Ball Stopper");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            BlowBall();
            StartCoroutine(BallStop());
        }
    }

    void BlowBall()
    {
        HideCue();
        Vector3 hitDirection = ballPoint.transform.right;
        hitDirection = new Vector3(hitDirection.x, 0, hitDirection.z).normalized;
        cueRb.AddForce(hitDirection * power, ForceMode.Impulse);
    }

    void HideCue()
    {
        cue.SetActive(false);
    }

    IEnumerator BallStop()
    {
        yield return new WaitForSeconds(waitForSeconds);
        ballStopper.GetComponent<BallStopper>().BallSpeedCheckAndStop();

        for (int i = 0; i < NumberOfBalls(); i++)
        {
            if (CheckBallSpeed(i))
            {
                yield return new WaitForSeconds(waitForSeconds);
                ballStopper.GetComponent<BallStopper>().BallSpeedCheckAndStop();
            }
        }
    }

    bool CheckBallSpeed(int i)
    {
        return ballStopper.GetComponent<BallStopper>().ballsRbList[i].GetComponent<Rigidbody>().velocity.magnitude != stopSpeed;
    }

    int NumberOfBalls()
    {
        return ballStopper.GetComponent<BallStopper>().numberOfBalls;
    }
}
