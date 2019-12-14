﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour {

    public LayerMask targetMask;
    public SpriteRenderer dot;
    public Color dotHighlightColour;
    Color _originalDotColour;

    private void Start()
    {
        Cursor.visible = false;
        _originalDotColour = dot.color;
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.forward * (-40 * Time.deltaTime));
	}

    public void DetectTargets(Ray ray)
    {
        if (Physics.Raycast(ray, 100, targetMask))
        {
            dot.color = dotHighlightColour;
        }
        else
        {
            dot.color = _originalDotColour;
        }
    }
}
