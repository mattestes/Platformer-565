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
            agent.speed = patrolSpeed;
            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) > 3)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
                character.Move(agent.desiredVelocity, false, false);
            }
            else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 3)
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

        }

        public void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.name == "PlayerArmature")
            {
                GameObject player = collision.gameObject;
                if(player.transform.position.y >= deathHeight)
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