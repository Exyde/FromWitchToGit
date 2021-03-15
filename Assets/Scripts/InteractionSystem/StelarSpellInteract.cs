using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StelarSpellInteract : Interactable
{
    public bool examined = false;

    public GameObject SpellPanel;
    public GameObject vfx;
    void Start()
    {
        SpellPanel.SetActive(false);
    }

    public override string GetDescription()
    {
        if (!examined) return "Examiner [E]";
        return "Fermer [E]";
    }

    public override void Interact()
    {
        if (!examined)
        {
            SpellPanel.SetActive(true);
            examined = true;
            vfx.SetActive(false);
        } else if (examined)
        {
            SpellPanel.SetActive(false);
            examined = false;
            vfx.SetActive(true);
        }

    }
}
