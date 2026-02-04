using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string collectibleTag = "Player";
    
    private void OnTriggerEnter(Collider other)
    {
        // Search in parent as well in case the collider is on a child object
        PlayerProgress progress = other.GetComponentInParent<PlayerProgress>();
        if (progress != null)
        {
            progress.AddMushroom();
            Destroy(gameObject);
        }
    }
}
