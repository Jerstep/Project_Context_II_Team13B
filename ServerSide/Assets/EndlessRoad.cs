using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoad : MonoBehaviour {

    //public List<GameObject> tilebleTilesObjects; // Needs at least 5 objects

    //private List<GameObject> avtive; // to check what is active

    public Transform startPos;
    public Transform endPos;
    public int speed;

    //private int amountAcive;

    private void Start()
    {
    }

    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);

        if(this.transform.position.x > endPos.position.x)
        {
            this.transform.position = startPos.position;
        }
    }

    //void InstantiateTile()
    //{
    //    int randomIndex = Random.Range(0, tilebleTilesObjects.Count);
    //    GameObject tile = Instantiate(tilebleTilesObjects[randomIndex], startPos, tilebleTilesObjects[randomIndex].transform.rotation);
    //}

    //void CheckTilePos()
    //{
    //    for(int i = 0; i < tilebleTilesObjects.Count; i++)
    //    {
    //        if(tilebleTilesObjects[i].transform.position.x > endPos.x)
    //        {
    //            DeactivateTile(i);
    //        }
    //    }
    //}

    //int RandomIndex()
    //{
    //    int index = Random.Range(0, tilebleTilesObjects.Count);
    //    return index;
    //}

    //void DeactivateTile(int index)
    //{
    //    tilebleTilesObjects[index].SetActive(false);
    //    tilebleTilesObjects[index].transform.position = startPos;
    //}

    //void ActivateTile(int index)
    //{
    //    tilebleTilesObjects[index].SetActive(true);
    //    tilebleTilesObjects[index].transform.position = startPos;
    //}
}
