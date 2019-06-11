using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum EInteractionInput
{
    Main =0,
    First,
    Second,
    Third,
    Fourth
}

/// <summary>
/// This class can be attached to any object to get Interaction input from players
/// </summary>
public class Interactable : MonoBehaviour
{
    /// <summary>
    /// Is the interaction allowed for player one
    /// </summary>
    public bool AllowedForPlayerOne;

    /// <summary>
    /// Is the interaction allowed for player two
    /// </summary>
    public bool AllowedForPlayerTwo;

    /// <summary>
    /// Distance in which the actor can interact with this interactable
    /// </summary>
    public float HorizontalInteractionDistance;

    private List<PlayerController> m_PlayersInRange;

    // shit, could be static
    private PlayerController[] m_PlayersInScene;

    private IInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = gameObject.GetComponent<IInteractable>();
        m_PlayersInScene = FindObjectsOfType<PlayerController>();
        m_PlayersInRange = new List<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayersInRange();
    }

    /// <summary>
    /// Triggers when an interactor enter the range on this interactble
    /// </summary>
    void OnActorInRange()
    {
        // start UI stuff ?
        interactable.OnInteractorInRange();
    }

    private void CheckPlayersInRange()
    {
        Vector3 interactorPositon = transform.position;
        interactorPositon.y = 0.0f;

        List<PlayerController> playerInRangeNow = new List<PlayerController>();

        /// check for player in range now
        foreach(PlayerController player in m_PlayersInScene)
        {
            Vector3 playerPosition = player.transform.position;
            playerPosition.y = 0.0f;

            float hSqrDistance = Vector3.SqrMagnitude(interactorPositon - playerPosition);

            if (hSqrDistance < Mathf.Pow(HorizontalInteractionDistance, 2))
            {
                playerInRangeNow.Add(player);
            }
        }

        /// check which player is no longer inside the interaction radius
        int nbActorsRemoved = 0;
        for(int i = m_PlayersInRange.Count - 1; i>=0;i--)
        {
            PlayerController player = m_PlayersInRange[i];
            if (!playerInRangeNow.Contains(player))
            {
                m_PlayersInRange.Remove(player);
                nbActorsRemoved++;
            }
        }

        /// check which player needs to be in range
        foreach (PlayerController player in playerInRangeNow)
        {
            if (!m_PlayersInRange.Contains(player))
            {
                m_PlayersInRange.Add(player);
                OnActorInRange();
            }
        }

        if(!nbActorsRemoved.Equals(0) && m_PlayersInRange.Count.Equals(0))
        {
            OnAllInteractorExits();
        }
    }

    private void OnAllInteractorExits()
    {
        interactable.OnAllInteractorsExitRange();
    }

}
