#include <algorithm>
#include <fstream>
#include <iostream>
#include <map>
#include <random>

using namespace std;

int main(int argc, char const* argv[]) {
    if (argc != 3) {
        cerr << "./zad3 [długość tekstu] [nazwa pliku]" << endl;
        return EXIT_FAILURE;
    }

    random_device rd;
    mt19937 gen(rd());
    vector<char> letters{'e', 't', 'a', 'o', 'i', 'n', 's', 'r', 'h',
                         'd', 'l', 'u', 'c', 'm', 'f', 'y', 'w', 'g',
                         'p', 'b', 'v', 'k', 'x', 'q', 'j', 'z'};
    vector<double> weights{12.02, 9.1,  8.12, 7.68, 7.31, 6.95, 6.28,
                           6.02,  5.92, 4.32, 3.98, 2.88, 2.71, 2.61,
                           2.3,   2.11, 2.89, 2.03, 1.82, 1.49, 1.11,
                           0.69,  0.17, 0.11, 0.1,  0.07};
    discrete_distribution<int> dist(weights.begin(), weights.end());

    // test dla rozkładu
    // map<int, int> m;
    // for (int n = 0; n < 10000; ++n) {
    //     ++m[dist(gen)];
    // }
    // for (auto p : m) {
    //     cout << letters[p.first] << " " << p.second << " razy" << endl;
    // }

    ofstream out;
    try {
        out = ofstream(argv[2], ios::out);
    } catch (const exception& ex) {
        cerr << "błąd" << endl << ex.what() << endl;
    }

    auto n = atoi(argv[1]);
    binomial_distribution<int> bin{12, 0.5};
    int ns = min(n, bin(gen));
    for (; n > 0; --n) {
        if (ns == 0) {
            out << " ";
            n -= 1;
            ns = min(n, bin(gen));
        }
        out << letters[dist(gen)];
        ns -= 1;
    }
}
