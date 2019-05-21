//
// Created by szipi on 10.04.2019.
//

#ifndef LISTA6_DZIEL_H
#define LISTA6_DZIEL_H

#include <stdexcept>
#include "operator2Arg.h"

class dziel : public operator2Arg {
public:
    dziel(wyrazenie &u, wyrazenie &w) : operator2Arg(u, w) {};

    dziel(wyrazenie *u, wyrazenie *w) : operator2Arg(*u, *w) {};

    double oblicz() override {
        if (w->oblicz() == 0)
            throw invalid_argument("nie mozna dzielic przez 0");
        return u->oblicz() / w->oblicz();
    }

    double oblicz(const map<string, double> &zm) override {
        if (w->oblicz(zm) == 0)
            throw invalid_argument("nie mozna dzielic przez 0");
        return u->oblicz(zm) / w->oblicz(zm);
    }

    string opis() override {
        return "(" + u->opis() + "/" + w->opis() + ")";
    }
};


#endif //LISTA6_DZIEL_H
