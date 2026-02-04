using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string collectibleTag = "Player";
    public AudioClip collectionSound;
    
    private void OnTriggerEnter(Collider other)
    {
        // Search in parent as well in case the collider is on a child object
        PlayerProgress progress = other.GetComponentInParent<PlayerProgress>();
        if (progress != null)
        {
            if (collectionSound != null)
            {
                AudioSource.PlayClipAtPoint(collectionSound, transform.position);
            }
            progress.AddMushroom();
            Destroy(gameObject);
        }
    }
}
