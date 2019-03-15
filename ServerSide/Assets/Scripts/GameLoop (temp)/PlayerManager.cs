using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private int playerAmount;

    public List<int> charIndex;
    public GameObject[] characters;

    private static PlayerManager manager;


	void Start () {
        //manager = this;
        DontDestroyOnLoad(this);
	}


    // DEBUG TEST CHAR LIST!!
    public void charIndexUpdate()
    {
        for(int i = 0; i < charIndex.Count; i++)
        {
            Debug.Log("Character Index in list: " + charIndex[i]);
        }
        if(charIndex.Count == 0)
        {
            Debug.Log("Empty");
        }
    }
}
