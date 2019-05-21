#include <iostream>
#include "kolejka.h"

int main() {
    bool test = true;
    char comm;
    string param;
    kolejka *q;
    q = new kolejka(initializer_list<string>{"raz", "dwa", "trzy"});
    kolejka *p;
    p = new kolejka(*q);
    cout << "stara:" << endl;
    q->zawartosc();
    p->wyciagnij();
    cout << "nowa:" << endl;
    p->zawartosc();
    cout << "stara:" << endl;
    q->zawartosc();
    cout << "kolejka o wielkosci 3" << endl;
    cout << "wpisz h aby uzyskac pomoc:" << endl;
    while(test){
        cin >> comm;
        if(comm == 104){
            cout << "polecenie, ew. parametr" << endl
            << "q <int> - nowa kolejka" << endl
            << "e <string> - wsadz element" << endl
            << "d - wyjmij element" << endl
            << "p - zajrzyj" << endl
            << "s - rozmiar kolejki" << endl
            << "n - liczba elementow kolejki" << endl
            << "a - wypisz wszystkie elementy" << endl
            << "x - zakoncz" << endl;
        }
        else{
            switch(comm){
                case 113: //q
                    cin >> param;
                    delete q;
                    try{
                        q = new kolejka(stoi(param));
                    }
                    catch (exception &e){
                        q = new kolejka();
                        clog << e.what() << endl << "utworzono domyslna kolejke" << endl;
                    }
                    break;
                case 112: //p
                    try{
                        cout << q->sprawdz() << endl;
                    }
                    catch (exception &e){
                        clog << e.what() << endl;
                    }
                    break;
                case 110: //n
                    cout << q->rozmiar() << endl;
                    break;
                case 120: //x
                    test = false;
                    break;
                case 100: //d
                    try{
                        cout << q->wyciagnij() << endl;
                    }
                    catch (exception &e){
                        clog << e.what() << endl;
                    }
                    break;
                case 101: //e
                    try{
                        cin >> param;
                        q->wloz(param);
                    }
                    catch (exception &e){
                        clog << e.what() << endl;
                    }
                    break;
                case 97: //a
                    q->zawartosc();
                    break;
                case 115: //s
                    cout << q->get_pojemnosc() << endl;
                    break;
                default:
                    cout << "bledne polecenie" << endl;
                    break;
            }
        }
    }
    delete q;
    return 0;
}