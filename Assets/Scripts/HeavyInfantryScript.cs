﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeavyInfantryScript : MonoBehaviour
{

    //private AudioSource <имя звукового файла>; - переменная для аудиофайла
    [SerializeField]private GameObject HeavyInfantry;
    //private float MoveSpeed = 5f;
    
    /*void Avake()      //Вызывается раньше Start
     {

     } */
    // Start is called before the first frame update
    void Start()
    {
        //HeavyInfantry = GetComponent<нужный компонент из unity>
        //Debug.Log("<текст>" + TimeDeltaTime); - функция вывода текста
    }

    // Update is called once per frame
    void Update()
    {
        //HeavyInfantry.transform.position = new Vector3(<x>,<y>, <z>);/HeavyInfantry.transform.Translate(Vector3.forward * MoveSpeed * Time.DeltaTime); - движение по координатам(также поворачивать)
        //Input.GetKey(KeyCode.<кнопка>);   -регестрирует нажатие кнопки и возвращает true
        //SetActive.HeavyInfantry(true); - включает персонажа
        //Destroy(HeavyInfantry); - уничтожение персонажа
    }

    /*void OnMouseDown()срабатывает по нажатию на коллайдер мышью(если этот скрипт прикреплён к объекту, то его явное указание в функциях не требуется
     * {
     *  
     * }
     * */
    /*void OnMouseUp()срабатывает после отпускания клавиши мыши(если этот скрипт прикреплён к объекту, то его явное указание в функциях не требуется
    * {
    *  
    * }
    * */
    /*void OnMouseAsButton()срабатывает после нажатия и отпускания клавиши мыши(если этот скрипт прикреплён к объекту, то его явное указание в функциях не требуется
    * {
    *  
    * }
    * */
}
