//
// Created by szipi on 2019-04-09.
//

#ifndef LISTA6_OPERATOR2ARG_H
#define LISTA6_OPERATOR2ARG_H

#include "operator1Arg.h"

class operator2Arg : public operator1Arg {
protected:
    wyrazenie *w{};

    operator2Arg() = default;

    operator2Arg(wyrazenie &wyr1, wyrazenie &wyr2) : operator1Arg(wyr1), w(&wyr2) {};
};


#endif //LISTA6_OPERATOR2ARG_H
