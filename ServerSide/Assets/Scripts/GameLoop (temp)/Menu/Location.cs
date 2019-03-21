using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField] private string locationName;
    [SerializeField] private Transform cameraLocation;
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] private Transform[] targetLocations;

    //public Statement[] statements;

    public bool isActive = false;

    public string GetName()
    {
        //name = this.gameObject.name;
        return locationName;
    }

    public Vector3[] GetSpawnPosition()
    {
        Vector3[] locations = new Vector3[spawnLocations.Length];
        for(int i = 0; i < spawnLocations.Length; i++)
        {
            locations[i] = spawnLocations[i].position;
        }
        return locations;
    }

    public Vector3[] GetTargetLocation()
    {
        Vector3[] locations = new Vector3[targetLocations.Length];
        for(int i = 0; i < targetLocations.Length; i++)
        {
            locations[i] = targetLocations[i].position;
        }
        return locations;
    }

    public Vector3 GetCameraLocation()
    {
        return cameraLocation.position;
    }
}
