//
// Created by szipi on 10.04.2019.
//

#ifndef LISTA6_LOGARYTM_H
#define LISTA6_LOGARYTM_H

#include "operator2Arg.h"
#include <cmath>

class logarytm : public operator2Arg {
public:
    logarytm(wyrazenie &base, wyrazenie &exp) : operator2Arg(base, exp) {};

    logarytm(wyrazenie *base, wyrazenie *exp) : operator2Arg(*base, *exp) {};

    double oblicz() override {
        return log(w->oblicz()) / log(u->oblicz());
    }

    double oblicz(const map<string, double> &zm) override {
        return log(w->oblicz(zm)) / log(u->oblicz(zm));
    }

    string opis() override {
        return "log[" + u->opis() + "](" + w->opis() + ")";
    }
};


#endif //LISTA6_LOGARYTM_H
