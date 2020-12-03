#include <complex>
#include <fstream>
#include <iostream>
#include <vector>

using namespace std;

// dla 0 < Re(z) < 1
complex<double> dzeta(complex<double> z, int iter) {
    complex<double> res{0, 0};
    for (int n = 1; n <= iter; ++n) {
        res += pow(-1.0, (double)n + 1) / pow(n, z);
    }
    return res / (1.0 - (2.0 / pow(2.0, z)));
}

int main() {
    vector<complex<double>> vars;
    ofstream f("riemann.csv", ios::out);
    for (double i = -10; i < 10; i += 0.01) {
        auto c = dzeta(complex<double>{0.5, (double)i}, 10000);
        f << i << ", " << c.real() << ", " << c.imag() << endl;
    }
    f.close();
}