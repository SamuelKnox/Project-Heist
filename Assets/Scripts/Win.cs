﻿using UnityEngine;
        first = true;
        if (other.gameObject.GetComponent<Selectable>() != null)
        {
            victory = true;
            Destroy(GameObject.Find("Guard"));
        }
            GUI.TextField(new Rect(50, 50, 200, 50), "You're Winner!");
            if (first)
            {
                Application.LoadLevel(Application.loadedLevel);
                //StartCoroutine("Wait");
                //first = false;
            }

    IEnumerable Wait()
    {
        yield return new WaitForSeconds(5.0f);
        Application.LoadLevel(Application.loadedLevel);
    }
