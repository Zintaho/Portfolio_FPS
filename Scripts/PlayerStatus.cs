using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    public int HP_CUR = 100;  //현재 HP
    public int HP_MAX = 100;  //최대 HP
    public int SP_CUR = 100;  //현재 SP
    public int SP_MAX = 100;  //최대 SP

    public float MVSPD_VERT = 10f; //최대 종이동 속도
    public float MVSPD_HORZ = 6f; //최대 횡이동 속도
     
    public float ROTSPD_HORZ = 2f; //최대 좌우회전 속도
    public float ROTSPD_VERT = 2f; //최대 상하회전 속도

    public bool isMoving = false;
}
