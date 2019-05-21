#include <iostream>
#include <vector>
#include <string>
#include <algorithm>

using namespace std;

const vector<pair<int, string>> rzym = {
        {1000, "M"},
        {900, "CM"}, {500, "D"}, {400, "CD"}, {100, "C"},
        {90, "XC"}, {50, "L"}, {40, "XL"}, {10, "X"},
        {9, "IX"}, {5, "V"}, {4, "IV"}, {1, "I"}
};

void bin2rzym(int i){
    cout << i << " -> ";
    int t = 0;
    string res;
    while(i > 0){
        if(i - rzym[t].first >= 0){
            res += rzym[t].second;
            i -= rzym[t].first;
        }
        else{
            ++t;
        }
    }
    cout << res << endl;
}

bool is_valid_number(string s){
    if(s[0] == '0' && s.length() > 1)
        return false;
    if(!isdigit(s[0]) && s[0] != '-')
        return false;
    for (int k = 1; k < s.length(); ++k){
        if(!isdigit(s[k]))
            return false;
    }
    return true;
}

int main(int argc, char *argv[]) {
    for (int i = 1; i < argc; ++i) {
        string t = argv[i];
        int x;
        if (is_valid_number(t)){
            try{
                x = stoi(t);
            }
            catch(exception &e){
                throw logic_error("nie mozna zamienic " +t +" na inta\n");
            }
            if(x >= 1 && x <= 3999){
                bin2rzym(x);
            }
            else{
                clog << "liczba " +t +" jest spoza zakresu [1, 3999]" << endl;
            }
        }
        else
            clog << "string " << t << " nie jest poprawna liczba" << endl;
    }
    return 0;
}