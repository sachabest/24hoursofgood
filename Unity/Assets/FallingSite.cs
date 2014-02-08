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
    public void changeMass(float newMass)
    {
        mass = newMass;
        rigidbody2D.mass = newMass;
    }
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.parent != null) {
            ContactPoint2D contact = collision.contacts[0];
            GameObject other = contact.collider.gameObject;
            if (other != null)
            {
                other.transform.parent = this.transform;
                this.rigidbody2D.Sleep();
                other.rigidbody2D.Sleep();
                //site.transform.rigidbody2D.Sleep();
                /* Need to also update the collider on this object to include the bounds of
                 * the recently caught site */

            }
        }
    }
}
