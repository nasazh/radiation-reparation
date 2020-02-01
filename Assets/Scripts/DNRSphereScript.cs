﻿using UnityEngine;

public class DNRSphereScript : MonoBehaviour {

    public string direction = "S";

    public GlobalState globalState;

    // Start is called before the first frame update
    void Start() {
        globalState = GameObject.Find("GlobalState").GetComponent<GlobalState>();
    }

    // Update is called once per frame
    void Update() {
        if ((direction == "S") && (transform.localPosition.y <= Constants.SCANNER_BELT_Y)) {
            transform.localPosition.Set(transform.localPosition.x, Constants.SCANNER_BELT_Y, transform.localPosition.z);
            direction = "E";
        }

        if (transform.localPosition.x >= Constants.OUTPUT_BELT_X) {
            transform.localPosition.Set(Constants.OUTPUT_BELT_X, transform.localPosition.y, transform.localPosition.z);
            direction = "N";
        }

        if (canMove()) {
            Move();
        }

    }

    private void Move() {
        float oldX = transform.localPosition.x;
        switch (direction) {
            case "S" :
                transform.Translate(Vector3.down * Time.deltaTime * Constants.BALLS_SPEED);
                break;
            case "E" :
                transform.Translate(Vector3.right * Time.deltaTime * Constants.BALLS_SPEED);
                break;
            case "N" :
                transform.Translate(Vector3.up * Time.deltaTime * Constants.BALLS_SPEED);
                break;
        }
        float newX = transform.localPosition.x;

        if ((oldX <= globalState.GetDestroyedX()) && (newX >= globalState.GetDestroyedX())) {
            globalState.destroyedDNRx = 2000f;
        }

    }

    private bool canMove() {
        bool leftOfDead = globalState.GetDestroyedX() > transform.localPosition.x;
        bool rightOfSpawn = globalState.addedDNRx <= transform.localPosition.x;

        return leftOfDead && (rightOfSpawn || !globalState.skipDNRSpawn);
    }

    public void onDeath() {
        if (globalState.destroyedDNRx == 2000f) {
            globalState.destroyedDNRx = gameObject.transform.localPosition.x;
            Destroy(gameObject);
        }
    }

    void OnMouseExit() {
        onDeath();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        DNRSphereScript dnrHitter = col.gameObject.GetComponent<DNRSphereScript>();
        if (dnrHitter.direction == "N") {
            globalState.skipDNRSpawn = true;
            dnrHitter.direction = "E";
            Vector3 spawnLocation = new Vector3(transform.localPosition.x - 54, transform.localPosition.y, transform.localPosition.z);
            dnrHitter.gameObject.transform.SetPositionAndRotation(spawnLocation, Quaternion.identity);
            globalState.addedDNRx = dnrHitter.gameObject.transform.localPosition.x - 0.01f;
        }
    }

}
