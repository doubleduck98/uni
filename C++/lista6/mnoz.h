//
// Created by szipi on 10.04.2019.
//

#ifndef LISTA6_MNOZ_H
#define LISTA6_MNOZ_H

#include "operator2Arg.h"

class mnoz : public operator2Arg {
public:
    mnoz(wyrazenie &u, wyrazenie &w) : operator2Arg(u, w) {};

    mnoz(wyrazenie *u, wyrazenie *w) : operator2Arg(*u, *w) {};

    double oblicz() override {
        return u->oblicz() * w->oblicz();
    }

    double oblicz(const map<string, double> &zm) override {
        return u->oblicz(zm) * w->oblicz(zm);
    }

    string opis() override {
        return "(" + u->opis() + "*" + w->opis() + ")";
    }
};


#endif //LISTA6_MNOZ_H
