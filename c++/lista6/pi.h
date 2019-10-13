//
// Created by szipi on 09.04.2019.
//

#ifndef LISTA6_PI_H
#define LISTA6_PI_H

#include <cmath>
#include "stala.h"

class pi : public stala {
public:
    pi() {
        x = M_PI;
    };

    string opis() override {
        return "pi";
    }
};


#endif //LISTA6_PI_H
