using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Matr : MonoBehaviour
    {
        public GameObject mirror;
        private Matrix3x3 mtr;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            mtr = Matrix3x3.Euler(mirror.transform.rotation.x, mirror.transform.rotation.y, mirror.transform.rotation.z);
            Vector3 vectorFoward = Matrix3x3.multiply(mtr, Vector3.forward);
            Vector3 vectorUp = Matrix3x3.multiply(mtr, Vector3.up);
            print(mtr.matr[0,0]);
            print(mtr.matr[0, 1]);
            print(mtr.matr[0, 2]);
            print(mtr.matr[1, 0]);
            print(mtr.matr[1, 1]);
            print(mtr.matr[1, 2]);
            print(mtr.matr[2, 0]);
            print(mtr.matr[2, 1]);
            print(mtr.matr[2, 2]);
            print("");
            Debug.DrawLine(new Vector3(0, 0, 0), vectorFoward);
            Debug.DrawLine(new Vector3(0, 0, 0), vectorUp);
            //transform.rotation.x = Matrix3x3.multiply(mtr, new Vector3(1,0,0));
            //print(vectorFoward + " " + Vector3.forward);
            //transform.rotation = 
            //Matrix3x3 mtr = 
            //mirror.transform.rotation;
            transform.LookAt(vectorFoward, vectorUp);
            //transform.position += Vector3.forward * Time.deltaTime;
            //transform.position += Vector3.up * Time.deltaTime;
        }
    }
}