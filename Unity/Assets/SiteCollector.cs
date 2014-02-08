using UnityEngine;
using System.Collections.Generic;

public class SiteCollector : MonoBehaviour {

    private int numSites;
    public const float SPEED = 0.4f;
    public float value;
    public bool onLeftWall, onRightWall;
    private Stack<FallingSite> sites;
    public Vector3 nextSlot;
    public Camera camera;
    private Vector3 initialCameraPos;
    public DataManager data;

	// Use this for initialization
	void Start () {
        sites = new Stack<FallingSite>();
        nextSlot = new Vector3(3.3f, 1.9f, 0f);
        initialCameraPos = this.GetComponent<BoxCollider2D>().size;
	}
    void Update()
    {
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;   
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
        sites.Push(site);
        numSites++;
        value += site.value;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        FallingSite site = contact.collider.gameObject.GetComponent<FallingSite>();
        if (site != null)
        {
            Debug.Log("Hit the collector");
            site.GetComponent<BoxCollider2D>().enabled = false;
            site.rigidbody2D.isKinematic = true;
            site.transform.parent = this.transform;
            Debug.Log("NEXT SLOT: " + nextSlot);
            site.transform.localPosition = nextSlot;
            nextSlot.y += 3.8f;
            this.addSite(site);
            this.GetComponent<BoxCollider2D>().size += new Vector2(0f, 7.4f);
            if (sites.Count > 6)
                camera.transform.position += new Vector3(0, 1.5f, 0f);
            foreach (FallingSite obj in data.downloadedSites) {
                if (!obj.dropped && obj.transform.parent == null)
                {
                    Vector2 oldPos = obj.transform.position;
                    obj.transform.position = new Vector3(oldPos.x, oldPos.y + 1.5f);
                }
            }
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
