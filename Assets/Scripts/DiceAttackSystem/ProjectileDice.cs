using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DiceThrowing
{
    public class ProjectileDice : MonoBehaviour
    {

        [SerializeField]
        float speed = 10;

        [SerializeField]
        float maxSpeed = 10;
        [SerializeField]
        float lifetime = 2;
        Rigidbody rigidBody;
        // Start is called before the first frame update
        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            StartCoroutine(LifeTimer());
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (rigidBody.velocity.magnitude >= maxSpeed) return;

            rigidBody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        }



        IEnumerator LifeTimer() {

            yield return new WaitForSeconds(lifetime);
            Destroy(gameObject);


        }



        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag != "Player") Destroy(gameObject);

        }

    }




}