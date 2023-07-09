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
    [SerializeField] int _stumpMultiplier = 2;
    [SerializeField] int _woodMulti = 1;
    [SerializeField] GameObject _treeParticlesPrefab;
    [SerializeField] Transform _particleSpawnPoint;
    int _spawnLocNum = -1;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
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
    public void SpawnTreeProperties(int m_woodPerChop, int m_health, int m_woodMulti, int m_spawnLocNum)
    {
        _treeHealth = m_health;
        _woodAmountPerChop = m_woodPerChop;
        _woodMulti = m_woodMulti;
        _spawnLocNum = m_spawnLocNum;

    }
    public void DamageTree(int m_dmg)
    {
        _treeHealth -= m_dmg;
        ChangeTreeSprite();


        GameObject m_treeParticles = Instantiate(_treeParticlesPrefab, _particleSpawnPoint.position, _treeParticlesPrefab.transform.rotation);
        if (_treeHealth > 0)
        {
            _gameManager.CollectWood(_woodAmountPerChop * _woodMulti);


            m_treeParticles.GetComponent<TreeParticleScript>().SetNumber(_woodAmountPerChop * _woodMulti);
        }
        else
        {
            m_treeParticles.GetComponent<TreeParticleScript>().SetNumber(_woodAmountPerChop * _woodMulti * _stumpMultiplier);

        }


    }
    void ChangeTreeSprite()
    {
        switch (_treeHealth)
        {
            case 80:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _treeCutSprites[0];
                break;
            case 60:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _treeCutSprites[1];

                break;
            case 40:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _treeCutSprites[2];

                break;
            case 20:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _treeCutSprites[3];

                _treeTop.enabled = false;
                _treebox.enabled = false;
                break;
        }
        if (_treeHealth <= 0)
        {
            _gameManager.CollectWood(_woodAmountPerChop * _stumpMultiplier * _woodMulti);
            _gameManager.TreeChopped(_spawnLocNum);
            Destroy(this.gameObject);

        }
    }
}
