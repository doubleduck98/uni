//
// Created by szipi on 09.04.2019.
//

#ifndef LISTA6_WYRAZENIE_H
#define LISTA6_WYRAZENIE_H

#include <string>
#include <map>

using namespace std;

class wyrazenie {
public:
    wyrazenie() = default;

    virtual double oblicz() = 0;

    virtual double oblicz(const map<string, double> &zm) = 0;

    virtual string opis() = 0;
};


#endif //LISTA6_WYRAZENIE_H
