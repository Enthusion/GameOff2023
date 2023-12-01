using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public SceneAsset firstLevel;
    public void PlayGame(){
        GameManager.Instance.LoadScene(firstLevel.name);
    }
}
