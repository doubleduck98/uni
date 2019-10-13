//
// Created by szipi on 2019-03-19.
//

#ifndef LISTA4_KOLEJKA_H
#define LISTA4_KOLEJKA_H

#include <string>

using namespace std;

class kolejka {
private:
    string *q;
    int pojemnosc, pocz, ile;

public:
    kolejka();
    ~kolejka();
    kolejka(const kolejka &k);
    kolejka& operator=(const kolejka&);
    kolejka(kolejka&& k) noexcept;
    kolejka& operator=(kolejka&& other) noexcept;
    kolejka(initializer_list<string> l);
    explicit kolejka(int size);
    void wloz(string s);
    string wyciagnij();
    string sprawdz();
    int rozmiar();
    void zawartosc();
    int get_pojemnosc(){ //tylko na potrzeby testow
        return pojemnosc;
    }
};


#endif //LISTA4_KOLEJKA_H
