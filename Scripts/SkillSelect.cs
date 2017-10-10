using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillSelect : MonoBehaviour
{
    RectTransform rectTr;
    AudioSource audioSource;

    public Skill[] skills = new Skill[4];
    public int index = 0;

    void Start()
    {
        rectTr = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Skill1") )
        {
            rectTr.Translate(new Vector2(50f * (0 - index), 0f));
            index = 0;
            audioSource.Play();
        }
        else if (Input.GetButtonUp("Skill2"))
        {
            rectTr.Translate(new Vector2(50f * (1 - index), 0f));
            index = 1;
            audioSource.Play();
        }
        else if (Input.GetButtonUp("Skill3"))
        {
            rectTr.Translate(new Vector2(50f * (2 - index), 0f));
            index = 2;
            audioSource.Play();
        }
        else if (Input.GetButtonUp("Skill4"))
        {
            rectTr.Translate(new Vector2(50f * (3 - index), 0f));
            index = 3;
            audioSource.Play();
        }
    }

}
