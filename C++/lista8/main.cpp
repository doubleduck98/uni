#include <iostream>
#include <vector>
#include "bst.h"

using namespace std;

int main() {
    auto *xd = new bst<int>({7, 2, 5, 4, 1, 19});
    xd->wypisz();
    //auto *xdd = new bst<int>(*xd);
    cout << endl;
    xd->usunWezel(7);
    xd->usunWezel(4);
    xd->wypisz();
    //xdd->wypisz();
    bool test = true;
    char comm;
    int param;
    cout << "puste drzewo binarnych poszukiwan" << endl;
    cout << "domyslna wartoscia przechowywana w drzewie jest int" << endl;
    cout << "wpisz h aby uzyskac pomoc: " << endl;
    while (false) {
        cin >> comm;
        if (comm == 104) {
            cout << "polecenie, ew. parametr" << endl
                 << "b - nowa kolejka" << endl
                 << "p <int> - wsadz element" << endl
                 << "d <int> - usun element" << endl
                 << "a - wypisz wszystkie elementy" << endl
                 << "h - pomoc"
                 << "x - zakoncz" << endl;
        } else {
            switch (comm) {
                case 98: //b
                    delete xd;
                    xd = new bst<int>({});
                    cout << "utworzono nowe bst" << endl;
                    break;
                case 112: //p
                    cin >> param;
                    xd->dodajWezel(param);
                    cout << "wsadzono element " << param << endl;
                    break;
                case 100: //d
                    cin >> param;
                    try {
                        xd->usunWezel(param);
                        cout << "usunieto element " << param << endl;
                    }
                    catch (exception &e) {
                        cerr << e.what() << endl;
                    }
                    break;
                case 97: //a
                    try {
                        xd->wypisz();
                    }
                    catch (exception &e) {
                        cerr << e.what() << endl;
                    }
                    break;
                case 104: //h
                    cout << "polecenie, ew. parametr" << endl
                         << "b <ciag intow> - nowa kolejka" << endl
                         << "p <int> - wsadz element" << endl
                         << "d <int> - usun element" << endl
                         << "a - wypisz wszystkie elementy" << endl
                         << "h - pomoc"
                         << "x - zakoncz" << endl;
                    break;
                case 120: //x
                    test = false;
                    break;
                default:
                    cerr << "bledne polecenie" << endl;
                    break;
            }
        }
    }
    delete xd;
}