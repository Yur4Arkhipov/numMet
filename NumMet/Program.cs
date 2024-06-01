//Non-linear alg
/* double root1 = NonLinearFn.BisectionMethod(1.0, 2.0, 0.0001, x => x*x*x - x - 2);
Console.WriteLine($"BisectionMethod / Root: {root1}\n");
double root2 = NonLinearFn.Newton(1.5, 0.001, Math.Cos);
Console.WriteLine($"Newton / Root: {root2}\n");
double root3 = NonLinearFn.SimpleIteration(0.5, 0.001, x => x * x);
Console.WriteLine($"SimpleIteration / Root: {root3}\n");
double root4 = NonLinearFn.ChordMethod(8, 3, 0.001, x => x * x * x - 18*x - 83);
Console.WriteLine($"ChordMethod / Root: {root4}\n"); */

//Systems lianear alg equations
/* double[,] matrix = {{3,2,-5},
                    {2,-1,3},
                    {1,2,-1}};
double[] vector = {-1,13,9};
            
double[,] matrixDop = {{1,3,-2, 0, -2},
                    {3,4,-5,1,-3},
                    {-2,-5,3,-2,2},
                    {0,1,-2,5,3},
                    {-2,-3,2,3,4}};
double[] vectorDop = {0.5,5.4,5.0,7.5,3.3};

double[,] matrixToSquare = {{2,1,4},
                            {1,1,3},
                            {4,3,14}};
double[] vectorToSquare = {16,12,52};

double[,] matrixToProgonka = {{2,-1,0},
                              {5,4,2},
                              {0,1,-3}};
double[] vectorToProgonka = {3,6,2};

double[,] matrixToSquare2 = {{4,1},
                            {1,0.3472}};
double[] vectorToSquare2 = {20,6.1666};


Matrix A1 = new Matrix(matrix);
Vector B1 = new Vector(vector);
Matrix A2 = new Matrix(matrix);
Vector B2 = new Vector(vector);
Matrix A3 = new Matrix(matrixToSquare);
Vector B3 = new Vector(vectorToSquare);
Vector BDop = new Vector(vectorDop);
Matrix ADOp = new Matrix(matrixDop);
Vector progonkaVector = new Vector(vectorToProgonka);
Matrix progonkaMatrix = new Matrix(matrixToProgonka);
Matrix matrixSquare2 = new Matrix(matrixToSquare2);
Vector vectorSquare2 = new Vector(vectorToSquare2);

Matrix.PrintMatrix(A1, "draft");
System.Console.Write("Vector: ");
foreach (var item in vector) {
    System.Console.Write(item + " ");
}
System.Console.WriteLine();

System.Console.WriteLine("Gauss: ");
Vector Gauss = LinearFn.GaussMethod(A1, B1);
Console.WriteLine(Gauss.ToString());
System.Console.WriteLine("Successive approximation: ");
Vector SuccessiveApproximationMethod = LinearFn.SuccessiveApproximationMethod(A2, B2);
Console.WriteLine(SuccessiveApproximationMethod.ToString());
System.Console.WriteLine("Square roots:");
Vector SquareRootsMethod = LinearFn.SquareRootsMethod(A3, B3);
Console.WriteLine(SquareRootsMethod.ToString());
System.Console.WriteLine("Progonka:");
Vector ProgonkaMethod = LinearFn.ProgonkaMethod(progonkaMatrix, progonkaVector);
Console.WriteLine(ProgonkaMethod.ToString());
System.Console.WriteLine("Square roots method 2");
Vector SquareRootsMethod2 = LinearFn.SquareRootsMethod(matrixSquare2, vectorSquare2);
System.Console.WriteLine(SquareRootsMethod2.ToString()); */

/* Matrix A = new(3, 3);
A.SetRow(0, new Vector(new double[] {1, 5, 9}));
A.SetRow(1, new Vector(new double[] {6, 2, 1}));
A.SetRow(2, new Vector(new double[] {7, 7, 4}));
Matrix Q, R;
LinearFn.GramSchmidt(A, out Q, out R);
Matrix.PrintMatrix(Q, "Q:");
Matrix.PrintMatrix(R, "R:");

double[,] matrixToGramShmidt = {{2,-1,0},
                                {5,4,2},
                                {0,1,-3}};
double[] vectorToGramShmidt = {3,6,2};
Matrix gramShmidtMatrix = new Matrix(matrixToGramShmidt);
Vector gramShmidtVector = new Vector(vectorToGramShmidt);

Vector result_gaus = LinearFn.GaussMethod(gramShmidtMatrix, gramShmidtVector);
Vector result_gramSchmidt = LinearFn.Solve_GramSchmidt(gramShmidtMatrix, gramShmidtVector);
Console.WriteLine("Result gauss: ");
Console.WriteLine(result_gaus);
Console.WriteLine("Result gramSchmidt: ");
Console.WriteLine(result_gramSchmidt); */

/* Vector xx = new Vector(new double[] { 1, 2.2, 3, 5, 7});
Vector yy = new Vector(new double[] { 6, 4.3, 9.8, 1.6, 2.9});
Spline spline = new Spline(xx, yy);
spline.solveParameters();
List<double> arrX = new List<double>(1);
List<double> arrY = new List<double>(1);
for (double i = 1; i <= 7; i += 0.1) {
    arrX.Add(i);
}
for (double valueX = 1; valueX <= 7; valueX += 0.1) {
    double valueY = spline.getValue(valueX);
    arrY.Add(valueY);
    // Console.WriteLine($" Value x: {valueX} Value y: {valueY}");
}
System.Console.WriteLine($"X: {string.Join(",", arrX)}");
System.Console.WriteLine();
System.Console.WriteLine($"Y: {string.Join(",", arrY)}");


System.Console.WriteLine(arrX.Count);
System.Console.WriteLine(arrY.Count);
 */


//МНК
/* Vector x1 = new Vector(new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
Vector y1 = new Vector(new double[] { 0, 14, 18, 20, 22, 24, 26, 28, 30, 32, 34 });
MinRect.Fn[] fns1 = new MinRect.Fn[] { x => x, x => x * x };

MinRect kv1 = new MinRect(x1, y1, fns1);
kv1.ComputeParameters();
Console.WriteLine("Параметры: {0}", kv1.param);
Console.WriteLine("Ошибка: {0}", kv1.GetError());

Vector x2 = new Vector(new double[] { 2, 4, 6, 12 });
Vector y2 = new Vector(new double[] { 8, 5.25, 3.5, 3.25});
MinRect.Fn[] fns2 = new MinRect.Fn[] { x => 1, x => 1 / x };

MinRect kv2 = new MinRect(x2, y2, fns2);
kv2.ComputeParameters();
Console.WriteLine("Параметры: {0}", kv2.param);
Console.WriteLine("Ошибка: {0}", kv2.GetError()); */


//Интегралы
/* Console.WriteLine("\nИнтегралы");
System.Console.WriteLine("Функция: x^2");
System.Console.WriteLine("Нижний предел: -1");
System.Console.WriteLine("Верхний предел: 1");
Console.WriteLine("Метод прямоугольника");
double resultRect = Integral.RectangleMethod(-1, 1, 0.001, x => x * x * x);
System.Console.WriteLine($"Результат: {resultRect}");

Console.WriteLine("Метод трапеций");
double resultTrap = Integral.TrapezoidMethod(-1, 1, 0.001, x => x * x * x);
System.Console.WriteLine($"Результат: {resultTrap}");

Console.WriteLine("Метод Симпсона");
double resultSimps = Integral.SimpsonMethod(-1, 1, 0.001, x => x * x * x);
System.Console.WriteLine($"Результат: {resultSimps}");

Console.WriteLine("Двойной интеграл");
double resultDoubleIntegral = Integral.DoubleIntegral(0, 1, 0, 2, 0.001, (x, y) => x * y * y);
System.Console.WriteLine($"Результат: {resultDoubleIntegral}"); */

//Дифференциальные уравнения

Console.WriteLine("\nДифференциальные уравнения");
Console.WriteLine("tn = 0");
Console.WriteLine("tk = 1");
Console.WriteLine("xn[0] = 0, xn[1] = 1");
Console.WriteLine("m = 10");
Vector xn = new Vector(new double[] { 0, 1 });
Console.WriteLine("Аналитическое решение");

for (double t = 0; t < 1.0; t += 0.1) {
    Console.WriteLine("t={0} Sin(t)={1} Cos(t)={2}", Math.Round(t,4), Math.Round(Math.Sin(t), 4), Math.Round(Math.Cos(t), 4));
}

Console.WriteLine("\nМетод Эйлера");
Matrix Euler = Differential.EulerMethod(0, 1, xn, 10, D);
for (int i = 0; i < Euler.Rows; i++) {
    for (int j = 0; j < Euler.Columns; j++) {
        Euler[i, j] = Math.Round(Euler[i, j], 4);
    }
}
Console.WriteLine($"Ответ:");
Matrix.PrintMatrix(Euler, "Эйлер");

Console.WriteLine("\nМетод Рунге - Кутты 2-го порядка");
Matrix RK2 = Differential.RungeKutta2Method(0, 1, xn, 10, D);
RK2 = roundMatrix(RK2);
Console.WriteLine($"Ответ:");
Matrix.PrintMatrix(RK2, "Рунге - Кутты 2");

Console.WriteLine("\nМетод Рунге - Кутты 4-го порядка");
Matrix RK4 = Differential.RungeKutta4Method(0, 1, xn, 10, D);
RK4 = roundMatrix(RK4);
Console.WriteLine($"Ответ:");
Matrix.PrintMatrix(RK4, "Рунге - Кутты 4");

Console.WriteLine("\nМетод Адамса");
Matrix Adams = Differential.AdamsMethod(0, 1, xn, 10, D);
Adams = roundMatrix(Adams);
Console.WriteLine($"Ответ:");
Matrix.PrintMatrix(Adams, "Адамс");

static Vector D(double t, Vector zx) {
    return new Vector([zx[1], -zx[0]]);
}

static Matrix roundMatrix(Matrix m) {
    for (int i = 0; i < m.Rows; i++) {
        for (int j = 0; j < m.Columns; j++) {
            m[i, j] = Math.Round(m[i, j], 4);
        }
    }
    return m;
}

