﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlls : MonoBehaviour
{

    public GameObject player;
    public GameObject scenePrefab;
    public GameObject scenePrefab2;
    public GameObject scenePrefab3;

    private int i;
    private bool start;
    private bool once;
    private GameObject[] del;
    private GameObject[] delcars;
    private GameObject delete;
    private GameObject fade;
    private GameObject fence;
    private GameObject scene;
    private Quaternion Rot;
    private PlayerController playerController;
    private int end;

    // Start is called before the first frame update
    void Start()
    {
        i = 2;
        start = false;
        once = true;
        Rot = player.transform.rotation;
        playerController = player.GetComponent<PlayerController>();
        Init();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.z % 100 < 10 && player.transform.position.z % 100 > -10 && once)
        {
            once = false;
            //new Object at i * 100 (vorrausschauend 2?)
            RandomScene();

            Instantiate(scene, new Vector3(0, 0, i * 100), Quaternion.identity);
            i++;
            if (start)
            {
                del = GameObject.FindGameObjectsWithTag("Scenes");
                for (int j = 0; j < del.Length; j++)
                {
                    if (del[j].transform.position.z + 50 < player.transform.position.z)
                    {
                        delete = del[j];
                        Destroy(delete);
                    }
                    if (del[j].transform.position.z < player.transform.position.z)
                    {
                        fence = del[j];
                        fence.transform.Find("Objects").Find("Fences").Find("EndFence").gameObject.SetActive(true);
                    }
                }
            }
            start = true;
        }

        if (player.transform.position.z % 100 < 60 && player.transform.position.z % 100 > 40)
        {
            once = true;
        }
    }

    private void Init()
    {
        for(i = 0; i<2; i++)
        {
            RandomScene();
            Instantiate(scene, new Vector3(0, 0, i * 100), Quaternion.identity);
            if (i == 0)
            {
                fence = GameObject.FindGameObjectWithTag("Scenes");
                fence.transform.Find("Objects").Find("Fences").Find("EndFence").gameObject.SetActive(true);
            }
        } 
    }

    private void RandomScene()
    {

        float random = UnityEngine.Random.Range(0.0f, 3.0f);
        if (random < 1)
        {
            scene = scenePrefab;
        }
        else if (random < 2)
        {
            scene = scenePrefab2;
        }
        else if (random <= 3)
        {
            scene = scenePrefab3;
        }

    }
}
