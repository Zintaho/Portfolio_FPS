using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*모든 플레이어의 동작과 관련된 스크립트는 PlayerStatus 컴포넌트를 참조합니다 */

public class PlayerMove : MonoBehaviour
{
    PlayerStatus playerStatus; /*필수*/

    private float horz = 0.0f;
    private float vert = 0.0f;
    //private float rotateX = 0.0f;
    //private float rotateY = 0.0f;

    private CharacterController charaCtrl;
    private Transform playerTransform;


    // Use this for initialization
    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>(); /*필수*/
        charaCtrl = GetComponent<CharacterController>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        if(horz != 0 || vert !=0)
        {
            playerStatus.isMoving = true;
        }
        else
        {
            playerStatus.isMoving = false;
        }

        charaCtrl.Move(playerTransform.forward * vert * playerStatus.MVSPD_VERT * Time.deltaTime);
        charaCtrl.Move(playerTransform.right * horz * playerStatus.MVSPD_HORZ * Time.deltaTime);
    }
}
