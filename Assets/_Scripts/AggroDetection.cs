﻿using System;
using UnityEngine;

public class AggroDetection : MonoBehaviour {
    public event Action<Transform> OnAggro = delegate { };

    void OnTriggerEnter(Collider other) {
        var player = other.GetComponent<PlayerMovement>();

        if (player != null) {
            OnAggro(player.transform);
        }
    }
}
