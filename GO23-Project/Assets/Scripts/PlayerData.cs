using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Player Data", menuName="Player Data")]
public class PlayerData : ScriptableObject
{
    public string characterName;
    public int characterId;
    public bool primaryPlayer;
    public float moveForce = 10f;
    public float maxSpeed = 15f;
    public float jumpForce = 10f;
    public float jumpTime = 0.13f;
    public LayerMask isGround;
    // public Vector2 groundOffset1 = new Vector2(-0.5f, -2.5f);
    // public Vector2 groundOffset2 = new Vector2(0.15f, -2.53f);
    public LayerMask isInteractable;
    public float baseDamage;
}