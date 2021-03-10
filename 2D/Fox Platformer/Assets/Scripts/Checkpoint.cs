using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Sprite cpOn, cpOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //CompareTag is slighty better for performance
        {
            CheckpointController.instance.DeactivateCheckpoints();

            sr.sprite = cpOn;

            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoint()
    {
        sr.sprite = cpOff;
    }
}
