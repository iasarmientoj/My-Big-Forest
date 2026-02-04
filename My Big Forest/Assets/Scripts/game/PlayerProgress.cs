using UnityEngine;
using System;

public class PlayerProgress : MonoBehaviour
{
    public int mushroomCount = 0;
    public static event Action<int> OnMushroomCollected;

    public void AddMushroom()
    {
        mushroomCount++;
        OnMushroomCollected?.Invoke(mushroomCount);
    }
}
