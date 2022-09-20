using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text[] buttonList;
    private string playerSide;


    public GameObject restartButton;



    private int moveCount;

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    void Awake() //Yazılacak yazı X olduğu için oyuncu X olarak tanımlandı.
    {
        moveCount = 0;
        SetGameControllerReferenceOnButtons();
        playerSide = "X";

        restartButton.SetActive(false);

    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()  //Ekstra grid eklemek isterseniz else if'i aynen kopyalaıp buttonlist'i arttırmanız yeterli olacaktır.
    {
        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (moveCount >= 9)
        {
            GameOver("Bitti");
        }
        
    }

   

    void GameOver(string winningPlayer)
    {
        if (winningPlayer == "draw")
        {

        }

        SetBoardInteractable(false);
        restartButton.SetActive(true);
    }


    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        restartButton.SetActive(false);
        SetBoardInteractable(true);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }

    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}

