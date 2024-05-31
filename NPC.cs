using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueText.text = "Villager: Be careful to the sorrounding, there are many enemies lurking. in the area. You must collect all the blue orbs to finish the game";
            dialogueText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueText.gameObject.SetActive(false);
        }
    }
}
