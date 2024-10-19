using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waveUIControl : MonoBehaviour
{
    public TMP_Text waveText;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //waveText = transform.GetChild(0).gameObject.GetComponent<Text>();

        NextWave(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextWave(int wave)
    {
        Debug.Log("Triggering UI next wave");

        waveText.text = "Wave " + wave.ToString();

        animator.SetBool("nextWave", true);

        Invoke("ResetAnimation", 3f);
    }

    void ResetAnimation()
    {
        animator.SetBool("nextWave", false);
    }
}
