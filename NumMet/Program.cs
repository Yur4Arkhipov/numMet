//Non-linear alg
/* double root1 = NonLinearFn.BisectionMethod(1.0, 2.0, 0.0001, x => x*x*x - x - 2);
Console.WriteLine($"BisectionMethod / Root: {root1}\n");
double root2 = NonLinearFn.Newton(1.5, 0.001, Math.Cos);
Console.WriteLine($"Newton / Root: {root2}\n");
double root3 = NonLinearFn.SimpleIteration(0.5, 0.001, x => x * x);
Console.WriteLine($"SimpleIteration / Root: {root3}\n"); */

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

Matrix m = new Matrix(4, 4);
m.SetRow(0, new Vector(new double[] { 20.0, 1.0, 2.0, 1.0 }));
m.SetRow(1, new Vector(new double[] { 1.0, 25.0, 9.0, 2.0 }));
m.SetRow(2, new Vector(new double[] { 19.0, 1.0, 30.0, 3.0 }));
m.SetRow(3, new Vector(new double[] { 2.0, 9.0, 9.0, 27.0 }));
Vector b = new Vector(new double[] { 10.0, 16.0, 2.0, 7.0 });
Vector result_gaus = LinearFn.GaussMethod(m, b);
Vector result_gramSchmidt = LinearFn.Solve_ModifiedGramSchmidt(m, b);
Console.WriteLine("Result gauss: ");
Console.WriteLine(result_gaus);
Console.WriteLine("Result gramSchmidt: ");
Console.WriteLine(result_gramSchmidt);

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

/* Console.WriteLine("Test Eiler Diff Ur");
Vector xn = new Vector(2); xn[0] = 0;xn[1] = 1.0;
Matrix reEiler = Differential.Euler(0.0, 1.0, xn, 10, PR);
Console.WriteLine("t        x1        x2         x1a        x2a");
for(int k = 0; k <= 10; k++) {
    double t = k * 0.1;
    double x1a = Math.Sin(t); double x2a = Math.Cos(t);
    Vector el = reEiler.GetColumn(k);
    Console.WriteLine("t={0,4}\t x1={1,6}\t x2={2,6}\t   Analitic {3,6}\t  {4,6}", t,el[1],el[2], x1a, x2a);
}            Console.ReadKey(); */

