#include <fstream>
#include <iostream>
#include <random>

using namespace std;

int main() {
    random_device rd;
    mt19937 generator(rd());
    // przedziały
    uniform_real_distribution<> urd(1.0, 2.0);
    // n i ppd.
    binomial_distribution<> bin(10, 0.5);
    // średnia i odchylenie standardowe
    normal_distribution<> norm(10, 2);

    ofstream uniform("uniform.csv", ios::out);
    for (int i = 0; i < 1000; ++i) {
        uniform << urd(generator) << endl;
    }
    uniform.close();

    ofstream binomial("binomial.csv", ios::out);
    for (int i = 0; i < 1000; ++i) {
        binomial << bin(generator) << endl;
    }
    binomial.close();

    ofstream normal("normal.csv", ios::out);
    for (int i = 0; i < 1000; ++i) {
        normal << norm(generator) << endl;
    }
    normal.close();
}
