using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public struct Matrix3x3
    {
        public float[,] matr;

        public Matrix3x3(float [,] matr)
        {
            this.matr = matr;
        }
        static Matrix3x3 Rotate(float deg, int axis)
        {
            Matrix3x3 mrt;
            float angleInRad = deg;
            float cos = Mathf.Cos(angleInRad);
            float sin = Mathf.Sin(angleInRad);
            switch (axis)
            {
                case 1:
                    mrt = new Matrix3x3(new float[,]{ {1,0,0}, {0, cos, -sin } ,{0, sin, cos } });
                    break;
                case 2:
                    mrt = new Matrix3x3(new float[,] { { cos, 0, sin }, { 0, 1, 0 }, { -sin, 0 , cos } });
                    break;
                default:
                    mrt = new Matrix3x3(new float[,] { { cos, -sin, 0 }, { sin, cos, 0 }, { 0, 0, 1 } });
                    break;
            }

            return mrt;
        }
        public static Matrix3x3 Euler(float x, float y, float z)
        {
            Matrix3x3 matr_x = Rotate(x, 1);
            Matrix3x3 matr_y = Rotate(y, 2);
            Matrix3x3 matr_z = Rotate(z, 3);

            

            return multiply(multiply(matr_y, matr_x), matr_z);
        }

        static Matrix3x3 multiply(Matrix3x3 mt_1, Matrix3x3 mt_2)
        {
            float[,] a = mt_1.matr;
            float[,] b = mt_2.matr;
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            float[,] r = new float[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += (a[i, k] * b[k, j]);
                    }
                }
            }
            //print(r[2, 0]);
            return new Matrix3x3(r);
        }

        public static Vector3 multiply( Matrix3x3 mt_2, Vector3 mt_1)
        {
            float[,] b = { {mt_1.x }, { mt_1.y }, { mt_1.z } };
            float[,] a = mt_2.matr;
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
            //Debug.
            //print(r[2, 0]);
           // return new Vector3(r[0,0], r[1, 0], r[2, 0]);
           return new Vector3(r[0,0], r[1, 0], r[2, 0]);
        }

        //Matrix3x3 Euler(Vector3 eulerAngles)
        //{

        //}

    }
}
