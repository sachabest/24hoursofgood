using UnityEngine;
using System.Collections;

public class UserLoginPrompter : MonoBehaviour {

    private string logvinURL;
    private string username, password;
    public UIInput usernameLabel, passwordLabel;
    public UIWidget loginWidget;
    public SiteDropper dropper;
	// Use this for initialization
	void Start ()
    {
	}
    public void processLogin()
    {
        this.username = usernameLabel.value;
        this.password = passwordLabel.value;
        Destroy(loginWidget.gameObject, 0);
    }
    void drop()
    {
        dropper.shouldDrop = true;
        Debug.Log(dropper.shouldDrop);
        dropper.StartCoroutine("Drop");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
