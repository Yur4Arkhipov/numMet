class LinearFn {

    // решение СЛАУ методом Гаусса
    public static Vector GaussMethod(Matrix matrix, Vector vector) {
        //проверка на корректность входных данных
        if (matrix.Columns != vector.Size) {
            throw new ArgumentException("Несоответствие количества аргументов и вектора");
        };
        for (int i = 0; i < matrix.Rows - 1; i++) {
            int j = i;
            double mainDiagonalElement = matrix[i,j];
            if (mainDiagonalElement == 0) {
                throw new ArgumentException("Главная диагональ имеет 0");
            }
            if (mainDiagonalElement != 1) {
                for (int k = 0; k < matrix.Columns; k++) {
                    matrix[i, k] /= mainDiagonalElement;
                }
                //изменение элемента вектора
                vector[j] /= mainDiagonalElement;
            }
            // прямой ход
            for (int k = i + 1; k < matrix.Rows; k++) {
                Vector currentRow = matrix.GetRow(k);
                for (int p = 0; p < matrix.Columns; p++) {
                    if (matrix[k, p] != 0) {
                        double newElement = matrix[k, p] - matrix[k, j] * matrix[i, p]; 
                        currentRow.SetElement(newElement, p);
                    }
                }
                vector[k] = vector[k] - matrix[k, j] * vector[i];
                matrix.SetRow(k, currentRow);
            }

        }

        //Получение решения после приведения к верхней треугольной матрице
        return Matrix.Upper(matrix, vector);
    }

    //решение СЛАУ методом последовательных приближений
    public static Vector SuccessiveApproximationMethod(Matrix A, Vector B) {
            if (A.Rows != A.Columns) return null;
            if (A.Rows != B.Size) return null;

            int n = A.Rows;
            double eps = 0.00000001;
            int max;
            double tmp;

            for (int j = 0; j < n; j++)
            {
                max = j;
                for (int i = j + 1; i < n; i++)
                {
                    if (Math.Abs(A[i, j]) > Math.Abs(A[max, j])) { max = i; };
                }

                if (max != j)
                {
                    Vector temp = A.GetRow(max); A.SetRow(max, A.GetRow(j)); A.SetRow(j, temp);
                    tmp = B[max]; B[max] = B[j]; B[j] = tmp;

                }
                if (Math.Abs(A[j, j]) < eps) return null;

            }

            Vector beta = new Vector(n);
            for (int i = 0; i < beta.Size; i++)
            {
                beta[i] = B[i] / A[i, i];
            }

            Matrix alpha = new Matrix(n, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j) alpha[i, j] = A[i, j] / A[i, i];
                    else alpha[i, j] = 0;
                }
                beta[i] = B[i] / A[i, i];
            }

            Vector prev_x = beta;
            Vector current_x;
            Vector delta;

            do
            {
                current_x = beta - alpha * prev_x;
                delta = current_x - prev_x;
                prev_x = current_x;
            }
            while (delta.Norma1() > eps);

            return prev_x;
        }

    // метод квадратных корней
   public static Vector SquareRootsMethod(Matrix matrix, Vector vector) {
        int n = matrix.Rows;
        var L = new Matrix(new double[n, n]);
        var y = new Vector(new double[n]);
        var x = new Vector(new double[n]);

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < i + 1; j++) {
                double sum = 0.0;
                if (j == i) {
                    for (int k = 0; k < j; k++) {
                        sum += Math.Pow(L[i, k], 2);
                    }
                    L[i, j] = Math.Sqrt(matrix[i, i] - sum);
                }
                else {
                    for (int k = 0; k < j; k++) {
                        sum += (L[i, k] * L[j, k]);
                    }
                    L[i, j] = (matrix[i, j] - sum) / L[j, j];
                }
            }
        }

        // Solving Ly = b
        for (int i = 0; i < n; i++) {
            double sum = 0.0;
            for (int j = 0; j < i; j++) {
                sum += L[i, j] * y[j];
            }
            y[i] = (vector[i] - sum) / L[i, i];
        }

        // Solving L^T x = y
        var LT = L.Trans();
        for (int i = n - 1; i >= 0; i--) {
            double sum = 0.0;
            for (int j = i + 1; j < n; j++) {
                sum += LT[i, j] * x[j];
            }
            x[i] = (y[i] - sum) / LT[i, i];
        }

        return x;
    }

}