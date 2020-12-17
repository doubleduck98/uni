#include <fstream>
#include <iostream>
#include <iterator>
#include <vector>

using namespace std;

int gcd(int a, int b) {
    if (b > a)
        return gcd(b, a);
    if (b == 0)
        return a;
    return gcd(b, a % b);
}

int phi(int n) {
    int res = 1;
    for (int i = 2; i < n; ++i) {
        if (gcd(n, i) == 1)
            ++res;
    }
    return res;
}

int main(int argc, char const *argv[]) {
    if (argc != 2) {
        cerr << "./zad2 <liczba>" << endl;
        return EXIT_FAILURE;
    }
    ofstream file("phi.txt", ios::out);
    vector<int> vec;
    for (int i = 1; i <= stoi(argv[1]); ++i) {
        vec.push_back(phi(i));
    }
    copy(vec.begin(), vec.end(), ostream_iterator<int>(file, "; "));
}
