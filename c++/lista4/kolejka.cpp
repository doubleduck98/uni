#include <stdexcept>
#include <iostream>

//
// Created by szipi on 2019-03-19.
//

#include "kolejka.h"

using namespace std;

kolejka::kolejka(){
    q = new string[1];
    pojemnosc = 1;
    pocz = 0;
    ile = 0;
}

kolejka::~kolejka(){
    delete[] q;
}

kolejka::kolejka(int size) {
    if(size <= 0)
        throw invalid_argument("nie mozna stwozyc kolejki o rozmiarze <= 0");
    q = new string[size];
    pojemnosc = size;
    pocz = 0;
    ile = 0;
}

kolejka::kolejka(const kolejka &k) {
    q = new string[k.pojemnosc];
    copy(k.q, k.q + k.pojemnosc, q);
    pojemnosc = k.pojemnosc;
    pocz = k.pocz;
    ile = k.ile;
}

kolejka &kolejka::operator=(const kolejka &k) = default;

kolejka::kolejka(kolejka &&k) noexcept
:q(nullptr)
,pojemnosc(0)
,pocz(0)
,ile(0){
    q = k.q;
    pojemnosc = k.pojemnosc;
    pocz = k.pocz;
    ile = k.ile;

    k.q = nullptr;
    k.pojemnosc = 0;
    k.pocz = 0;
    k.ile = 0;
}

kolejka &kolejka::operator=(kolejka &&other) noexcept {
    if(this != &other){
        delete[] q;
        q = other.q;
        pojemnosc = other.pojemnosc;
        pocz = other.pocz;
        ile = other.ile;
    }
    return *this;
}

kolejka::kolejka(initializer_list<string> l) {
    if(l.size() <= 0)
        throw invalid_argument("nie mozna stworzyc kolejki o rozmiarze <= 0");
    q = new string[l.size()];
    pojemnosc = l.size();
    pocz = 0;
    ile = l.size();
    int i = 0;
    for(const auto &x : l){
        q[i] = x;
        ++i;
    }
}

void kolejka::wloz(string s) {
    if(ile == pojemnosc)
        throw invalid_argument("kolejka jest pelna");
    q[(pocz + ile) % pojemnosc] = move(s);
    ++ile;
}

string kolejka::wyciagnij() {
    if(ile == 0)
        throw invalid_argument("nie mozna wyciagac z pustej kolejki");
    --ile;
    string t = q[pocz];
    ++pocz;
    pocz %= pojemnosc;
    return t;
}

string kolejka::sprawdz() {
    if(ile == 0)
        throw invalid_argument("nie mozna sprawdzac z pustej kolejki");
    return q[pocz];
}

int kolejka::rozmiar() {
    return ile;
}

void kolejka::zawartosc() { //uzywana tylko przez ui
    for (int i = 0; i < ile; ++i) {
        cout << q[(i + pocz) % pojemnosc] << endl;
    }
}
