using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    [SerializeField] Sprite[] _treeCutSprites;
    [SerializeField] int _treeHealth = 100;
    [SerializeField] BoxCollider2D _treebox;
    [SerializeField] CircleCollider2D _treeTop;
    GameManagerScript _gameManager;
    [SerializeField] int _woodAmountPerChop = 1;
    [SerializeField] int _SpriteChangeMulti = 2;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamageTree(int m_dmg)
    {
        _treeHealth -= m_dmg;
        ChangeTreeSprite();
    }
    void ChangeTreeSprite()
    {
        switch (_treeHealth)
        {
            case 80:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _treeCutSprites[0];
                _gameManager.CollectWood(_woodAmountPerChop * _SpriteChangeMulti);
                break;
            case 60:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _treeCutSprites[1];
                _gameManager.CollectWood(_woodAmountPerChop * _SpriteChangeMulti);

                break;
            case 40:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _treeCutSprites[2];
                _gameManager.CollectWood(_woodAmountPerChop * _SpriteChangeMulti);

                break;
            case 20:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _treeCutSprites[3];
                _gameManager.CollectWood(_woodAmountPerChop * _SpriteChangeMulti);

                _treeTop.enabled = false;
                _treebox.enabled = false;
                break;
            default:
                _gameManager.CollectWood(_woodAmountPerChop);

                break;
        }
        if (_treeHealth <= 0)
        {
            _gameManager.CollectWood(_woodAmountPerChop * _SpriteChangeMulti);

            Destroy(this.gameObject);

        }
    }
    void OnMouseOver()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<AxeScript>().CanSwing(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<AxeScript>().TreeSelected(this.gameObject);

    }

    void OnMouseExit()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<AxeScript>().CanSwing(false);

    }
}
