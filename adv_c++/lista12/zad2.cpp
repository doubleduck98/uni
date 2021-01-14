#include <iostream>

using namespace std;

template <int N, int K>
struct binom {
    constexpr int operator()() {
        return binom<N - 1, K - 1>()() + binom<N - 1, K>()();
    }
};

template <int N>
struct binom<N, 0> {
    constexpr int operator()() { return 1; }
};

template <int N>
struct binom<N, N> {
    constexpr int operator()() { return 1; }
};

int main() {
    cout << binom<14, 5>()() << endl;
    cout << binom<12, 4>()() << endl;
    cout << binom<6, 5>()() << endl;
    cout << binom<8, 2>()() << endl;
}