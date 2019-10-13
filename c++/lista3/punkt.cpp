//
// Created by szipi on 12.03.2019.
//
#include <cmath>
#include "punkt.h"

punkt::punkt() = default;

punkt::punkt(double xi, double yi) {
    x = xi;
    y = yi;
}

punkt::punkt(const punkt &p) {
    x = p.x;
    y = p.y;
}

punkt& punkt::operator=(const punkt& p) {
    this->x = p.x;
    this->y = p.y;
    return *this;
}

void punkt::przesun(double wx, double wy) {
    x += wx;
    y += wy;
}

void punkt::obroc(punkt p, double theta) {
    double t = x;
    double theta_rad = -theta * M_PI / 180;
    x = cos(theta_rad) * (x - p.get_x()) + sin(theta_rad) * (y - p.get_y()) + p.get_x();
    y = sin(theta_rad) * (t - p.get_x()) + cos(theta_rad) * (y - p.get_y()) - p.get_y();
}

bool punkt::same_as(punkt p1, punkt p2) {
    return p1.get_x() == p2.get_x() && p1.get_y() == p2.get_y();
}

std::ostream &operator<<(std::ostream &strm, const punkt &p) {
    return strm << std::setprecision(3) << "[" << std::to_string(p.x) << ", " << std::to_string(p.y) << "]";
}
