using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CharaterEventSO healthEvent;
    public PlayerStatBar playerStatBar;

    private void OnEnable()
    {
        healthEvent.OnEventRaised += OnHealthEvent;
    }

    private void OnDisable()
    {
        healthEvent.OnEventRaised -= OnHealthEvent;
    }

    private void OnHealthEvent(Character character)
    {
        var pensentage = (float)character.currentHealth / character.maxHealth;
        playerStatBar.OnHealthChange(pensentage);
    }
}
