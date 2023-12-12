using UnityEngine;

public class BallStopper : MonoBehaviour
{
    [SerializeField] GameObject cue;
    [SerializeField] float minSpeed;
    [SerializeField] int stopSpeed;

    public int numberOfBalls;
    public GameObject[] ballsRb;
    bool checkBalls = false;
    private void Start()
    {
        ballsRb = GameObject.FindGameObjectsWithTag("Ball");
    }
    void Update()
    {
        CheckBallSpeedAndShowCue();
    }

    void CheckBallSpeedAndShowCue()
    {
        CheckBallSpeed();
        ShowCue();
    }

    void CheckBallSpeed()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            float speed = ballsRb[i].GetComponent<Rigidbody>().velocity.magnitude;
            if (speed == stopSpeed)
            {
                checkBalls = true;
            }
            else
            {
                checkBalls = false;
                break;
            }
        }
    }

    void ShowCue()
    {
        if (checkBalls)
        {
            cue.SetActive(true);
        }
    }

    public void BallSpeedCheckAndStop()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            StopBalls(i);
        }
    }

    void StopBalls(int i)
    {
        if (BallChecking(i))
        {
            ballsRb[i].GetComponent<Rigidbody>().Sleep();
        }
    }

    bool BallChecking(int i)
    {
        float speed = ballsRb[i].GetComponent<Rigidbody>().velocity.magnitude; // find gameobject`s speed.
        return speed < minSpeed;
    }
}
