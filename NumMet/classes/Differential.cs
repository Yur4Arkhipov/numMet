delegate Vector PravDU(double t,Vector x);
class Differential {
    public delegate Vector Derivative(double t, Vector x);

    public static Vector DifferentialEquations(double t, Vector x)
    {
        Vector result = new Vector(2);
        result[0] = x[1];
        result[1] = -x[0];
        return result;
    }

    public static Matrix EulerMethod(double initialTime, double finalTime, Vector initialState, int numSteps, Derivative derivative)
    {
        //
        int dimension = initialState.Size;
        Matrix result = new Matrix(dimension + 1, numSteps + 1);
        double stepSize = (finalTime - initialTime) / numSteps;
        Vector column = new Vector(dimension + 1);
        column[0] = initialTime;

        for (int i = 0; i < dimension; i++)
            column[i + 1] = initialState[i];

        result.SetColumn(0, column);
        Vector xt = initialState.Copy();
        double t = initialTime;
        Vector derivativeValue;

        for (int k = 1; k <= numSteps; k++)
        {
            derivativeValue = derivative(t, xt);
            xt = xt + derivativeValue * stepSize;
            t += stepSize;
            column[0] = t;

            for (int i = 0; i < dimension; i++)
                column[i + 1] = xt[i];

            result.SetColumn(k, column);
        }

        return result;
    }

    public static Matrix RungeKutta2Method(double initialTime, double finalTime, Vector initialState, int numSteps, Derivative derivative)
    {
        int dimension = initialState.Size;
        Matrix result = new Matrix(dimension + 1, numSteps + 1);
        double stepSize = (finalTime - initialTime) / numSteps;
        Vector column = new Vector(dimension + 1);
        column[0] = initialTime;

        for (int i = 0; i < dimension; i++)
            column[i + 1] = initialState[i];

        result.SetColumn(0, column);
        Vector xt = initialState.Copy();
        double t = initialTime;

        for (int k = 1; k <= numSteps; k++)
        {
            Vector k1 = derivative(t, xt);
            Vector k2 = derivative(t + stepSize, xt + k1 * stepSize);
            xt = xt + (k1 + k2) * (stepSize / 2.0);
            t += stepSize;
            column[0] = t;

            for (int i = 0; i < dimension; i++)
                column[i + 1] = xt[i];

            result.SetColumn(k, column);
        }

        return result;
    }

    public static Matrix RungeKutta4Method(double initialTime, double finalTime, Vector initialState, int numSteps, Derivative derivative)
    {
        int dimension = initialState.Size;
        Matrix result = new Matrix(dimension + 1, numSteps + 1);
        double stepSize = (finalTime - initialTime) / numSteps;
        Vector column = new Vector(dimension + 1);
        column[0] = initialTime;

        for (int i = 0; i < dimension; i++)
            column[i + 1] = initialState[i];

        result.SetColumn(0, column);
        Vector xt = initialState.Copy();
        double t = initialTime;

        for (int k = 1; k <= numSteps; k++)
        {
            Vector k1 = derivative(t, xt);
            Vector k2 = derivative(t + stepSize / 2.0, xt + k1 * (stepSize / 2.0));
            Vector k3 = derivative(t + stepSize / 2.0, xt + k2 * (stepSize / 2.0));
            Vector k4 = derivative(t + stepSize, xt + k3 * stepSize);
            xt = xt + (k1 + 2 * k2 + 2 * k3 + k4) * (stepSize / 6.0);
            t += stepSize;
            column[0] = t;

            for (int i = 0; i < dimension; i++)
                column[i + 1] = xt[i];

            result.SetColumn(k, column);
        }

        return result;
    }

    public static Matrix AdamsMethod(double initialTime, double finalTime, Vector initialState, int numSteps, Derivative derivative)
    {
        int dimension = initialState.Size;
        Matrix result = new Matrix(dimension + 1, numSteps + 1);
        double stepSize = (finalTime - initialTime) / numSteps;
        Vector column = new Vector(dimension + 1);
        column[0] = initialTime;

        for (int i = 0; i < dimension; i++)
            column[i + 1] = initialState[i];

        result.SetColumn(0, column);
        Vector[] xt = new Vector[numSteps + 1];
        double[] t = new double[numSteps + 1];
        Vector[] derivatives = new Vector[numSteps + 1];

        t[0] = initialTime;
        xt[0] = initialState.Copy();
        derivatives[0] = derivative(t[0], xt[0]);

        for (int k = 1; k <= Math.Min(3, numSteps); k++)
        {
            t[k] = t[k - 1] + stepSize;
            derivatives[k] = derivative(t[k], xt[k - 1]);
            xt[k] = xt[k - 1] + derivatives[k] * stepSize;
            column[0] = t[k];

            for (int i = 0; i < dimension; i++)
                column[i + 1] = xt[k][i];

            result.SetColumn(k, column);
        }

        for (int k = 3; k < numSteps; k++)
        {
            t[k + 1] = t[k] + stepSize;
            xt[k + 1] = xt[k] + (stepSize / 24) * (55 * derivatives[k] - 59 * derivatives[k - 1] + 37 * derivatives[k - 2] - 9 * derivatives[k - 3]);
            derivatives[k + 1] = derivative(t[k + 1], xt[k + 1]);
            column[0] = t[k + 1];

            for (int i = 0; i < dimension; i++)
                column[i + 1] = xt[k + 1][i];

            result.SetColumn(k + 1, column);
        }

        return result;
    }
}