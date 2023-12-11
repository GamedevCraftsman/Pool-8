using System.Globalization;
using UnityEngine;

public class BallStopper : MonoBehaviour
{
    [SerializeField] GameObject[] ballRb;
    [SerializeField] GameObject cue;
    [SerializeField] int numberOfBalls;
    [SerializeField] float minSpeed;
    private void Start()
    {
        ballRb = GameObject.FindGameObjectsWithTag("Ball");
    }
    void Update()
    {
        BallSpeedCheckAndStop();
        // Show cue:
        //for (int i = 0; i < 16; i++)
        //{
        //    float speed = ballRb[i].GetComponent<Rigidbody>().velocity.magnitude;
        //    if (speed == 0)
        //    {
        //        cue.SetActive(true);
        //    }
        //}

    }

    void BallSpeedCheckAndStop ()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {          
            if (BallChecking(i))
            {
                ballRb[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }

   bool BallChecking(int i)
    {
        float speed = ballRb[i].GetComponent<Rigidbody>().velocity.magnitude; // find gameobject`s speed.
        return speed < minSpeed;
    }
}
