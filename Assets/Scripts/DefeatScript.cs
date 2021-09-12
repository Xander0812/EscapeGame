using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefeatScript : MonoBehaviour
{
    //Это скрипт передвижения врага, а так же на отправление информации о поражении в Game Controller

    [SerializeField] private GameObject player;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool playerIsNear = false;
    private bool beingHandled = false;


    //Мне удалось сделать так, чтобы враг не видел игрока через стену.
    //Вполне логично, что для этого я использовал лучи.
    void SearchForPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var ray = new Ray(this.transform.position, player.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Player")&& playerIsNear == true)
            {
                StartCoroutine(GameController.Instance.GameOverSequenceCorutine(false));
            }

        }
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
 
        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
        if (!beingHandled)
        {
            StartCoroutine(WaitForPlayerSpawn());
        }
        else
        {
            SearchForPlayer();
        }
    }

    private IEnumerator WaitForPlayerSpawn()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        beingHandled = true;
        StartCoroutine("SearchForPlayer");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

}
