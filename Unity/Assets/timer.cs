using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    int seconds = 50;
    public UILabel label;
    public Camera winCamera;
    public UILabel sitesList;
    public SiteCollector collector;
    public SiteDropper dropper;
    public bool printed = false;
	// Use this for initialization
	void Start () {
        winCamera.enabled = false;
	}
    void countdown()
    {
        seconds--;
    }
    public void startTimer()
    {
        InvokeRepeating("countdown", 1.0f, 1.0f);
    }
	// Update is called once per frame
	void Update () {
        label.text = "0:" + seconds;
        if (seconds == 0)
        {
            if (!printed) {
                StopAllCoroutines();
                CancelInvoke("countdown");
                dropper.shouldDrop = false;
                sitesList.text += "\n\n" + collector.value;
                
                winCamera.enabled = true;
             }
             printed = true;
        }
	}
}
