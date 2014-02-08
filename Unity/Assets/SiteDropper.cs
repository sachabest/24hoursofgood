using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SiteDropper : MonoBehaviour {

    private const int DISTANCE_MAX = 10;
    public DataManager data;
    public bool shouldDrop;
    private int currentIndex;
    public UILabel sitesList;
  
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
                if (shouldDrop)
                {
                    if (androidDude == null || androidDude.dropped || androidDude.siteURL == null) yield return new WaitForSeconds(0);
                    float difference = (float)Random.Range(-1.0f, 1.0f) * DISTANCE_MAX; ;
                    androidDude.transform.position = new Vector2(difference, androidDude.transform.position.y);
                    androidDude.gameObject.rigidbody2D.isKinematic = false;
                    androidDude.rigidbody2D.gravityScale = Random.Range(0.3f, 0.8f);
                    androidDude.dropped = true;
                    sitesList.text += "\n" + androidDude.value + "     ";
                    if (androidDude.value < 10)
                        sitesList.text += " ";
                    sitesList.text += androidDude.siteURL;
                }
                yield return new WaitForSeconds(3.0f);
            }
        }
        shouldDrop = false;
        yield return null;
        
    }
	// Update is called once per frameu
}
