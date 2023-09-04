using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : BaseScene
{
    private void Start()
    {
        AddressableManager.Instance.Instantiate("Test");
    }
}
