#include <iostream>
#include "bst.h"

using namespace std;

int main() {
    auto *xd = new bst<int>({});
    auto *xdd = new bst<int>();
    //przypisanie kopiujace -> *xdd = *xd;
    try{
        //cout << xd->znajdzWezel(55) << endl;
        xd->dodajWezel(997);
        xd->wypisz();
        xdd->wypisz();
    }
    catch (exception &e){
        cerr << e.what() << endl;
    }
    cout << "lmao";
    delete xd;
    delete xdd;
}