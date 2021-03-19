using UnityEngine;

public class OpenDoorOnAura : MonoBehaviour
{
    public GameObject guard;
    public int auraTrigger;
    private DialogueManager dm;

    private void Start()
    {
        dm = guard.GetComponent<DialogueManager>();
    }

    private void Update()
    {
        if (dm.auraAmount >= auraTrigger)
        {
            //Play Animation Open Door !
            //GetComponent<Animator>().Set
            Destroy(this.gameObject);
        }
    }
}