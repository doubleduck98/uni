//
// Created by szipi on 09.04.2019.
//

#ifndef LISTA6_SINUS_H
#define LISTA6_SINUS_H

#include <cmath>
#include "operator1Arg.h"

class sinus : public operator1Arg {
public:
    explicit sinus(wyrazenie &w) : operator1Arg(w) {};

    explicit sinus(wyrazenie *w) : operator1Arg(*w) {};

    double oblicz() override {
        return sin(u->oblicz());
    }

    double oblicz(const map<string, double> &zm) override {
        return sin(u->oblicz(zm));
    }

    string opis() override {
        return "sin(" + u->opis() + ")";
    }
};

#endif //LISTA6_SINUS_H
