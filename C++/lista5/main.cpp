#include <iostream>
#include <initializer_list>
#include "wielomian.h"

int main() {
    wielomian a, b, w;
    a = wielomian(initializer_list<double>{9, 9, 7});
    b = wielomian(initializer_list<double>{6, 4, 3, 2, 1, 5, 33, 4942, 0, 2});
    w = b;
    for (int i = 0; i < 100000; ++i) {
        if(i % 10000 == 0)
            cout << i << endl;
        w += a;
        w -= a;
    }
    cout << w << endl;
    return 0;
}