﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public enum EstadoIA {
        Atacando,
        Andando,
    }

    public EstadoIA estado;
    public float dano;

    NavMeshAgent agenteNM;
    Vida vida;
    Vida vidaJogador;

    void Awake() {
        agenteNM = GetComponent<NavMeshAgent>();
        vida = GetComponent<Vida>();
        vidaJogador = GameObject.FindWithTag("Player").GetComponent<Vida>();
    }

    void Update() {
        if (agenteNM.isStopped) {
            estado = EstadoIA.Atacando;
        } else {
            estado = EstadoIA.Andando;
        }

        if (estado == EstadoIA.Atacando) {
            vidaJogador.vida = vidaJogador.vida - dano * Time.deltaTime;
        }

        if (vida.vida <= 0) {
            Destroy(gameObject);
        }
    }
}
