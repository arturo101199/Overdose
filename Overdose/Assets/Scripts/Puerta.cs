﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Transform destino;
    public GameObject camera;
    public bool abierta;
    public Puerta puertaQueAbre;
    public Objeto llave;
    public AudioClip sonidoAbrir;
    public AudioClip sonidoCerrado;
}
