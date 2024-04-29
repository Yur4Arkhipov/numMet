 //Non-linear alg
/* double root1 = NonLinearFn.BisectionMethod(1.0, 2.0, 0.0001, x => x*x*x - x - 2);
Console.WriteLine($"BisectionMethod / Root: {root1}\n");
double root2 = NonLinearFn.Newton(1.5, 0.001, Math.Cos);
Console.WriteLine($"Newton / Root: {root2}\n");
double root3 = NonLinearFn.SimpleIteration(0.5, 0.001, x => x * x);
Console.WriteLine($"SimpleIteration / Root: {root3}\n"); */

//Systems lianear alg equations
double[,] matrix = {{3,2,-5},
                    {2,-1,3},
                    {1,2,-1}};
double[] vector = {-1,13,9};
            
double[,] matrixDop = {{1,3,-2, 0, -2},
                    {3,4,-5,1,-3},
                    {-2,-5,3,-2,2},
                    {0,1,-2,5,3},
                    {-2,-3,2,3,4}};
double[] vectorDop = {0.5,5.4,5.0,7.5,3.3};
        
Matrix A1 = new Matrix(matrix);
Vector B1 = new Vector(vector);
Matrix A2 = new Matrix(matrix);
Vector B2 = new Vector(vector);
Matrix A3 = new Matrix(matrix);
Vector B3 = new Vector(vector);
Vector BDop = new Vector(vectorDop);
Matrix ADOp = new Matrix(matrixDop);
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

