using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] Button restartButton;
    [SerializeField] Button returnButton;
    bool canMenu = true;
    GameStateChannel gameStateChannel;

    private void Start()
    {
        gameStateChannel = FindObjectOfType<Beacon>().gameStateChannel;
        gameStateChannel.StateEnter += StateEntered;

        returnButton.onClick.AddListener(() =>
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1;
        });
        AssignNamedActionTransition();
    }

    private void AssignNamedActionTransition()
    {
        var transitions = FindObjectsOfType<NamedActionTransition>();
        var buttons = FindObjectsOfType<Button>(true).ToList();
        foreach (var transition in transitions)
        {
            var selectedButton = buttons.FirstOrDefault(x => x.name.Equals(transition.ActionName));
            if (selectedButton != null)
            {
               selectedButton.onClick.AddListener(transition.DoAction);
            }
        }
    }

    private void StateEntered(GameState state)
    {
        if (state == null)
            return;
        if (state.stateSO.canMenu)
            canMenu = true;
        else
            canMenu = false;
    }

    private void Update()
    {
        if (canMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.gameObject.activeInHierarchy);
            if (menuPanel.activeInHierarchy)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
