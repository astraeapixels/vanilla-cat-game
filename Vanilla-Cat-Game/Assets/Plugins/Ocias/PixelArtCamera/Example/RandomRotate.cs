﻿using UnityEngine;

public class RandomRotate : MonoBehaviour {

    // Use this for initialization
    private void Start () {
		
	}

    // Update is called once per frame
    private void Update () {
		transform.Rotate(230.43f * Time.deltaTime * Random.value, 150.52f * Time.deltaTime * Random.value, 40.34f * Time.deltaTime * Random.value);	
	}
}
