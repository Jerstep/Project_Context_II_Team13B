using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public Color charChosenColor = Color.gray;
    public Color charFreeColor = Color.white;

    private int characterIndex;
    public GameObject[] characters;
    public PlayerManager playerManager;

    public Image[] buttonColor;

    // Needs to assign all players to Char.
    // Chosen characters need to be assigned to the correct players.
    // Info needs to be send to the next scene ( can be in int form ).

    // Next scene uses ints to instantiate chars for players.
    // Number above head indicates who is who.
    // Selection must know how manny players are playing.

    // Cannot start game without everybody choosing.
    // If everybody has a char the game can start.
    // Players need to be able to rechoose.

    // Make every player click comfirm after choosing


    void Start () {

	}

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
        playerManager.charIndexUpdate();            
    }

    private void AddToCharIndex(int charIndex)
    {
        if(!playerManager.charIndex.Contains(charIndex))
        {
            playerManager.charIndex.Add(charIndex);
        }
        else
        {
            playerManager.charIndex.Remove(charIndex);
        }
    }

    public void SharkSelect()
    {
        AddToCharIndex(0);
        ChangeButtonColor(0);
        Debug.Log("Shark");
    }

    public void BeeSelect()
    {
        AddToCharIndex(1);
        ChangeButtonColor(1);
        Debug.Log("Bee");
    }

    public void DuckSelect()
    {
        AddToCharIndex(2);
        ChangeButtonColor(2);
        Debug.Log("Duck");
    }

    public void HumanSelect()
    {
        AddToCharIndex(3);
        ChangeButtonColor(3);
        Debug.Log("Human");
    }

    public void LionSelect()
    {
        AddToCharIndex(4);
        ChangeButtonColor(4);
        Debug.Log("Lion");
    }

    public void MonkeySelect()
    {
        AddToCharIndex(5);
        ChangeButtonColor(5);
        Debug.Log("Monkey");
    }
}
