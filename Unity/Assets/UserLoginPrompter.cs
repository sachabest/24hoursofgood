using UnityEngine;
using System.Collections; 

public class UserLoginPrompter : MonoBehaviour {

    private string logvinURL;
    private string  username, password;
    public UIInput usernameLabel, passwordLabel;
    public UIWidget loginWidget;
    public SiteDropper dropper;
    public Timer timer;

	// Use this for initialization
	void Start ()
    {
	}
    public void processLogin()
    {
        Debug.Log("Login button pushed");
      //  this.username = usernameLabel.value;
      //  this.password = passwordLabel.value;
        NGUITools.DestroyImmediate(loginWidget.gameObject);
        drop();
    }
    void drop()
    {
        dropper.shouldDrop = true;
        Debug.Log(dropper.shouldDrop);
        dropper.StartCoroutine("Drop");
        timer.startTimer();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
