using System.Collections;
using UnityEngine;

public class RespawnOnExitCollider : MonoBehaviour
{
    // The spawn point to respawn the player at
    public Transform spawnPoint;

    // The delay before respawning the player
    public float respawnDelay = 3f;

    // The GameController script
    private GameController gc;

    // The BallController script
    private BallController bc;

    // Get the GameController and BallController scripts when the script is started
    void Start()
    {
        gc = FindObjectOfType<GameController>();

        // Check that the BallController script is present
        bc = FindObjectOfType<BallController>();
        if (bc == null)
        {
            Debug.LogError("BallController script not found!");
        }
    }

    // Called when an object exits the collider attached to this script
    //score traffic
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Respawn the player after a delay
            StartCoroutine(RespawnAfterDelay(other.gameObject));
            Debug.Log("Player out!!");
            SoundManager.instance.PlaySFX("playerDrop");
            
        }
        else if (other.CompareTag("Stuff"))
        {
            // Update the score and log a message to the console
            gc.UpdateScore(-10);
            Debug.Log("Stuff out!!");
            SoundManager.instance.PlaySFX("fail");

        }
        else if (other.CompareTag("Garbage"))
        {
            // Update the score and log a message to the console
            gc.UpdateScore(10);
            Debug.Log("Garbage out!!");
            SoundManager.instance.PlaySFX("corect");

        }
    }

    // Respawn the player after a delay and disable player control
    private IEnumerator RespawnAfterDelay(GameObject player)
    {
        bc.canControl = false;  // disable player control
        bc.speed = 0;
        
        yield return new WaitForSeconds(respawnDelay);
        
        bc.GetComponent<Rigidbody>().velocity = Vector3.zero; // delete all forces on the ball
        bc.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;

        yield return new WaitForSeconds(1f);  // wait for a moment before enabling player control
        bc.canControl = true;  // enable player control
        bc.speed = 10;

        Debug.Log("Player respawned!");
        
    }
}