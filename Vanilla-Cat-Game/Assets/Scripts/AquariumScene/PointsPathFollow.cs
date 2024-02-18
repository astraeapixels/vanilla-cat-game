using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPathFollow : MonoBehaviour
{
    // Start is called before the first frame update
[Serialize Field] GameObject[] objectsToSpawn;


private int specificObject;
Ok so let’s say you have your array of game objects, you can use the Instantiate() function to spawn one in the scene. So it might look something like this:

[Serialize Field] GameObject[] objectsToSpawn;

// create the array and fill it in the inspector (fill it with objects from the assets folder, not the hierarchy)

private int specificObject;

// create an int variable that you can use to specify which object in the array you want to spawn
void Start(){
    objectsToSpawn = GameObject.FindWithTag ("Fish");
}
private void SpawnObject()

{

specificObject = 17;

// assign a number (x) to the int variable

Instantiate(objectsToSpawn[specificObject], spawnPosition, spawnRotation);

// use the instantiate method to spawn the object. Note: you need to reference the array and pass in the int to specify which thing in the array you want (in this case it’s whatever ‘x’ is). Also with the instantiate method you need to give it a position and rotation.

}
}
