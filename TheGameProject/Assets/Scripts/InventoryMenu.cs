using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class InventoryMenu : MonoBehaviour
    {
        public GameObject Canvas;
        void Start(){
            Canvas.SetActive(false);
        }
        void Update(){
            if (Input.GetKeyDown(KeyCode.Escape)){
                Canvas.SetActive(!Canvas.activeSelf);  
            }
        }
    }
