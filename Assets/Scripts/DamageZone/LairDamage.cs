using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LairDamage : MonoBehaviour
{
    private GameObject HpBarLair;
    private GameObject HpText;
    private RectTransform _HpBarLair;
    private Text _HpText;
    [SerializeField]List<GameObject> enemy;

    private float Damage = 5f;
    bool Destroyed;

    private void Awake()
    {
        Destroyed = false;
    }

    void Start()
    {
        HpBarLair = GameObject.Find("HPbarOrcs");
        HpText = GameObject.Find("HpTextOrcs");

        _HpBarLair = HpBarLair.GetComponent<RectTransform>();
        _HpBarLair.sizeDelta = new Vector2(400, 8);
        _HpText = HpText.GetComponent<Text>();
        _HpText.text = _HpBarLair.sizeDelta.x.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "HeavyInfantrys(Clone)")&&(enemy.Count == 0))
        {
            StartCoroutine("DamageTime");
            enemy.Add(other.gameObject);
            /*_HpBarLair.sizeDelta = new Vector2(_HpBarLair.sizeDelta.x - Damage * Time.deltaTime, 8);
            _HpText.text = _HpBarLair.sizeDelta.x.ToString();*/
        }
        else if(other.gameObject.name == "HeavyInfantrys(Clone)")
        {
            enemy.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.name == "HeavyInfantrys(Clone)")&&(enemy.Count == 1))
        {
            enemy.Remove(other.gameObject);
            StopCoroutine("DamageTime");
        }
        else if((other.gameObject.name == "HeavyInfantrys(Clone)") && (enemy.Count > 0))
        {
            enemy.Remove(other.gameObject);
        }
    }

    private IEnumerator DamageTime()
    {
        while (true)
        {
            for(int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i] == null)
                {
                    enemy.RemoveAt(i);
                }
            }
            
            _HpBarLair.sizeDelta = new Vector2(_HpBarLair.sizeDelta.x - Damage * enemy.Count, 8);
            _HpText.text = _HpBarLair.sizeDelta.x.ToString();
            yield return new WaitForSeconds(1f);
        }
        
    }
}
