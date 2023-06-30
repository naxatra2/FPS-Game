using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NewBehaviourScript : MonoBehaviour
{
    public string promptMessage; 
    public void BaseInteract()
    {

    }
    //this is templatemethod pattern 
    protected virtual void Interact()
    {

    }
}
