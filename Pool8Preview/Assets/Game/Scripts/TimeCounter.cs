using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] Text timeText;

    void Update()
    {
        timeText.text = Convert.ToInt32(Time.timeSinceLevelLoad) + " ñ.";
    }
}
