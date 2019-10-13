//
// Created by szipi on 12.03.2019.
//

#ifndef LISTA3_PUNKT_H
#define LISTA3_PUNKT_H

#include <cmath>
#include <ostream>
#include <iomanip>

class punkt {

private:
    double x;
    double y;
    friend std::ostream& operator<<(std::ostream&, const punkt&);

public:
    punkt();
    punkt(double x, double y);
    punkt(const punkt &p);
    punkt& operator=(const punkt&);
    void przesun(double wx, double wy);
    void obroc(punkt p, double theta);
    double get_x(){
        return x;
    };
    double get_y(){
        return y;
    }
    static bool same_as(punkt p1, punkt p2);
};

inline double dystans_pomiedzy_punktami(punkt a, punkt b){
    return sqrt(pow(a.get_x() - b.get_x(), 2) + pow(a.get_y() - b.get_y(), 2));
}

#endif //LISTA3_PUNKT_H
