﻿using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class DataManager : MonoBehaviour {

    public const int MASS_MODIFIER = 2;
    public const int MAX_ENTRIES = 25;
    public const string websiteToCheck = "http://google.com";
    public JSONObject downloadedJSON;
    public List<FallingSite> downloadedSites;
    private float downloadProgress;
    public bool downloading;
    public SiteDropper dropper;
    public SiteCollector collector;
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
                string[] split = Regex.Split(line, " : ");
                if (split.Length > 1)
                {
                    line = split[1];
                    line = line.Trim();
                    if (!line.Contains("http"))
                        continue;
                    GameObject prefab;
                    int random = Random.Range(0, 100);
                    if (random < 30) {
                        prefab = (GameObject)Instantiate(Resources.Load("RedDroid"));
                    }
                    else if (random < 60) {
                        prefab = (GameObject)Instantiate(Resources.Load("YellowDroid"));
                    }
                    else {
                        prefab = (GameObject)Instantiate(Resources.Load("FallingSitePrefab"));
                    }
                    FallingSite toAdd = prefab.GetComponent<FallingSite>();
                    toAdd.siteURL = line;
                    toAdd.value = random;
                    prefab.rigidbody2D.isKinematic = true;
                    prefab.rigidbody2D.gravityScale = 0.0f;
                    prefab.transform.position = new Vector2(0, 30);
                    toAdd.collector = collector;
                    downloadedSites.Add(toAdd);
                    count++;
                }
            }
        }
        stream.Close();
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
