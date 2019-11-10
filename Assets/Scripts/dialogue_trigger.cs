using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_trigger : MonoBehaviour
{
    public Dialogue dialogue;

    public GameObject dialogue_manager;
    private dialogue_manager dialogue_script;

    private bool is_in = false;
    private bool has_conversation_started = false;
    private GameObject interactor;
    private player_control interactor_script;
    private Rigidbody2D interactor_rb;

    // Start is called before the first frame update
    void Start()
    {
        dialogue_script = dialogue_manager.GetComponent<dialogue_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        bool is_interacting = interactor_script.get_is_interacting();
        if(is_in && is_interacting) {
            interactor_rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            
            if (!has_conversation_started) {
                has_conversation_started = true;
                dialogue_script.start_dialogue(dialogue);
            } else {
                dialogue_script.display_next_sentence();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactor = other.gameObject;
        interactor_script = interactor.GetComponent<player_control>();
        interactor_rb = interactor.GetComponent<Rigidbody2D>();

        is_in = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        has_conversation_started = false;
        is_in = false;
    }
}
