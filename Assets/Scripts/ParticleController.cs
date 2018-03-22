using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class ParticleController : MonoBehaviour
{
    ParticleSystem particleSystem;

    PlayerMovement playerMovement;

    float baseEmit = 1.5f;

    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = particleSystem.main;
        main.startLifetime = (playerMovement.YAxisMovement + baseEmit);
    }
}
