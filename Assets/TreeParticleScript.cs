using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeParticleScript : MonoBehaviour
{
    [SerializeField] TMP_Text _woodParticleText;
    // Start is called before the first frame update
    public void SetNumber(int m_woodAmountText)
    {
        _woodParticleText.text = "+" + m_woodAmountText;
    }
    void Start()
    {
        //start number anim
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
