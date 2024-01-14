using HutongGames.PlayMaker.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbParticle : MonoBehaviour
{
    private bool hasCollided = false; // Flag to track collision with death zone
    private Player player;
    [SerializeField] ParticleSystem OrbCollected = null;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the reference to the SpringJoint2D component

        player = GameObject.FindObjectOfType<Player>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

            if (!hasCollided)
            {
                hasCollided = true;
                TriggerOrbCollectedParticle();

            }
        
    }

    private void TriggerOrbCollectedParticle()
    {
        OrbCollected.transform.position = transform.position;
        OrbCollected.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
