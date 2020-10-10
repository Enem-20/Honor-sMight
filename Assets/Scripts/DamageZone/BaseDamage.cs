using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class BaseDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private RectTransform HpBar;
    [SerializeField] private GameObject HpText;
    private Text _HpText;
    private Vector2 Damage;

    private void Awake()
    {
        
        _HpText = HpText.GetComponent<Text>();
        Damage = new Vector2(1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Humans" && gameObject.name == "DamageOrcs")
        {
            StartCoroutine("Damager_Orcs");
        }
        if(other.tag == "Orcs" && gameObject.name == "DamageHumans")
        {
            StartCoroutine("Damager_Humans");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Humans" && gameObject.name == "DamageOrcs")
        {
            StopCoroutine("Damager_Orcs");
        }
        if (other.tag == "Orcs" && gameObject.name == "DamageHumans")
        {
            StopCoroutine("Damager_Humans");
        }
    }

    IEnumerator Damager_Humans()
    {
        while (HpBar.sizeDelta.x > 0)
        {
            HpBar.sizeDelta -= Damage;
            //HpBar.position += new Vector3(HpBar.position.x + Damage, 0, 0);
            _HpText.text = HpBar.sizeDelta.x.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator Damager_Orcs()
    {
        while (HpBar.sizeDelta.x > 0)
        {
            Debug.Log("Damaged");
            HpBar.sizeDelta -= Damage;
            //HpBar.position -= new Vector3(HpBar.position.x + Damage, 0, 0);
            _HpText.text = HpBar.sizeDelta.x.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
