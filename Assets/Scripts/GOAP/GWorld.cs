using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld {

    // Our GWorld instance
    private static readonly GWorld instance = new GWorld();
    // Our world states
    private static WorldStates world;
    // Queue of patients
    private static Queue<GameObject> patients;

    private static Queue<GameObject> patients_ER;

    private static Queue<GameObject> patient_Dead;
    // Queue of cubicles
    private static Queue<GameObject> cubicles;

    static GWorld() {

        // Create our world
        world = new WorldStates();
        // Create patients array
        patients = new Queue<GameObject>();
        patients_ER = new Queue<GameObject>();
        patient_Dead = new Queue<GameObject>();
        // Create cubicles array
        cubicles = new Queue<GameObject>();
        // Find all GameObjects that are tagged "Cubicle"
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        // Then add them to the cubicles Queue
        foreach (GameObject c in cubes) {

            cubicles.Enqueue(c);
        }

        // Inform the state
        if (cubes.Length > 0) {
            world.ModifyState("FreeCubicle", cubes.Length);
        }

        // Set the time scale in Unity
        Time.timeScale = 5.0f;
    }

    private GWorld() {

    }

    // Add patient
    public void AddPatient(GameObject p) {

        // Add the patient to the patients Queue
        if (p.gameObject.CompareTag("Patient_ER"))
            patients_ER.Enqueue(p);
        else
            patients.Enqueue(p);
    }

    // Remove patient
    public GameObject RemovePatient() {

        if (patients.Count == 0) return null;
        return patients.Dequeue();
    }

    public GameObject RemoveERPatient()
    {

        if (patients_ER.Count == 0) return null;
        return patients_ER.Dequeue();
    }

    public GameObject RemoveDead()
    {
        if (patient_Dead.Count == 0) return null;

        return patient_Dead.Dequeue();
    }

    public void AddDead(GameObject p)
    {
        patient_Dead.Enqueue(p);
    }

    // Add cubicle
    public void AddCubicle(GameObject p) {

        // Add the patient to the patients Queue
        cubicles.Enqueue(p);
    }

    // Remove cubicle
    public GameObject RemoveCubicle() {

        // Check we have something to remove
        if (cubicles.Count == 0) return null;
        return cubicles.Dequeue();
    }

    public static GWorld Instance {

        get { return instance; }
    }

    public WorldStates GetWorld() {

        return world;
    }
}
