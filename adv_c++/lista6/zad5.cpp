#include <algorithm>
#include <iostream>
#include <string>

using namespace std;

int main(int argc, char const *argv[]) {
    for (int i = 1; i < argc; i++) {
        string s = argv[i];
        cout << s << " ";
        while (next_permutation(s.begin(), s.end())) {
            cout << s << " ";
        }
        cout << endl;
    }
}
