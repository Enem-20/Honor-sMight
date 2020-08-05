using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class On_CollisionAndOnEnte : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour {

	public GameObject obj;
	private GameObject inst_obj;
	[SerializeField]
	private float speed = 4f;

	void Start () {
		inst_obj = Instantiate (obj, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
	}

	void Update () {
		float zPos = Input.GetAxis ("Vertical");

		inst_obj.transform.Translate (Vector3.forward * speed * zPos * Time.deltaTime);
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {

	void OnMouseDown () {
		transform.localScale = new Vector3 (transform.localScale.x / 2f, transform.localScale.y / 2f, transform.localScale.z / 2f);
	}

	void OnCollisionEnter (Collider <название коллайдера>)// ВызываетсЯ когда произошло соприкосновение с коллайдером данного объекта {
		print (<название коллайдера>.gameObject.name);
    void OnCollisionExit (Collider <название коллайдера>)// Вызывается когда соприкосновение с коллайдером данного объекта закончилось {
		print (<название коллайдера>.gameObject.name);
    void OnCollisionExit (Collider <название коллайдера>)// Вызывается когда соприкосновение с коллайдером данного объекта продолжается {
		print (<название коллайдера>.gameObject.name);/*Аналогично и с триггерами*/
	/*}
	}

}
 */
