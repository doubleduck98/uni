//
// Created by szipi on 09.04.2019.
//

#ifndef LISTA6_STALA_H
#define LISTA6_STALA_H

#include "wyrazenie.h"

class stala : public wyrazenie {
protected:
    double x{};
public:
    stala() = default;

    double oblicz() override {
        return x;
    }

    double oblicz(const map<string, double> &zm) override {
        return x;
    }
};

#endif //LISTA6_STALA_H
