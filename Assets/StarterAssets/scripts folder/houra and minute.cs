using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houraandminute : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    private float day = 86400; // seconds in a day

    void Update()
    {
        // Get the current time
        System.DateTime time = System.DateTime.Now;

        // Calculate the angles for the hour and minute hands
        float hourAngle = (time.Hour * 3600 + time.Minute * 60 + time.Second) / day * 360;
        float minuteAngle = (time.Minute * 60 + time.Second) / 3600 * 360;

        // Rotate the hour and minute hands
        hourHand.localRotation = Quaternion.Euler(0, 0, -hourAngle);
        minuteHand.localRotation = Quaternion.Euler(0, 0, -minuteAngle);
    }
}
