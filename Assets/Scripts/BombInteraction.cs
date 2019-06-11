using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInteraction : MonoBehaviour, IInteractable
{
    public Material NormalMaterial;
    public Material InteractionMaterial;

    private MeshRenderer Meshrenderer;

    public void OnAllInteractorsExitRange()
    {
        Meshrenderer.material = NormalMaterial;
    }

    public void OnInteractionFailed()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteractionInputReceived()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteractionSucceded()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteractorExitRange()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteractorInRange()
    {
        Meshrenderer.material = InteractionMaterial;
    }

    public void OnWrongPlayerInteractionReceived()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Meshrenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
