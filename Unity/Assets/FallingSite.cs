using UnityEngine;
using System.Collections;

public class FallingSite : MonoBehaviour {

    public float value { get; set; }
    public float mass { get; set; }
    public string siteURL { get; set; }
    public int id;

	// Use this for initialization
	void Start () {
	    
	}
    void changeMass(float newMass)
    {
        mass = newMass;
        rigidbody.mass = newMass;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
