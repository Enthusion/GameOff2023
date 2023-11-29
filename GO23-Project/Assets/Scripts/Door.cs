using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : SwitchReciever
{
    protected Animator anima;

    public override void Start()
    {
        base.Start();
        anima = GetComponent<Animator>();
    }
    public override void Activating()
    {
        base.Activating();
        Activated();
    }
    public override void Activated()
    {
        base.Activated();
        anima.SetBool("Open", true);
    }
}
