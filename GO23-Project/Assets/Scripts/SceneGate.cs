using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneGate : MonoBehaviour
{
    public SceneAsset DestinationScene;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController controller))
        {
            GameManager.Instance.LoadScene(DestinationScene.name);
        }
    }
}
