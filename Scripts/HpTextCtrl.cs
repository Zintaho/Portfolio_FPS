using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpTextCtrl : MonoBehaviour
{
    private GameObject Player;
    private Text text;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
