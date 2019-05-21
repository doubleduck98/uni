//
// Created by szipi on 10.04.2019.
//

#ifndef LISTA6_POTEGA_H
#define LISTA6_POTEGA_H

#include "operator2Arg.h"
#include <cmath>

class potega : public operator2Arg {
public:
    potega(wyrazenie &u, wyrazenie &w) : operator2Arg(u, w) {};

    potega(wyrazenie *u, wyrazenie *w) : operator2Arg(*u, *w) {};

    double oblicz() override {
        return pow(u->oblicz(), w->oblicz());
    }

    double oblicz(const map<string, double> &zm) override {
        return pow(u->oblicz(zm), w->oblicz(zm));
    }

    string opis() override {
        return u->opis() + "^" + w->opis();
    }
};


#endif //LISTA6_POTEGA_H
