#include <algorithm>
#include <fstream>
#include <iostream>
#include <map>
#include <string>

using namespace std;

int main(int argc, char const *argv[]) {
    if (argc != 2) {
        cerr << "podaj nazwe pliku" << endl;
        exit(-1);
    }

    ifstream file;
    try {
        file = ifstream(argv[1], fstream::in);
    } catch (const ifstream::failure &) {
        cerr << "błąd przy otwieraniu pliku" << endl;
    }

    int total = 0;
    map<char, int> let;
    string line;
    if (file.is_open()) {
        while (getline(file, line)) {
            line.erase(remove_if(line.begin(), line.end(), ::isspace),
                       line.end());
            transform(line.begin(), line.end(), line.begin(), ::tolower);
            line.erase(
                remove_if(line.begin(), line.end(),
                          [](auto c) { return !(c >= 'a' && c <= 'z'); }),
                line.end());
            for (char c : line) {
                ++let[c];
                ++total;
            }
        }
    }

    for (auto a : let) {
        cout << a.first << " ";
        for (int i = 0; i < a.second * 100 / total; i++) {
            cout << "█";
        }
        cout << endl;
        }

    cout << "0";
    for (int i = 0; i < 10; i++) {
        cout << "|―――――――――";
    }
    cout << "| 100%" << endl;
}
