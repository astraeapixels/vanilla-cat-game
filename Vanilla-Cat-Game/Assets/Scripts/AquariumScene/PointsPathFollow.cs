using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] units;
    public GameObject unitPrefab;
    public int numUnits = 5;
    public Vector3 range = new Vector3(5, 5, 5);
  
    void Start()
    {
        units = new GameObject[numUnits];
        for (int i = 0; i < numUnits; i++)
        {
            Vector3 unitPos = new Vector3(Random.Range(-range.x,range.x),
                                          Random.Range(-range.y,range.y),
                                          Random.Range(0, 0));
            units[i] = Instantiate(unitPrefab, this.transform.position + unitPos, Quaternion.identity) as GameObject;
            units[i].GetComponent<UnitsForce>().manager = this.gameObject;
        }
    }
}