using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerBossActive : MonoBehaviour
{
    public GameObject MaleAime;
    public GameObject BossTitleCanvas;

    BossAI bossAi;

    bool bossStarted = false;
    public float minScale = .1f;

    void Start()
    {
        bossAi = MaleAime.GetComponent<BossAI>();
        bossAi.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !bossStarted)
        {
            MaleAime.GetComponent<BossAI>().enabled = true;

            iTween.ScaleTo(BossTitleCanvas, iTween.Hash("x", minScale, "z", minScale, "y", minScale));

        }
    }
}
