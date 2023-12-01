using System.Collections;
using System.Collections.Generic;
// using UnityEngine
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public string firstLevel;
    public void PlayGame(){
        GameManager.Instance.LoadScene(firstLevel);
    }
}
