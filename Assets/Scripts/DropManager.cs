using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public static DropManager Instance;

    public int maxDrops = 5;
    public int totalBoxes = 20;

    private int currentDrops = 0;
    private int boxesBroken = 0;

    [Range(0f, 1f)]
    public float baseDropChance = 0.25f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool TryDrop()
    {
        boxesBroken++;

        int dropsLeft = maxDrops - currentDrops;
        int boxesLeft = totalBoxes - boxesBroken;

        if (boxesLeft < dropsLeft)
        {
            currentDrops++;
            return true;
        }

        if (Random.value <= baseDropChance)
        {
            currentDrops++;
            return true;
        }

        return false;
    }
}
