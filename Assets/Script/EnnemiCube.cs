﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiCube : Ennemi
{
    GameObject player;
    public float speed = 5;
    Rigidbody rdb;
    AudioSource audioSource;
    public AudioMusic audioMusic;
    public GameObject particuleSystemeDeath;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rdb = GetComponent<Rigidbody>();
        audioSource = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();

    }
    private void FollowPlayer()
    {
        rdb.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime));
    }
    public override void Die()
    {
        audioSource.PlayOneShot(audioMusic.soundToPlay);
        Instantiate(particuleSystemeDeath, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
