//
// Created by szipi on 2019-04-09.
//

#ifndef LISTA6_BEZWZGL_H
#define LISTA6_BEZWZGL_H

#include <cmath>
#include "operator1Arg.h"

class bezwzgl : public operator1Arg {
public:
    explicit bezwzgl(wyrazenie &w) : operator1Arg(w) {};

    explicit bezwzgl(wyrazenie *w) : operator1Arg(*w){};

    double oblicz() override {
        return abs(u->oblicz());
    }

    double oblicz(const map<string, double> &zm) override {
        return abs(u->oblicz(zm));
    }

    string opis() override {
        return "|" + u->opis() + "|";
    }
};


#endif //LISTA6_BEZWZGL_H
