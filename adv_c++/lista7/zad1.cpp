#include <iostream>
#include <random>

using namespace std;

template <typename T>
void shuffle(vector<T>& vect) {
    static random_device rd;
    static mt19937 generator(rd());

    int size = vect.size();
    for (int i = 0; i < size; ++i) {
        int j = uniform_int_distribution<int>{i, size - 1}(generator);
        swap(vect[i], vect[j]);
    }
}

int main() {
    vector<int> vect{0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    for (auto i : vect) {
        cout << i << " ";
    }
    cout << endl;

    shuffle(vect);

    for (auto i : vect) {
        cout << i << " ";
    }
    cout << endl;
}