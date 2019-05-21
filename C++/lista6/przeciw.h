//
// Created by szipi on 2019-04-09.
//

#ifndef LISTA6_PRZECIW_H
#define LISTA6_PRZECIW_H

#include <cmath>
#include "operator1Arg.h"

class przeciw : public operator1Arg {
public:
    explicit przeciw(wyrazenie &w) : operator1Arg(w) {};

    explicit przeciw(wyrazenie *w) : operator1Arg(*w){};

    double oblicz() override {
        return -u->oblicz();
    }

    double oblicz(const map<string, double> &zm) override {
        return -u->oblicz(zm);
    }

    string opis() override {
        return "-" + u->opis();
    }
};


#endif //LISTA6_PRZECIW_H
