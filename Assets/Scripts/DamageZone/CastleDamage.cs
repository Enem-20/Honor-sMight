using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleDamage : MonoBehaviour
{
    [SerializeField] private GameObject[] Skull;

    private GameObject HpBarCastle;
    private GameObject HpTextCastle;
    [SerializeField] private List<GameObject> enemy;
    private RectTransform _HpBarCastle;
    private Text _HpTextCastle;

    RectTransform SkullUnity1;
    RectTransform SkullUnity2;

    private float Damage = 5f;

    // Start is called before the first frame update
    void Start()
    {
        HpBarCastle = GameObject.Find("HpBarHumans");       //Find health bar of Humans
        HpTextCastle = GameObject.Find("HpTextHumans");     //Find text, which shows health bar numbers

        _HpBarCastle = HpBarCastle.GetComponent<RectTransform>();       //Get access to health bar
        _HpBarCastle.sizeDelta = new Vector2(400, 8);       //Default value vor health bar
        _HpTextCastle = HpTextCastle.GetComponent<Text>();
        _HpTextCastle.text = _HpBarCastle.sizeDelta.x.ToString();       //To show health in numbers

        Skull[0] = GameObject.Find("Skull1");       //Skull's texture
        Skull[1] = GameObject.Find("Skull2");

        SkullUnity1 = Skull[0].GetComponent<RectTransform>();
        SkullUnity2 = Skull[1].GetComponent<RectTransform>();
        SkullUnity1.anchoredPosition3D = new Vector3(73, -104f, 0);     //Default position skull's texture
        SkullUnity2.anchoredPosition3D = new Vector3(315f, -104f, 0);
    }

    private void OnTriggerEnter(Collider Enemy)
    {
        if((Enemy.gameObject.name == "OrcProtectors_Empty(Clone)") && (enemy.Count == 0))
        {
            enemy.Add(Enemy.gameObject);
            StartCoroutine("DamageTime");
        }
        else if(Enemy.gameObject.name == "OrcProtectors_Empty(Clone)")
        {
            enemy.Add(Enemy.gameObject);
        }
    }

    private void OnTriggerExit(Collider Enemy)
    {
        if ((Enemy.gameObject.name == "OrcProtectors_Empty(Clone)") &&(enemy.Count == 1))
        {
            enemy.Remove(Enemy.gameObject);
            StopCoroutine("DamageTime");
        }
        else if((Enemy.gameObject.name == "OrcProtectors_Empty(Clone)") && (enemy.Count > 0))
        {
            enemy.Remove(Enemy.gameObject);
        }
    }

    private IEnumerator DamageTime()
    {
        while (true)
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                if (enemy[i] == null)
                {
                    enemy.RemoveAt(i);
                }
            }

            _HpBarCastle.sizeDelta = new Vector2(_HpBarCastle.sizeDelta.x - Damage * enemy.Count, 8);
            _HpTextCastle.text = _HpBarCastle.sizeDelta.x.ToString();
            
            yield return new WaitForSeconds(1f);
        }

    }
}

