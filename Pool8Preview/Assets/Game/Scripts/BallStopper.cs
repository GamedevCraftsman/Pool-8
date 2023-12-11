using System.Globalization;
using UnityEngine;

public class BallStopper : MonoBehaviour
{
    [SerializeField] GameObject[] ballRb;
    [SerializeField] GameObject cue;
    [SerializeField] int numberOfBalls = 16;
    [SerializeField] float minSpeed = 1;
    private void Start()
    {
        ballRb = GameObject.FindGameObjectsWithTag("Ball");
    }
    void Update()
    {
        
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
            if (SpeedCheck(i))
            {
                ballRb[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }

    bool SpeedCheck(int i)
    {
        float speed = ballRb[i].GetComponent<Rigidbody>().velocity.magnitude; // find gameobject`s speed.
        return speed < minSpeed ? true:false;
    }
}
