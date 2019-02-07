using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    private Text text;
    public List<string> themes = new List<string>();
    public List<int> usedThemes;

    private int random;
    private bool pressed;

    public GameObject BG;

	// Use this for initialization
	void Start () {
        pressed = false;
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            if (pressed == false)
            {
                SetRandomText();
            }
        }
	}

    void SetRandomText()
    {
        random = Random.Range(0, themes.Count);

        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(-5, 5));
        BG.transform.rotation = randomRotation;
        this.transform.rotation = randomRotation;

        if(random >= 0 && random <= 5) // Blue
        {
            BG.GetComponent<Image>().color = new Color32(72, 83, 207, 255);
        }
        if(random >= 6 && random <= 13) // Green
        {
            BG.GetComponent<Image>().color = new Color32(104, 207, 71, 255);
        }
        if(random >= 14 && random <= 19) // Yellow
        {
            BG.GetComponent<Image>().color = new Color32(229, 186, 53, 255);
        }
        if(random >= 20 && random <= 25) // Red
        {
            BG.GetComponent<Image>().color = new Color32(198, 57, 47, 255);
        }
        text.text = themes[random].ToString();
        Debug.Log("It Worked");
    }
}
