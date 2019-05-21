//
// Created by szipi on 09.04.2019.
//

#ifndef LISTA6_LICZBA_H
#define LISTA6_LICZBA_H

#include "wyrazenie.h"

class liczba : public wyrazenie {
private:
    double xd;
public:
    explicit liczba(double x) {
        this->xd = x;
    }

    double oblicz() override {
        return xd;
    }

    double oblicz(const map<string, double> &zm) override {
        return xd;
    }

    string opis() override {
        return to_string(xd);
    }
};

#endif //LISTA6_LICZBA_H
