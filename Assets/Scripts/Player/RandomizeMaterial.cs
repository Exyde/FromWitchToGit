using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMaterial : MonoBehaviour
{
    public SkinnedMeshRenderer smr;
    public SkinData skinDatas;

    void Start()
    {
        smr.material = skinDatas.currentSkin;
    }

    public void RandomizeSkin()
    {
        skinDatas.RandomizeSkin();
        smr.material = skinDatas.currentSkin;
    }
}
