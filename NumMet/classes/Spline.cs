class CubicSpline {
    Vector xz;
    Vector yz;
    int countPoints;
    double[] M;
    int N = 0;
    public CubicSpline(Vector xx, Vector yy) {
        xz = xx.Copy();
        yz = yy.Copy();
        if (xx.Size == yy.Size) {
            countPoints = xx.Size;
            N = countPoints - 1;
            M = new double[countPoints];
        }
    }

    public void solveParameters() {
        M[0] = 0.0; M[N] = 0.0;
        double[] h = new double[N];
        for (int i = 0; i < N; i++) {
            h[i] = xz[i + 1] - xz[i];
        }
        Vector low = new Vector(N - 1);
        Vector sr = new Vector(N - 1);
        Vector up = new Vector(N - 1);
        Vector rez = new Vector(N - 1);
        Vector b = new Vector(N - 1);

        for (int i = 0; i < N - 1; i++) {
            if (i == 0)
                low[0] = 0.0;
            if (i > 0)
                low[i] = h[i] / 6.0;
            sr[i] = (h[i] + h[i + 1]) / 3.0;
            if (i < (N - 2)) 
                up[i] = h[i + 1] / 6.0;
            else
                up[i] = 0.0;
            b[i] = (yz[i + 2] - yz[i + 1]) / h[i + 1] - (yz[i + 1] - yz[i]) / h[i];
        }
        Matrix progonkaMatrix = new Matrix(low, sr, up);
        rez = LinearFn.ProgonkaMethod(new Matrix(low, sr, up), b);
        for (int i = 1; i < N; i++) {
            M[i] = rez[i - 1];
        }
    }

    public double getValue(double x) {
        int i;
        if (x < xz[0] || x > xz[N]) return 0;
        for (i = 0; i < N; i++) {
            if (x >= xz[i] && x <= xz[i + 1]) break;
        }
        double h = (xz[i + 1] - xz[i]);
        double s = 0;
        s += M[i] * Math.Pow((xz[i + 1] - x), 3) / (6 * h);
        s += M[i + 1] * Math.Pow((x - xz[i]), 3) / (6 * h);
        s += (yz[i + 1] - M[i + 1] * h * h / 6) * (x - xz[i]) / h;
        s += (yz[i] - M[i] * h * h / 6) * (xz[i + 1] - x) / h;
        return s;
    }
}
