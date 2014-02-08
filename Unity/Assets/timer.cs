using UnityEngine;
using System.Collections;

public class imer : MonoBehaviour {

    int seconds = 50;
    public UILabel label;
	// Use this for initialization
	void Start () {
        InvokeRepeating("countdown", 1.0f, 1.0f);
	}
    void countdown()
    {
        seconds--;
    }

	// Update is called once per frame
	void Update () {
        label.text = "0:" + seconds;
	}
}
