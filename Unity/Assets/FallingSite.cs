﻿using UnityEngine;
using System.Collections;

public class FallingSite : MonoBehaviour {

    public float value;
    public float mass;
    public string siteURL;
    public int id;
    public bool dropped;
    public SiteCollector collector;
    private bool hasBeenOnScreen;
    private float visibleDuration;

	// Use this for initialization
	void Start () {
        enabled = true;
        hasBeenOnScreen = false;
	}
    void OnBecameVisible()
    {
        enabled = true;
        hasBeenOnScreen = true;
        visibleDuration = Time.time;
    }
    void OnBecameInvisible()
    {
        visibleDuration = Time.time - visibleDuration;
        if (hasBeenOnScreen && visibleDuration > 1)
            enabled = false;
    }
    public void changeMass(float newMass)
    {
        mass = newMass;
        rigidbody2D.mass = newMass;
    }
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -20)
            DestroyImmediate(gameObject);
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
            ContactPoint2D contact = collision.contacts[0];
            FallingSite other = contact.collider.gameObject.GetComponent<FallingSite>();
            if (other != null)
            {
                if (hasBeenOnScreen && other.hasBeenOnScreen) 
                    collector.OnCollisionEnter2D(collision);
                /*
                collector.nextSlot.y += 1.5f;
                other.transform.parent = collector.transform;
                this.rigidbody2D.isKinematic = true;
                this.rigidbody2D.isKinematic = true;
                Vector2 oldPositon = new Vector2(other.transform.position.x, other.transform.position.y);
                Vector2 newPosition = collector.nextSlot;
                other.transform.position = Vector2.Lerp(oldPositon, newPosition, 0.5f);
                //site.transform.rigidbody2D.Sleep();
                /* Need to also update the collider on this object to include the bounds of
                 * the recently caught site */

            }
    }
}
