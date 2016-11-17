﻿using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    public GameObject meteorPrefab = null;
    public float startXPosition;
    public float yPositionMax;
    private List<GameObject> meteors;
    private float elapsedTime = 0;

	// Use this for initialization
	void Start () {
        meteors = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1)
        {
            elapsedTime = 0;
            GameObject meteor = Instantiate<GameObject>(meteorPrefab);
            meteor.transform.position = new Vector3(startXPosition, Random.Range(-yPositionMax, yPositionMax), 0);
            meteors.Add(meteor);
        }

        foreach(var meteor in meteors)
        {
            meteor.transform.position += new Vector3(-0.1f, 0, 0);
        }
	}
}