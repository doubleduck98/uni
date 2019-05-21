//
// Created by szipi on 2019-04-09.
//

#ifndef LISTA6_ODWROTNOSC_H
#define LISTA6_ODWROTNOSC_H

#include <cmath>
#include <stdexcept>
#include "operator1Arg.h"

class odwrotnosc : public operator1Arg {
public:
    explicit odwrotnosc(wyrazenie &w) : operator1Arg(w) {};

    explicit odwrotnosc(wyrazenie *w) : operator1Arg(*w){};

    double oblicz() override {
        if (u->oblicz() == 0)
            return 0;
        return 1 / u->oblicz();
    }

    double oblicz(const map<string, double> &zm) override {
        if (u->oblicz(zm) == 0)
            return 0;
        return 1 / u->oblicz(zm);
    }

    string opis() override {
        if (u->oblicz() == 0)
            return to_string(0);
        return "1/" + u->opis();
    }
};


#endif //LISTA6_ODWROTNOSC_H
