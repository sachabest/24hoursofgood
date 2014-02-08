using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SiteDropper : MonoBehaviour {

    private const int DISTANCE_MAX = 10;
    public DataManager data;
    public bool shouldDrop;
    private int currentIndex;
  
	// Use this for initialization
	void Start () {
	}
    public IEnumerator Drop()
    {
        Debug.Log("In drop method");
        if (shouldDrop)
        {
            Debug.Log("Dropping");
            List<FallingSite> dudes = data.downloadedSites;
            foreach (FallingSite androidDude in dudes)
            {
                float difference = (float)Random.Range(-1.0f, 1.0f) * DISTANCE_MAX; ;
                androidDude.transform.position = new Vector2(difference, androidDude.transform.position.y);
                androidDude.gameObject.rigidbody2D.isKinematic = false;
                androidDude.rigidbody2D.gravityScale = Random.Range(0.3f, 0.8f);
                yield return new WaitForSeconds(3.0f);
            }
        }
        shouldDrop = false;
        yield return null;
        
    }
	// Update is called once per frameu
	void Update () {
	}
}
