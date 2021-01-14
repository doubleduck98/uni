#include <iostream>

using namespace std;

template <int N>
struct lucas {
    constexpr int operator()() { return lucas<N - 1>()() + lucas<N - 2>()(); }
};

template <>
struct lucas<0> {
    constexpr int operator()() { return 2; }
};

template <>
struct lucas<1> {
    constexpr int operator()() { return 1; }
};

int main() {
    constexpr auto luc1 = lucas<41>()();
    constexpr auto luc2 = lucas<42>()();
    constexpr auto luc3 = lucas<43>()();
    constexpr auto luc4 = lucas<44>()();
    cout << luc1 << endl;
    cout << luc2 << endl;
    cout << luc3 << endl;
    cout << luc4 << endl;
}
