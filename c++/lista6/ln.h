//
// Created by szipi on 2019-04-09.
//

#ifndef LISTA6_LN_H
#define LISTA6_LN_H

#include "operator1Arg.h"
#include <cmath>

class ln : public operator1Arg {
public:
    explicit ln(wyrazenie &w) : operator1Arg(w) {};

    explicit ln(wyrazenie *w) : operator1Arg(*w){};

    double oblicz() override {
        return log(u->oblicz());
    }

    string opis() override {
        return "ln(" + u->opis() + ")";
    }
};


#endif //LISTA6_LN_H
