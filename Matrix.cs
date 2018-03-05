using System;

public class Matrix {
    
    public delegate double ActivationFunc(double x);
    public int rows;
    public int cols;
    public double[,] data;
    public Matrix(int rows_, int cols_) {
        cols = cols_;
        rows = rows_;
        data = new double[rows, cols];
    }

    #region Add function
    public static Matrix Add(Matrix a, double b) {
        Matrix c = new Matrix(a.rows, a.cols);
        for (int i = 0; i < c.rows; i++) {
            for (int j = 0; j < c.cols; j++) {
                c.data[i, j] = a.data[i, j] + b;
            }
        }
        return c;
    }

    public static Matrix Add(Matrix a, float b) {
        Matrix c = new Matrix(a.rows, a.cols);
        for (int i = 0; i < c.rows; i++) {
            for (int j = 0; j < c.cols; j++) {
                c.data[i, j] = a.data[i, j] + b;
            }
        }
        return c;
    }

    public static Matrix Add(Matrix a, int b) {
        Matrix c = new Matrix(a.rows, a.cols);
        for (int i = 0; i < c.rows; i++) {
            for (int j = 0; j < c.cols; j++) {
                c.data[i, j] = a.data[i, j] + b;
            }
        }
        return c;
    }

    public static Matrix Add(Matrix a, Matrix b) {
        if (a.cols != b.cols || a.rows != b.rows) {
            throw new System.ArgumentException("Colomn and Rows do not match.");
        }

        Matrix c = new Matrix(a.rows, a.cols);
        for (int i = 0; i < c.rows; i++) {
            for (int j = 0; j < c.cols; j++) {
                c.data[i, j] = a.data[i, j] + b.data[i, j];
            }
        }
        return c;
    }
    #endregion
    #region Subtract function
    public static Matrix Subtract(Matrix a, double b) {
        Matrix c = new Matrix(a.rows, a.cols);
        for (int i = 0; i < c.rows; i++) {
            for (int j = 0; j < c.cols; j++) {
                c.data[i, j] = a.data[i, j] - b;
            }
        }
        return c;
    }

    public static Matrix Subtract(Matrix a, float b) {
        Matrix c = new Matrix(a.rows, a.cols);
        for (int i = 0; i < c.rows; i++) {
            for (int j = 0; j < c.cols; j++) {
                c.data[i, j] = a.data[i, j] - b;
            }
        }
        return c;
    }

    public static Matrix Subtract(Matrix a, int b) {
        Matrix c = new Matrix(a.rows, a.cols);
        for (int i = 0; i < c.rows; i++) {
            for (int j = 0; j < c.cols; j++) {
                c.data[i, j] = a.data[i, j] - b;
            }
        }
        return c;
    }

    public static Matrix Subtract(Matrix a, Matrix b) {
        if (a.cols != b.cols || a.rows != b.rows) {
            throw new System.ArgumentException("Colomn and Rows do not match.");
        }

        Matrix c = new Matrix(a.rows, a.cols);
        for (int i = 0; i < c.rows; i++) {
            for (int j = 0; j < c.cols; j++) {
                c.data[i, j] = a.data[i, j] - b.data[i, j];
            }
        }
        return c;
    }
    #endregion
    #region Muliplication function
    public static Matrix Scale(Matrix a, double b) {
        Matrix c = new Matrix(a.rows, a.cols);
        for (int i = 0; i < c.rows; i++) {
            for (int j = 0; j < c.cols; j++) {
                c.data[i, j] = c.data[i, j] * b;
            }
        }
        return c;
    }

    public static Matrix Multiply(Matrix a, Matrix b) {
        if (a.cols != b.rows) {
            throw new System.ArgumentException("Colomn and Rows do not match.");
        }
        Matrix c = new Matrix(a.rows,b.cols);
        for (int i = 0; i < c.rows; i++) {
            for (int j = 0; j < c.cols; j++) {
                double sum = 0;
                for (int k = 0; k < a.cols; k++) {
                    sum += a.data[i,k] * b.data[k,j];
                }
                c.data[i, j] = sum;
            }
        }
        return c;
    }
    #endregion

    public static Matrix Transpose(Matrix a) {
        Matrix b = new Matrix(a.cols, a.rows);
        for (int i = 0; i < b.rows; i++) {
            for (int j = 0; j < b.cols; j++) {
                b.data[i, j] = a.data[j, i];
            }
        }
        return b;
    }

    public static Matrix Map(Matrix a, ActivationFunc f) {
        for (int i = 0; i < a.rows; i++) {
            for (int j = 0; j < a.cols; j++) {
                a.data[i, j] = f(a.data[i, j]);
            }
        }
        return a;
    }

    public void Randomize(int seed = -1) {
        if (seed == -1) {
            seed = DateTime.Now.Millisecond;
        }
        Random rand = new Random(seed);
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                data[i, j] = (rand.NextDouble() * 2) - 1.0;
            }
        }
    }

    public double[] toArray() {
        double[] a = new double[data.Length];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                a[(i * cols) + j] = data[i, j];
            }
        }
       return a;
    }

    public static Matrix FromArray(double[] inputs) {
        Matrix a = new Matrix(inputs.Length,1);
        for (int i = 0; i < inputs.Length;i++) {
            a.data[i,0] = inputs[i];
        }
        return a;
    }

    public string Print() {
        string result = PrintSize(); ;
        for (int i = 0; i < cols; i++) {
            for (int j = 0; j < rows; j++) {
                result += (data[i, j] + " ");
            }
            result += "\n";
        }
        return result;
    }
    public string PrintSize() {
        string result = "DEBUG: [" + cols + "," + + rows + "]" + "\n";
        return result;
    }
}
