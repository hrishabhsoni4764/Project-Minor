using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    [Header("Prefabs")]
    public GameObject inventory;
    public GameObject fadeOverlay;
    public GameObject fadeScreen;
    public GameObject buttonPrompt;
    public GameObject dialoguePrompt;
    private Health health;
    void Awake()
    {
        health = FindObjectOfType<Health>();
        instance = this;
    }
}
