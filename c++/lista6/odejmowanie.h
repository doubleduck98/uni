//
// Created by szipi on 2019-04-09.
//

#ifndef LISTA6_ODEJMOWANIE_H
#define LISTA6_ODEJMOWANIE_H

#include "operator2Arg.h"

class odejmowanie : public operator2Arg {
public:
    odejmowanie(wyrazenie &u, wyrazenie &w) : operator2Arg(u, w) {};

    odejmowanie(wyrazenie *u, wyrazenie *w) : operator2Arg(*u, *w) {};

    double oblicz() override {
        return u->oblicz() - w->oblicz();
    }

    double oblicz(const map<string, double> &zm) override {
        return u->oblicz(zm) - w->oblicz(zm);
    }

    string opis() override {
        return "(" + u->opis() + "-" + w->opis() + ")";
    }
};


#endif //LISTA6_ODEJMOWANIE_H
