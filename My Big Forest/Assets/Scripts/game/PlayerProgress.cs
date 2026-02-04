using UnityEngine;
using System;

public class PlayerProgress : MonoBehaviour
{
    public int mushroomCount = 0;
    public static event Action<int> OnMushroomCollected;
    
    public AudioSource audioSource;
    public AudioClip collectionSound;

    public void AddMushroom()
    {
        mushroomCount++;
        
        if (audioSource != null && collectionSound != null)
        {
            audioSource.PlayOneShot(collectionSound);
        }
        else
        {
            Debug.LogWarning("Falta asignar el AudioSource o el AudioClip en el script PlayerProgress del jugador.");
        }

        OnMushroomCollected?.Invoke(mushroomCount);
    }
}
