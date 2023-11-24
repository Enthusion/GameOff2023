using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Switch : MonoBehaviour
{
    public SwitchReciever Reciever;
    public bool Active { get; protected set; }
    public virtual void Start()
    {
        Reciever?.StartUp(Active);
    }
    public virtual void Update() { }
    public virtual void Activating() { }
    public virtual void Activated()
    {
        Active = true;
    }
}
