using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSwitch : Interactable
{
    public Light m_light;
    public GameObject Flame;
    public bool isOn;

    void Start()
    {
        ToggleLight();
    }
    
    void ToggleLight()
	{
        m_light.enabled = isOn;
        Flame.SetActive(isOn);
	}

	public override string GetDescription()
	{
        if (isOn) return "Eteindre [E]";
        return "Allumer [E]";
	}

	public override void Interact()
	{
        isOn = !isOn;
        ToggleLight();
	}
}
