﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;


public class SPHManager : MonoBehaviour
{
    //Import
    [Header("Import")]
    [SerializeField] private GameObject sphColliderPrefab = null;
    private EntityManager manager;


    void Start()
    {

        //Import
        manager = World.Active.EntityManager;


        //Setup



    }

    void Update()
    {
        
    }


    void AddColliders()
    {
        //Find all colliders
        GameObject[] colliders = GameObject.FindGameObjectsWithTag("SPHCollider");

        //Turn them into entities
        NativeArray<Entity> entities = new NativeArray<Entity>(colliders.Length, Allocator.Temp);
        manager.Instantiate(sphColliderPrefab, entities);


        //Set data
        for (int i = 0; i < colliders.Length; i++)
        {
            manager.SetComponentData(entities[i], new SPHCollider
            {
                position = colliders[i].transform.position,
                right = colliders[i].transform.right,
                up = colliders[i].transform.up,
                scale = new float2(colliders[i].transform.localScale.x / 2f, colliders[i].transform.localScale.y / 2f)
            });
        }

        //Done
        entities.Dispose();
    }

    
    void AddParticles(int _amount)
    {   
        NativeArray<Entity> entities = new NativeArray<Entity>(_amount, Allocator.Temp);
        manager.Instantiate(sphParticlePrefab, entities); 

        for (int i = 0; i < _amount; i++)
        {
            manager.SetComponentData()

        }
      


    }
    
}
