//
// Created by szipi on 09.04.2019.
//

#ifndef LISTA6_FI_H
#define LISTA6_FI_H

#include "stala.h"
#include <cmath>

class fi : public stala {
public:
    fi() {
        x = (1 + sqrt(5)) / 2;
    }

    string opis() override {
        return "fi";
    }
};

#endif //LISTA6_FI_H
