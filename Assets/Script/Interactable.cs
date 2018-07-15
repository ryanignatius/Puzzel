using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Interactable : MonoBehaviour {

    public bool useZoom = true;

    protected FirstPersonCamera cam;

    protected bool isStartInteract;
    protected bool isInteract;
    protected Vector3 target;
    protected float zoomLevel;

    protected static GameObject terminalObject;
    protected static Terminal terminal;

    protected virtual void Start()
    {
        isStartInteract = false;
        isInteract = false;
        target = transform.position;
        zoomLevel = 30;
        cam = GameObject.Find("Main Camera").GetComponent<FirstPersonCamera>();
        if (terminalObject == null)
        {
            terminalObject = GameObject.Find("Terminal");
            if (terminalObject != null)
            {
                terminal = terminalObject.GetComponentInChildren<Terminal>();
                terminalObject.SetActive(false);
            }
        }
    }

    protected virtual void Update()
    {
        if (isInteract)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                CancelInteract();
            }
        }
    }

    public void Interact()
    {
        if (!isStartInteract)
        {
            isStartInteract = true;
            if (useZoom)
            {
                float t = cam.ZoomTo(target, zoomLevel);
                Invoke("AfterInteract", t);
            }
            else
            {
                AfterInteract();
            }
        }
    }

    public void CancelInteract()
    {
        if (isInteract)
        {
            isInteract = false;
            CloseTerminal();
            if (useZoom)
            {
                float t = cam.CancelZoom();
                Invoke("AfterCancelInteract", t);
            }
            else
            {
                AfterCancelInteract();
            }
        }
    }

    protected virtual void AfterInteract()
    {
        isInteract = true;
        OpenTerminal();
    }

    protected virtual void AfterCancelInteract()
    {
        isStartInteract = false;
    }

    private void OpenTerminal()
    {
        Debug.Log("open terminal");
        if (terminalObject != null)
        {
            Debug.Log("open terminal not null");
            terminalObject.SetActive(true);
            terminal.ShowTerminal("test open terminal");
        }
    }

    private void CloseTerminal()
    {
        if (terminalObject != null)
        {
            terminalObject.SetActive(false);
        }
    }
}
