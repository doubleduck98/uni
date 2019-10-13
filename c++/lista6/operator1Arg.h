//
// Created by szipi on 09.04.2019.
//

#ifndef LISTA6_OPERATOR1ARG_H
#define LISTA6_OPERATOR1ARG_H

#include "wyrazenie.h"

class operator1Arg : public wyrazenie {
protected:
    wyrazenie *u{};

    operator1Arg() = default;

    explicit operator1Arg(wyrazenie &wyr) : u(&wyr) {};
};


#endif //LISTA6_OPERATOR1ARG_H
