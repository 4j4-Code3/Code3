using UnityEngine;

public class DialoguesMarchand : MonoBehaviour
{
    public Dialogues dialogues;
    private bool Dialogue1 = false;

    private bool zoneDialogues = false;

    void Update()
    {
        if (Dialogue1 == false && zoneDialogues == true)
        {
            Dialogue1 = true;
            dialogues.CommencerDialogue();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            zoneDialogues = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            zoneDialogues = false;
        }
    }
}
