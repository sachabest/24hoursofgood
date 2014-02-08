using UnityEngine;
using System.Collections.Generic;

public class SiteCollector : MonoBehaviour {

    private int numSites;
    public const float SPEED = 0.4f;
    public float value;
    public bool onLeftWall, onRightWall;
    private List<FallingSite> sites;

	// Use this for initialization
	void Start () {
        sites = new List<FallingSite>();
	}
    void Update()
    {
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftBorder + 4, rightBorder - 4), transform.position.y);
    }
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 position = this.transform.position;
	    if (Input.GetKey(KeyCode.LeftArrow) && !onLeftWall) {
            this.transform.position = new Vector2(-SPEED + position.x, position.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !onRightWall) {
            this.transform.position = new Vector2(SPEED + position.x, position.y);
        }
        if (Input.GetKey(KeyCode.RightArrow) && onLeftWall)
        {
            onLeftWall = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && onRightWall)
        {
            onRightWall = false;
        }
	}
    void addSite(FallingSite site)
    {
        sites.Add(site);
        numSites++;
        value += site.value;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        FallingSite site = contact.collider.gameObject.GetComponent<FallingSite>();
        if (site != null)
        {
            this.addSite(site);
            site.transform.parent = this.gameObject.transform;
            //site.transform.rigidbody2D.Sleep();
            /* Need to also update the collider on this object to include the bounds of
             * the recently caught site */

        }
        else if (contact.collider.gameObject.name.Equals("rightWall"))
        {
            onRightWall = true;
        }
        else if (contact.collider.gameObject.name.Equals("leftWall"))
        {
            onLeftWall = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        if (contact.collider.gameObject.name.Equals("rightWall"))
        {
            onRightWall = false;
        }
        else if (contact.collider.gameObject.name.Equals("leftWall"))
        {
            onLeftWall = false;
        }
    }
}
