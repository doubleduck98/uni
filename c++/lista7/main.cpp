#include <iostream>
#include "wymierna.h"

using namespace std;
using namespace obliczenia;

int main() {
    wymierna w1(1, 3);
    wymierna w2(4, 3);
    wymierna w3(4, 8);
    cout << "w1:\t" << w1 << endl;
    cout << "w2:\t" << w2 << endl;
    cout << "w3:\t" << w3 << endl;
    cout << "w1+w2:\t" << w1 + w2 << endl;
    cout << "w2-w3:\t" << w2 - w3 << endl;
    cout << "w1*w3:\t" << w1 * w3 << endl;
    cout << "w2/w2:\t" << w2 / w2 << endl;
    cout << "!(w2-w3): " << !(w2-w3) << endl;
    cout << "-(-4/7):  " << -wymierna(-4,7) << endl;
    cout << !(w2-w3) << " -> int: " << (int)!(w2-w3) << endl;
    cout << !(w2-w3) << " -> double: " << (double)!(w2-w3) << endl;
    return 0;
}