using UnityEngine;
using System.Collections;

public class PlayerRotate : MonoBehaviour
{
    PlayerStatus playerStatus; /*필수*/
    GameObject playerCameraObject;       //상하회전시 카메라만 회전하게 하기 위함

    private Vector3 rotateInfo;
    private float horz = 0.0f;
    private float vert = 0.0f;

    private Transform playerTransform;
    // Use this for initialization
    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>(); /*필수*/
        playerCameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxis("Mouse X");
        vert = Input.GetAxis("Mouse Y");

        rotateInfo = new Vector3(0, horz, 0);
        playerTransform.Rotate(rotateInfo * playerStatus.ROTSPD_HORZ);

        rotateInfo = new Vector3(vert, 0, 0);
        playerCameraObject.transform.Rotate(rotateInfo * playerStatus.ROTSPD_VERT);
    }
}
