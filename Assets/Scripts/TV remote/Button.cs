using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Button
{


    public abstract Button ChangeButton(int x, int y);
    public abstract void ExecuteAction();
}
