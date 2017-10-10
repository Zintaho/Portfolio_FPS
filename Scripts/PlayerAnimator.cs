using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

    PlayerStatus playerStatus; /*필수*/

    public Animator playerAnimator;
	// Use this for initialization
	void Start ()
    {
        playerStatus = GetComponent<PlayerStatus>(); /*필수*/
    }

    void FixedUpdate()
    {
        if(playerStatus.isMoving)
        {
            playerAnimator.SetBool("Moving", true);
        }
        else
        {
            playerAnimator.SetBool("Moving", false);
        }
    }
	
}
