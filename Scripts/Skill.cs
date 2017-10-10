using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill : MonoBehaviour
{
    public GameObject skillObject;
     
    public bool isBombOn;
    public Text textCooldown;

    public float fireRate = 5f;
    public float curTime = 0.0f;

    public int requireSP = 0;
    
    private Image iconSkill;

    // Use this for initialization
    void Start()
    {
        iconSkill = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        isBombOn = TimeCheck();
    }

    bool TimeCheck()
    {
        curTime += Time.deltaTime;
        float amount = curTime / fireRate;
        iconSkill.fillAmount = amount;

        UpdateText(fireRate - curTime);
        UpdateAlpha(amount);

        if (curTime >= fireRate)
        {
            curTime = fireRate;

            return true;
        }
        return false;
    }

    void UpdateText(float amount)
    {
        int intAmount = Mathf.CeilToInt(amount);
        if (intAmount > 0)
        {
            textCooldown.text = intAmount.ToString();
        }
        else
        {
            textCooldown.text = "";
        }
    }

    void UpdateAlpha(float amount)
    {
        Color currentColor = iconSkill.color;
        iconSkill.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f + amount / 2);
    }
}
