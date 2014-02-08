using UnityEngine;
using System.Collections;

public class SiteDropper : MonoBehaviour {

    private const int DISTANCE_MAX = 10;
    public DataManager data;
  
	// Use this for initialization
	void Start () {
	}
    public void dropFoold()
    {
        foreach (FallingSite androidDude in data.downloadedSites)
        {
            float difference = (float) Random.Range(-1.0f, 1.0f) * DISTANCE_MAX; ;
            androidDude.transform.position = new Vector2(difference, androidDude.transform.position.y);
            androidDude.gameObject.rigidbody2D.isKinematic = false;
            androidDude.rigidbody2D.gravityScale = Random.Range(0.3f, 0.8f) * 1 / 10;
            Debug.Log(androidDude.rigidbody2D.gravityScale);
            Debug.Log("Difference " + difference);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
