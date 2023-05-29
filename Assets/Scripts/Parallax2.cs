using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2 : MonoBehaviour
{
        public GameObject cam;
        private float length, startpos;
        public float parallaxEffect;

        void Start()
        {
            startpos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        void FixedUpdate()
        {
            float temp = (cam.transform.position.x * (1 - parallaxEffect));
            float dist = (cam.transform.position.x * parallaxEffect);

            Vector3 pos = transform.position;
            pos.x = startpos + dist;
            pos.y = cam.transform.position.y - (cam.transform.position.y / 10);
            transform.position = pos;

            if (temp > startpos + length) startpos += length;
            else if (temp < startpos - length) startpos -= length;
        }
}

