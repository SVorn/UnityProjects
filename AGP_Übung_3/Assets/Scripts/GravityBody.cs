﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {

	public GravityAttractor attractor;
	private Transform planet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		attractor.Attract(planet);
	}
}
