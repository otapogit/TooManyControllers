using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Button
{


    public abstract void ExecuteAction();
    public void SetSelected();
    public void SetUnselected();
    public void SetPressed();
}
