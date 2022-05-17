using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class EnemyBehavior : MonoBehaviour
    {
        public NavMeshAgent agent;
        public ThirdPersonCharacter character;

        public float triggerRange;
        public float deathHeight;

        public float patrolRange;

        public enum State
        {
            PATROL,
            CHASE
        }
        public State state;
        private bool alive;

        //patrolling
        public GameObject[] waypoints;
        private int waypointInd;
        public float patrolSpeed;

        //chasing
        public float chaseSpeed;
        public GameObject target;

        float currentY;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updatePosition = true;
            agent.updateRotation = false;
            waypointInd = 0;

            state = EnemyBehavior.State.PATROL;
            alive = true;

            target = GameObject.FindGameObjectWithTag("Player");

            StartCoroutine("FSM");
        }

        IEnumerator FSM()
        {
            while (alive)
            {
                switch (state)
                {
                    case State.PATROL:
                        Patrol();
                        break;
                    case State.CHASE:
                        Chase();
                        break;
                }
                yield return null;
            }
        }

        void Patrol()
        {
            // Debug.Log(waypointInd);
            agent.speed = patrolSpeed;
            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) > patrolRange)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
                character.Move(agent.desiredVelocity, false, false);
            }
            else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= patrolRange)
            {
                waypointInd += 1;
                if (waypointInd >= waypoints.Length)
                {
                    waypointInd = 0;
                }
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }

        void Chase()
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(target.transform.position);
            character.Move(agent.desiredVelocity, false, false);

        }

        void Update()
        {
            if(Vector3.Distance(this.transform.position, target.transform.position) <= triggerRange)
            {
                state = EnemyBehavior.State.CHASE;
            }
            //Debug.Log(this.gameObject.name + ": " + this.gameObject.transform.position.y);
            currentY = this.gameObject.transform.position.y;
        }

        public void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.name == "PlayerArmature")
            {
                GameObject player = collision.gameObject;
                // This is an incredibly hacky solution to a mysterious problem, but for some reason,
                // this.gameObject.transform.position.y was giving the wrong value when called in here,
                // so I'm just storing the value in Update (which gives the correct value), then looking
                // at the value that I stored.
                deathHeight = currentY;
                //Debug.Log("current Y: " + currentY);
                Debug.Log(this.gameObject.name + " hit height: " + deathHeight);
                Debug.Log("player height:" + player.transform.position.y);
                if (player.transform.position.y >= deathHeight)
                {
                    alive = false;
                    GameObject score = GameObject.FindGameObjectWithTag("Score");
                    score.GetComponent<Score>().addScore(100);
                    Destroy(this.gameObject);
                }
                else
                {
                    GameObject heart = GameObject.FindGameObjectWithTag("Heart1");
                    heart.GetComponent<HeartDepletion>().removeHeart();
                }
            }
        }
    }
}