//
// Created by szipi on 2019-04-09.
//

#ifndef LISTA6_COSINUS_H
#define LISTA6_COSINUS_H

#include "operator1Arg.h"
#include <cmath>

class cosinus : public operator1Arg {
public:
    explicit cosinus(wyrazenie &w) : operator1Arg(w) {};

    explicit cosinus(wyrazenie *w) : operator1Arg(*w){};

    double oblicz() override {
        return cos(u->oblicz());
    };

    double oblicz(const map<string, double> &zm) override {
        return cos(u->oblicz(zm));
    }

    string opis() override {
        return "cos(" + u->opis() + ")";
    }
};


#endif //LISTA6_COSINUS_H
