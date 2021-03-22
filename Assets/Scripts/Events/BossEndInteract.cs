using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEndInteract : Interactable
{
    public bool examined = false;

    public override string GetDescription()
    {
        if (!examined) return "Interagir [E]";
        return "";
    }

    public override void Interact()
    {
        if (!examined)
        {
            examined = true;
            FindObjectOfType<GameManager>().HandleGameEnd();
        }
    }
}
