#include <complex>
#include <iostream>

#define GAMMA_CONSTANT 0.5772156649

using namespace std;

complex<double> gamma(complex<double> z, int iter) {
    complex<double> res{1.0, 0};
    for (int n = 1; n <= iter; ++n) {
        res *= pow(1.0 + 1.0 / (double)n, z) / (1.0 + z / (double)n);
    }
    return res / z;
}

complex<double> inv_gamma(complex<double> z, int iter) {
    complex<double> res{1.0, 0};
    for (int n = 1; n <= iter; ++n) {
        res *= (1.0 + z / (double)n) * exp(-z / (double)n);
    }
    return res * z * exp(GAMMA_CONSTANT * z);
}

int main() {
    auto c = gamma(complex<double>(2, 3), 1000000);
    cout << c << endl;
    cout<< "***" << endl;
    c = inv_gamma(complex<double>(4, 1), 1000);
    cout << c << endl;
    c = inv_gamma(complex<double>(4, 1), 10000);
    cout << c << endl;
    c = inv_gamma(complex<double>(4, 1), 100000);
    cout << c << endl;
    c = inv_gamma(complex<double>(2, 3), 1000000);
    cout << c << endl;
}