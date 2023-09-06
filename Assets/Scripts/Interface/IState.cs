using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void DoThis();
    void DoThat();
}

public class FreeLookState : IState
{
    public void SetContext(/*Context*/)
    {

    }

    public void DoThat()
    {
        
    }

    public void DoThis()
    {
        
    }
}


