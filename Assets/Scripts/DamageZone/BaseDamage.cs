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
    private Vector2 HpBar_Width;
    private float Damage;

    private void Awake()
    {
        
        _HpText = HpText.GetComponent<Text>();
        HpBar_Width = HpBar.sizeDelta;
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
        
        HpBar_Width -= new Vector2(Damage, 0);
        //HpBar.position += new Vector3(HpBar.position.x + Damage, 0, 0);
        _HpText.text = HpBar_Width.ToString();
        yield return new WaitForSeconds(500f);
    }
    IEnumerator Damager_Orcs()
    {
        Debug.Log("Damaged");
        HpBar_Width -= new Vector2(Damage, 0);
        //HpBar.position -= new Vector3(HpBar.position.x + Damage, 0, 0);
        _HpText.text = HpBar_Width.x.ToString();
        yield return new WaitForSeconds(500f);
    }
}
