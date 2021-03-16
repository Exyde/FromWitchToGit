using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Skin")]
public class SkinData : ScriptableObject
{
    public Material[] skinMaterials;

    public Material currentSkin;

    public void RandomizeSkin()
    {
        Material skin = skinMaterials[Random.Range(0, skinMaterials.Length)];
        currentSkin = skin;
    }
}
