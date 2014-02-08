using UnityEngine;
using System.Collections;

public class UserLoginPrompter : MonoBehaviour {

    private string logvinURL;
    private string username, password;
    public UILabel usernameLabel, passwordLabel;
	// Use this for initialization
	void Start ()
    {

	}
    public void processLogin()
    {
        this.username = usernameLabel.text;
        this.password = passwordLabel.text;

    }
	// Update is called once per frame
	void Update () {
	
	}
}
