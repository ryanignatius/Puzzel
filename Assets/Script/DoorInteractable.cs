﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Keypad))]
[RequireComponent(typeof(Collider))]
public class DoorInteractable : Interactable {

    private Keypad keypad;
    private Collider doorCollider;

    protected override void Start()
    {
        base.Start();
        keypad = GetComponent<Keypad>();
        doorCollider = GetComponent<Collider>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void AfterInteract()
    {
        base.AfterInteract();
        keypad.Show(doorCollider);
    }

    protected override void AfterCancelInteract()
    {
        base.AfterCancelInteract();
        keypad.Reset();
    }
}
