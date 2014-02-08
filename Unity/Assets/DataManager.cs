using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class DataManager : MonoBehaviour {

    public const int MASS_MODIFIER = 2;
    public const int MAX_ENTRIES = 10;
    public const string websiteToCheck = "http://google.com";
    public JSONObject downloadedJSON;
    public List<FallingSite> downloadedSites;
    private float downloadProgress;
    public bool downloading;
    public SiteDropper dropper;
	// Use this for initialization
	void Start () {
        decodeTXT("Assets/history.txt");
	}
    void startHTTPCheck()
    {

    }
    public void decodeTXT(string filename)
    {
        StreamReader stream = new StreamReader(filename);
        string line;
        int count = 0;
        while ((line = stream.ReadLine()) != null)
        {
            if (count > MAX_ENTRIES)
                break;
            if (line.Contains("URL"))
            {
                string[] split = line.Split(':');
                if (split.Length > 1)
                {
                    line = split[1];
                    line = line.Trim();
                    GameObject prefab = (GameObject)Instantiate(Resources.Load("FallingSitePrefab"));
                    FallingSite toAdd = prefab.GetComponent<FallingSite>();
                    toAdd.siteURL = line;
                    toAdd.value = Random.Range(0, 100);
                    prefab.rigidbody2D.isKinematic = false;
                    prefab.transform.position = new Vector2(0, 30);
                    downloadedSites.Add(toAdd);
                    count++;
                }
            }
        }
        stream.Close();
        dropper.dropFoold();
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
        /*
        foreach (JSONObject jsonSite in (downloadedJSON.list)) {
            FallingSite toAdd = new FallingSite();
            toAdd.siteURL = jsonSite.keys[0];
            toAdd.value = Random.Range(0, 100);
            downloadedSites.Add(toAdd);
        }
        */

    }
	// Update is called once per frame
	void Update () {
	
	}
}
