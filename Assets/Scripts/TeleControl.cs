using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleControl : MonoBehaviour
{
    [SerializeField] HeroControl player;
    [SerializeField] MainMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<HeroControl>();
        menu = FindObjectOfType<MainMenu>();
    }

    public void MobileButtons(int i)
    {
        switch (i)
        {
            case (int)ActionButtons.LeftMove:
                {
                    player.Button = ActionButtons.LeftMove;
                }
                break;

            case (int)ActionButtons.RightMove:
                {
                    player.Button = ActionButtons.RightMove;
                }
                break;

            default:
                player.Button = ActionButtons.NotPressed;
                
                break;
        }
    }
    
    public void UpArrow()
    {
        player.Jump();
    }
    public void TeleFire()
    {
        player.Fire();
    }
    public void TeleBomb()
    {
        player.Bomb();
    }
    public void TeleMenu()
    {
        menu.GotoMainmenu();
    }



}
