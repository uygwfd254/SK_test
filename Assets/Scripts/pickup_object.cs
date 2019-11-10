using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_object : MonoBehaviour
{
    public Item item;

    public GameObject popup_manager;
    private popup_manager popup_script;

    private bool is_in = false;
    private GameObject interactor;
    private player_control interactor_script;
    private Rigidbody2D interactor_rb;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        popup_script = popup_manager.GetComponent<popup_manager>();
        sr = GetComponent<SpriteRenderer>();
        item.image = sr.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        // check
        bool is_interacting = interactor_script.get_is_interacting();
        if (is_in && is_interacting) {
            interactor_rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            StopAllCoroutines();
            StartCoroutine(popup(item));
        }
    }

    IEnumerator popup(Item item) {
        popup_script.display_popup(item);
        yield return new WaitForSeconds(2);

        popup_script.end_popup();
        interactor_rb.constraints = RigidbodyConstraints2D.None;
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        interactor = other.gameObject;
        interactor_script = interactor.GetComponent<player_control>();
        interactor_rb = interactor.GetComponent<Rigidbody2D>();

        is_in = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        is_in = false;
    }
}
