﻿using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace FamilyWikGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform startPosition;
        public GameObject playerPferab;
        [SerializeField] private Slider PlayerHealdSlider;

        public static GameManager _instance;

        // Start is called before the first frame update
        void Start()
        {
            InitPlayer();
            Init();
            PlayerHealdSlider.maxValue = 100;
        }
        public void UpdateUI(int health)
        {
            PlayerHealdSlider.value = health;
        }
        void Init()
        {
            if (_instance == null)
                _instance = this;
            else Destroy(gameObject);
            DontDestroyOnLoad(this);
        }

        void InitPlayer()
        {
            PhotonNetwork.Instantiate(playerPferab.name, startPosition.position, Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void ShowChat()
        {
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log(newPlayer.NickName);
            gameObject.name = newPlayer.NickName;
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Debug.Log(otherPlayer.NickName);
        }
    }
}