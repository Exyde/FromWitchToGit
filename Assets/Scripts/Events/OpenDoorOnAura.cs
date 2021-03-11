using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOnAura : MonoBehaviour
{
    public GameObject guard;
    public int auraTrigger = 75;
    DialogueManager dm;

    void Start()
    {
        dm = guard.GetComponent<DialogueManager>();
    }

    void Update()
    {
        if (dm.auraAmount >= auraTrigger){
            //Play Animation Open Door !
            Destroy(this.gameObject);
        }
    }
}
