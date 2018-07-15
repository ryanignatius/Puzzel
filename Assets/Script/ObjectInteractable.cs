using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : Interactable {

	protected override void Start ()
    {
        base.Start();
        zoomLevel = 20;
        target = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
    }

    protected override void Update()
    {
        base.Update();
    }
}
