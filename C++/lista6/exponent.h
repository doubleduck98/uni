//
// Created by szipi on 2019-04-09.
//

#ifndef LISTA6_EXP_H
#define LISTA6_EXP_H

#include "operator1Arg.h"
#include <cmath>

class exponent : public operator1Arg {
public:
    explicit exponent(wyrazenie &w) : operator1Arg(w) {};

    explicit exponent(wyrazenie *w) : operator1Arg(*w){};

    double oblicz() override {
        return pow(M_E, u->oblicz());
    }

    double oblicz(const map<string, double> &zm) override {
        return pow(M_E, u->oblicz(zm));
    }

    string opis() override {
        return "e^" + u->opis();
    }
};


#endif //LISTA6_EXP_H
