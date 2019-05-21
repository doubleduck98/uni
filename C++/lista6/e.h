//
// Created by szipi on 2019-04-11.
//

#ifndef LISTA6_E_H
#define LISTA6_E_H

#include "stala.h"
#include <cmath>

class e : public stala {
public:
    e() {
        x = M_E;
    }

    string opis() override {
        return "e";
    }
};

#endif //LISTA6_E_H
