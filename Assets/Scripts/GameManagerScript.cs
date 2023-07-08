using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] int _woodCollected = 0;
    [SerializeField] TMP_Text _woodAmountText; 
    // Start is called before the first frame update
    void Start()
    {
        _woodAmountText.text = "Wood: "+ _woodCollected.ToString();
    }
    public void CollectWood(int m_woodAmount)
    {
        _woodCollected += m_woodAmount;
        _woodAmountText.text = "Wood: " + _woodCollected.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
