using System;
using System.Collections.Generic;
using UnityEngine;


public class BallStopper : MonoBehaviour
{
    [SerializeField] GameObject cue;
    [SerializeField] float minSpeed;
    [SerializeField] int stopSpeed;

    public List<GameObject> ballsRbList = new List<GameObject>();

    public int numberOfBalls;
    public GameObject[] ballsRb;
    private bool cueShown = false;

    private void Start()
    {
        ballsRb = GameObject.FindGameObjectsWithTag("Ball");
        for (int i = 0; i < ballsRb.Length; i++)
        {
            ballsRbList.Add(ballsRb[i]);
        }
    }

    void Update()
    {
        CheckBallSpeedAndShowCue();
    }

    void CheckBallSpeedAndShowCue()
    {
        if (CheckBallSpeed())
        {
            if (!cueShown)
            {
                ShowCue();
                cueShown = true;
            }
        }
        else
        {
            cueShown = false;
        }
    }

    bool CheckBallSpeed()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            float speed = ballsRbList[i].GetComponent<Rigidbody>().velocity.magnitude;
            if (Math.Abs(speed - stopSpeed) >= 0.01f)
            {
                return false;
            }
        }
        return true;
    }

    void ShowCue()
    {
        cue.SetActive(true);
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
            ballsRbList[i].GetComponent<Rigidbody>().Sleep();
        }
    }

    bool BallChecking(int i)
    {
        float speed = ballsRbList[i].GetComponent<Rigidbody>().velocity.magnitude; // find gameobject`s speed.
        return speed < minSpeed;
    }
}
