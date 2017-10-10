using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillCtrl : MonoBehaviour
{
    PlayerStatus playerStatus; /*필수*/

    public SkillSelect skillSelect;
    public Transform skillPos;
    public AudioSource cancelAudio;

    public float[] forces = new float[4];

    private Skill currentSkill;

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>(); /*필수*/
    }

    // Update is called once per frame
    void Update()
    {
        currentSkill = skillSelect.skills[skillSelect.index];
        string skillString = "Skill" + (skillSelect.index + 1).ToString();
        if ( ((Input.GetButton("Fire3") || Input.GetAxis("Fire3") > 0)&& currentSkill.isBombOn)
            || (Input.GetButton(skillString) && currentSkill.isBombOn) )
        {
            if(playerStatus.SP_CUR >= currentSkill.requireSP) 
            {//남은 SP가 충분하다면
                Activate(skillSelect.index);
            }
            else
            {//남은 SP가 부족하다면
                cancelAudio.Play();
            }
        }
    }


    void Activate(int activatedSkill)
    {
        Skill skill = skillSelect.skills[activatedSkill];
        GameObject skillObj;

        skillObj = (GameObject)GameObject.Instantiate(skill.skillObject, skillPos.position, skillPos.rotation);
        currentSkill.curTime = 0.0f;
        playerStatus.SP_CUR -= skill.requireSP;

        if(activatedSkill == 0)/*추후에 enum으로 변경*/
        {//ACID 
            Transform tfSkill = skillObj.GetComponent<Transform>();
            Rigidbody rbSkill = skillObj.GetComponent<Rigidbody>();

            Vector3 forceVector = (Vector3.Normalize(new Vector3(0, 0.5f, 0) + tfSkill.forward) * forces[0]);
            rbSkill.AddForce(forceVector);
        }
        else if(activatedSkill == 1)
        {//BOMB
            Transform tfSkill = skillObj.GetComponent<Transform>();
            Rigidbody rbSkill = skillObj.GetComponent<Rigidbody>();

            Vector3 forceVector = (Vector3.Normalize(new Vector3(0, 0.5f, 0) + tfSkill.forward) * forces[0]);
            rbSkill.AddForce(forceVector);
        }
        else if (activatedSkill == 2)
        {//ABSORB
            Transform tfSkill = skillObj.GetComponent<Transform>();
            Rigidbody rbSkill = skillObj.GetComponent<Rigidbody>();

            Vector3 forceVector = (Vector3.Normalize(new Vector3(0, 0.5f, 0) + tfSkill.forward) * forces[0]);
            rbSkill.AddForce(forceVector);
        }
        else if (activatedSkill == 3)
        {//SHIELD

        }
    }

    
}
