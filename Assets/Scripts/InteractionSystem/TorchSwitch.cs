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
        if (isOn) return "Press [E] to turn <color=red> off </color> the torch.";
        return "Press [E] to turn <color=green> on </color> the torch.";
	}

	public override void Interact()
	{
        isOn = !isOn;
        ToggleLight();
	}
}
