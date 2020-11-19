#include <algorithm>
#include <iostream>
#include <map>
#include <vector>

using namespace std;

auto count(vector<int>& v) {
    map<int, int> rep;
    for (auto i : v) {
        ++rep[i];
    }

    vector<pair<int, int>> res;
    auto it = max_element(rep.begin(), rep.end(), [](auto me1, auto me2) {
        return me1.second < me2.second;
    });
    while (it != rep.end()) {
        res.push_back(*it);
        it = find_if(next(it), rep.end(),
                     [it](auto p) { return it->second == p.second; });
    }
    return res;
}

int main() {
    vector<int> v1{1, 1, 3, 5, 8, 9, 5, 8, 8, 5};
    auto res = count(v1);
    for (auto p : res) {
        cout << p.first << " " << p.second << endl;
    }
    cout << "***" << endl;

    vector<int> v2{};
    res = count(v2);
    for (auto p : res) {
        cout << p.first << " " << p.second << endl;
    }
    cout << "***" << endl;

    vector<int> v3{4, 3, 5, 5, 5, 3, 5, 4, 2, 1, 1, 1, 4, 2, 4, 5, 2, 4, 3, 4,
                   1, 2, 4, 3, 1, 1, 5, 1, 2, 2, 3, 3, 4, 2, 1, 1, 5, 2, 4, 4,
                   2, 4, 3, 5, 1, 3, 5, 1, 2, 5, 5, 1, 3, 3, 5, 1, 3, 3, 5, 3,
                   3, 4, 4, 2, 3, 2, 2, 3, 2, 2, 2, 2, 1, 3, 4, 4, 5, 2, 1, 4,
                   3, 5, 5, 1, 1, 3, 2, 5, 3, 4, 5, 3, 5, 4, 1, 5, 3, 3, 2, 3};
    res = count(v3);
    for (auto p : res) {
        cout << p.first << " " << p.second << endl;
    }
    cout << "***" << endl;
}