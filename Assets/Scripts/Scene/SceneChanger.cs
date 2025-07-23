using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to manage
    public Animator transitionAnimator; // Animator for scene transition effects
    public float transitionDuration = 1f; // Duration of the transition effect
    public Vector2 teleportPosition;
    private Transform playerTransform; // Reference to the player's transform

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var checkPoint = CheckpointManager.Instance;
        if (checkPoint != null)
        {
            checkPoint.ResetCheckpoint();
        }
        Debug.Log("Trigger entered by: " + collision.gameObject.tag);
        if (collision.CompareTag("Player"))
        {
            playerTransform = collision.transform; // Get the player's transform
            transitionAnimator.Play("FadeAnimation"); // Play the fade-out animation
            // Load the specified scene when the player enters the trigger
            StartCoroutine(LoadSceneWithTransition());
        }
    }

    IEnumerator LoadSceneWithTransition()
    {
        // Wait for the transition animation to finish before loading the scene
        yield return new WaitForSeconds(transitionDuration);
        playerTransform.position = teleportPosition; // Teleport the player to the specified position
        SceneManager.LoadScene(sceneToLoad);
    }
}
