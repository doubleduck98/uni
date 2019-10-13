//
// Created by szipi on 2019-04-09.
//

#ifndef LISTA6_DODAWANIE_H
#define LISTA6_DODAWANIE_H

#include "operator2Arg.h"

class dodawanie : public operator2Arg {
public:
    dodawanie(wyrazenie &u, wyrazenie &w) : operator2Arg(u, w) {};

    dodawanie(wyrazenie *u, wyrazenie *w) : operator2Arg(*u, *w) {};

    double oblicz() override {
        return u->oblicz() + w->oblicz();
    }

    double oblicz(const map<string, double> &zm) override {
        return u->oblicz(zm) + w->oblicz(zm);
    }

    string opis() override {
        return "(" + u->opis() + "+" + w->opis() + ")";
    }
};


#endif //LISTA6_DODAWANIE_H
