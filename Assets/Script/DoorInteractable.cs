using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Keypad))]
[RequireComponent(typeof(Collider))]
public class DoorInteractable : Interactable {

    private Keypad keypad;
    private Collider doorCollider;

    void Start()
    {
        keypad = GetComponent<Keypad>();
        doorCollider = GetComponent<Collider>();
    }

    public override void Interact()
    {
        // open keypad
        keypad.Show(doorCollider);
    }
}
