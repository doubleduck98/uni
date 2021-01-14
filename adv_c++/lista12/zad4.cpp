#include <iostream>

using namespace std;

template <size_t N, typename T = double>
constexpr T inner(T *x, T *y) {
    T acc = 0;
    for (size_t i = 0; i < N; ++i) {
        acc += x[i] * y[i];
    }
    return acc;
}

int main() {
    int i1[]{2, 3, 4, 5};
    int i2[]{1, 1, 1, 1};
    cout << inner<4, int>(i1, i2) << endl;
    double d1[]{2.0, 3.0, 4.5, 5.5};
    double d2[]{1.0, 1.5, 1.0, 1.0};
    cout << inner<4>(d1, d2) << endl;
}