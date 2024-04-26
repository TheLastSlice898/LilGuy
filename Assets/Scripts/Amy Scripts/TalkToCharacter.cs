
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkToCharacter : MonoBehaviour
    {
    public GameObject speechBubble;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            speechBubble.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            speechBubble.SetActive(false);
    }
}