﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class Stun : MonoBehaviour {

	public float _duration;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnTriggerEnter(Collider other)
	 {
		 if (other.gameObject.tag == "Player")
		 {
			other.GetComponent<Player_State>().Stun(_duration);
		 }
	 }
}
