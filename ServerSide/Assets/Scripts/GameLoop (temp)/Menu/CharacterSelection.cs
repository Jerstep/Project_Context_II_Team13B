using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private Color charChosenColor = Color.gray;
    [SerializeField] private Color charFreeColor = Color.white;
    [SerializeField] private PlayerManager playerManager;

    private int characterIndex;
    public GameObject[] characters;

    public Image[] buttonColor;

    private void ChangeButtonColor(int colorIndex)
    {
        if(buttonColor[colorIndex].color != charChosenColor)
        {
            buttonColor[colorIndex].color = charChosenColor;
        }
        else
        {
            buttonColor[colorIndex].color = charFreeColor;
        }      
    }

    private void AddToCharIndex(int _charIndex)
    {
        if(!playerManager.charIndex.Contains(_charIndex))
        {
            playerManager.charIndex.Add(_charIndex);
        }
        else
        {
            playerManager.charIndex.Remove(_charIndex);
        }
    }

    public void CharButton(int index)
    {
        AddToCharIndex(index);
        ChangeButtonColor(index);
    }

    public void ConfirmSelection()
    {
        SceneManager.LoadScene("GameLoop");
    }
}
