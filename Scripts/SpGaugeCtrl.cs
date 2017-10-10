using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpGaugeCtrl : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public Text currentAmountText;
    public Text maxAmountText;
    
    private Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        maxAmountText.text = playerStatus.SP_MAX.ToString();
        currentAmountText.text = playerStatus.SP_CUR.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        slider.value = (float)playerStatus.SP_CUR/(float)playerStatus.SP_MAX;
    }

    public void TextUpdate()
    {
        currentAmountText.text = playerStatus.SP_CUR.ToString();
        maxAmountText.text = playerStatus.SP_MAX.ToString();
    }
}
