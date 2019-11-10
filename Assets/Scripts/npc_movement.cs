using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_movement : MonoBehaviour
{
    public float follow_distance;
    private float speed;
    public GameObject follower;

    private bool is_following = false;
    private float distance;
    private Vector3 move;
    private float current_speed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        speed = player_movement.speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_following) {
            distance = Vector3.Distance(follower.transform.position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, follower.transform.position, current_speed * Time.deltaTime);

            if (distance >= follow_distance) {
                if (current_speed != speed) {
                    current_speed++;
                }
            } else {
                if (current_speed != 0) {
                    current_speed--;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        is_following = true;
    }
}
