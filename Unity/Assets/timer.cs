using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    int seconds = 50;
    public UILabel label;
	// Use this for initialization
	void Start () {
       
	}
    void countdown()
    {
        seconds--;
    }
    void startTimer()
    {
        InvokeRepeating("countdown", 1.0f, 1.0f);
    }
	// Update is called once per frame
	void Update () {
        label.text = "0:" + seconds;
	}
}
