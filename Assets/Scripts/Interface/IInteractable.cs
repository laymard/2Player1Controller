using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable 
{
    /// <summary>
    /// Called when the interaction is completed
    /// </summary>
    void OnInteractionSucceded();

    /// <summary>
    /// Called when the interaction has failed (e.g the wrong player started the interaction)
    /// </summary>
    void OnInteractionFailed();

    /// <summary>
    /// Recevied when an interactor is inside the range
    /// </summary>
    void OnInteractorInRange();

    /// <summary>
    /// Called when an interactor exit the interaction range
    /// </summary>
    void OnInteractorExitRange();

    /// <summary>
    /// Called when all interactors are no longer in range
    /// </summary>
    void OnAllInteractorsExitRange();

    /// <summary>
    /// Called by the interactionHandler when he gets input
    /// </summary>
    void OnInteractionInputReceived();

    void OnWrongPlayerInteractionReceived();
}
