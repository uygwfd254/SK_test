using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    private bool is_interacting_ = false;
    private bool is_open_inventory_ = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e")) {
            is_interacting_ = true;
        } else {
            is_interacting_ = false;
        }

        if (Input.GetKeyDown("i")) {
            is_open_inventory_ = true;
        } else {
            is_open_inventory_ = false;
        }
    }

    // accessor
    public bool get_is_interacting() {
        return is_interacting_;
    }

    public bool get_is_open_inventory() {
        return is_open_inventory_;
    }
}
