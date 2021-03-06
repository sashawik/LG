﻿using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerControlls : MonoBehaviourPunCallbacks
{
    private PhotonView photonView;
    [SerializeField] private TextMeshPro nickText;
    private PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        stats = GetComponent<PlayerStats>();

        nickText.SetText(photonView.Owner.NickName);

        if (photonView.IsMine)
        {
            nickText.color = Color.green;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Time.deltaTime * 5 * Vector3.up);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Time.deltaTime * 5 * Vector3.left);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Time.deltaTime * 5 * Vector3.right);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Time.deltaTime * 5 * Vector3.down);
            }

            if (Input.GetKey(KeyCode.Return))
            {

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().DealDamage(GetComponent<PlayerStats>().GetDamage());
        }

        if (other.gameObject.name == "Wall")
            GetComponent<PlayerStats>().DealDamage(10);
        Debug.Log(other.gameObject.name);
    }
}
