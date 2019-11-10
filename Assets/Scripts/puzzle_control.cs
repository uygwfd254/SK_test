using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle_control : MonoBehaviour
{
    public bool is_button = false; // true if it's a switch

    private SpriteRenderer sr;
    private bool is_activated = false;
    private bool is_in = false;
    private GameObject interactor;
    private player_control interactor_script;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_activated) {
            sr.color = new Color(0, 0, 0, 1);
        } else {
            sr.color = new Color(1, 1, 1, 1);
        }

        // check
        bool is_interacting = interactor_script.get_is_interacting();
        if (is_in && is_interacting) {
            if (is_button) {
                is_activated = true;
            } else {
                is_activated = !is_activated;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactor = other.gameObject;
        interactor_script = interactor.GetComponent<player_control>();
        is_in = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        is_in = false;
    }
}
