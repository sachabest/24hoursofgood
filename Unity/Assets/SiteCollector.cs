using UnityEngine;
using System.Collections.Generic;

public class SiteCollector : MonoBehaviour {

    private int numSites;
    public float value;
    private List<FallingSite> sites;

	// Use this for initialization
	void Start () {
        sites = new List<FallingSite>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void addSite(FallingSite site)
    {
        sites.Add(site);
        numSites++;
        value += site.value;
    }
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        FallingSite site = contact.otherCollider.gameObject.GetComponent<FallingSite>();
        if (site != null)
        {
            this.addSite(site);
            /* Need to also update the collider on this object to include the bounds of
             * the recently caught site */

        }
    }
}
