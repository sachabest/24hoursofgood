using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour {

    public const string websiteToCheck = "http://google.com";
    public JSONObject downloadedJSON;
    private List<FallingSite> downloadedSites;
    private float downloadProgress;
    public bool downloading;

	// Use this for initialization
	void Start () {
	    
	}
    void startHTTPCheck()
    {

    }
    public void decodeJSON(string url)
    {
        downloading = true;
        WWW jsonPage = new WWW(url);
        while (!jsonPage.isDone)
        {
            downloadProgress = jsonPage.progress;
        }
        downloading = false;
        string json = System.Text.Encoding.Default.GetString(jsonPage.bytes);
        downloadedJSON = new JSONObject(json);
        
        foreach (JSONObject jsonSite in (downloadedJSON.list)) {
            FallingSite toAdd = new FallingSite();
            toAdd.siteURL = jsonSite.keys[0];
            toAdd.value = int.Parse(jsonSite.keys[1]);
            toAdd.mass = int.Parse(jsonSite.keys[2]);
            downloadedSites.Add(toAdd);
        }

    }
	// Update is called once per frame
	void Update () {
	
	}
}
