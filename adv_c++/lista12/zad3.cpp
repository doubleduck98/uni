#include <iostream>

using namespace std;

template <int A, int B>
struct gcd {
    constexpr int operator()() { return gcd<B, A % B>()(); }
};

template <int A>
struct gcd<A, 0> {
    constexpr int operator()() { return A; }
};

int main() {
    cout << gcd<18, 6>()() << endl;
    cout << gcd<71, 42>()() << endl;
    cout << gcd<64, 48>()() << endl;
    cout << gcd<17, 7>()() << endl;
    cout << gcd<22, 33>()() << endl;
}