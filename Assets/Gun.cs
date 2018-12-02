using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gun : MonoBehaviour {
    public GameObject enemy;
    private float[,] matriks_4x4 = {
        { 1, 0, 0, 0 },
        { 0, 1, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
    };
    private float[,] vec_position = { { 0 }, { 0 }, { 0 }, { 1 } };
    // Use this for initialization
    void Start()
    {

        //private float[,] vec_position = { {this.transform.rotation.x}, { this.transform.rotation.y }, { this.transform.rotation.z }, { 1 } };
    }

    // Update is called once per frame
    void Update()
    {
        float[,] enemy_pos = { { enemy.transform.rotation.x }, { enemy.transform.rotation.y }, { enemy.transform.rotation.z }, { 1 } };
        print(enemy_pos[1, 0]);
        //transformRotX(x_ang);
        float[,] rot_x = { { 1 }, { 0 }, { 0 }, { 1 } };
        float[,] rot_y = { { 0 }, { 1 }, { 0 }, { 1 } };
        float[,] rot_z = { { 0 }, { 0 }, { 1 }, { 1 } };

        /*float x_ang = Mathf.Acos((rot_x[0,0] * enemy_pos[0,0] + rot_x[1, 0] * enemy_pos[1, 0] + rot_x[2, 0] * enemy_pos[2, 0])/
            Mathf.Sqrt(rot_x[0, 0] * rot_x[0, 0] + rot_x[1, 0] * rot_x[1, 0] + rot_x[2, 0] * rot_x[2, 0]) *
            Mathf.Sqrt(enemy_pos[0, 0] * enemy_pos[0, 0] + enemy_pos[1, 0] * enemy_pos[1, 0] + enemy_pos[2, 0] * enemy_pos[2, 0]));
        
        float y_ang = Mathf.Acos((rot_y[0, 0] * enemy_pos[0, 0] + rot_y[1, 0] * enemy_pos[1, 0] + rot_y[2, 0] * enemy_pos[2, 0]) /
            Mathf.Sqrt(rot_y[0, 0] * rot_y[0, 0] + rot_y[1, 0] * rot_y[1, 0] + rot_y[2, 0] * rot_y[2, 0]) *
            Mathf.Sqrt(enemy_pos[0, 0] * enemy_pos[0, 0] + enemy_pos[1, 0] * enemy_pos[1, 0] + enemy_pos[2, 0] * enemy_pos[2, 0])); ;

        float z_ang = Mathf.Acos((rot_z[0, 0] * enemy_pos[0, 0] + rot_z[1, 0] * enemy_pos[1, 0] + rot_z[2, 0] * enemy_pos[2, 0]) /
            Mathf.Sqrt(rot_z[0, 0] * rot_z[0, 0] + rot_z[1, 0] * rot_z[1, 0] + rot_z[2, 0] * rot_z[2, 0]) *
            Mathf.Sqrt(enemy_pos[0, 0] * enemy_pos[0, 0] + enemy_pos[1, 0] * enemy_pos[1, 0] + enemy_pos[2, 0] * enemy_pos[2, 0])); ;
        print(Mathf.Cos(z_ang));*/

        float y = enemy.transform.position.y - transform.position.y;
        float x = enemy.transform.position.x - transform.position.x;
        float z = enemy.transform.position.z - transform.position.z;

        float x_ang = enemy.transform.rotation.x;
        float y_ang = enemy.transform.rotation.y;
        float z_ang = enemy.transform.rotation.z;
        float[,] vec_position_y = Multiplication(transformRotY(y_ang), rot_y);
        float[,] vec_position_x = Multiplication(transformRotX(x_ang), vec_position_y);
        float[,] vec_position = Multiplication(transformRotZ(z_ang), vec_position_x);



        
        //vec_position = Multiplication
        //vec_position = Multiplication(Multiplication(Multiplication(transformRotZ(z_ang), rot_z), Multiplication(transformRotX(x_ang), rot_x)), Multiplication(transformRotY(y_ang), rot_y));
        float f = transform.rotation.x;
        //Vector3 rotationVector;
        //rotationVector = new Vector3(vec_position[0, 0], vec_position[1, 0], vec_position[2, 0]);
        //transform.Rotate(rotationVector);
        float[,] rotatedForward = { { vec_position[0,0]}, { vec_position[0, 1] }, { vec_position[0, 2] }, { 1} };
        float[,] rotatedUp = { { vec_position[0, 0] }, { vec_position[0, 1] }, { vec_position[0, 2] }, { 1 } };
        //transform.LookAt(Multiplication());
    }

    private float[,] transformRotX(float teta)
    {
        float[,] matr = matriks_4x4;
        matr[1, 1] = Mathf.Cos(teta);
        matr[1, 2] = -Mathf.Sin(teta);
        matr[2, 1] = Mathf.Sin(teta);
        matr[2, 2] = Mathf.Cos(teta);
        return matr;
    }
    private float[,] transformRotY(float teta)
    {
        float[,] matr = matriks_4x4;
        matr[0, 0] = Mathf.Cos(teta);
        matr[0, 2] = Mathf.Sin(teta);
        matr[2, 0] = -Mathf.Sin(teta);
        matr[2, 2] = Mathf.Cos(teta);
        return matr;
    }
    private float[,] transformRotZ(float teta)
    {
        float[,] matr = matriks_4x4;
        matr[0, 0] = Mathf.Cos(teta);
        matr[0, 1] = -Mathf.Sin(teta);
        matr[1, 0] = Mathf.Sin(teta);
        matr[1, 1] = Mathf.Cos(teta);
        return matr;
    }

    static float[,] Multiplication(float[,] a, float[,] b)
    {
        if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
        float[,] r = new float[a.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                for (int k = 0; k < b.GetLength(0); k++)
                {
                    r[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        print(r[2, 0]);
        return r;
    }
}
