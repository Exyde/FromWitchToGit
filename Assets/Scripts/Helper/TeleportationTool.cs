using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationTool : MonoBehaviour
{
    Transform player;
    CharacterController cc;

    public Transform[] positions;
    int index = 0;

    void Start()
    {
        player = FindObjectOfType<FPSController>().transform;
        cc = player.GetComponent<CharacterController>();
        print(player.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            cc.enabled = false;
            player.position = positions[index].position + new Vector3(.5f, 2f, .5f);
            index = (index + 1) % positions.Length;
            print("TP");
            cc.enabled = true;
        }
    }
}
