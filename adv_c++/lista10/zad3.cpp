#include <algorithm>
#include <chrono>
#include <filesystem>
#include <iostream>
#include <string>

using namespace std;
namespace fs = std::filesystem;

string file_string(fs::path& path) {
    switch (fs::status(path).type()) {
        case fs::file_type::regular:
            return "plik";
        case fs::file_type::directory:
            return "katalog";
        case fs::file_type::symlink:
            return "symlink";
        default:
            return "";
    }
}

time_t file_time(fs::file_time_type time) {
    return chrono::system_clock::to_time_t(
        chrono::time_point_cast<chrono::system_clock::duration>(
            time - fs::file_time_type::clock::now() +
            chrono::system_clock::now()));
}

int main(int argc, char* argv[]) {
    if (argc != 2) {
        cerr << "./zad3 <scieżka>" << endl;
        return EXIT_FAILURE;
    }

    if (!fs::exists(fs::path(argv[1]))) {
        cerr << '"' << argv[1] << '"' << " nie istnieje" << endl;
    }

    auto path = fs::path(argv[1]);

    cout << fs::canonical(path) << " - ";
    cout << file_string(path) << " - ";

    if (fs::is_regular_file(path)) {
        cout << fs::file_size(path) << " bytes - ";
    }

    auto ftime = fs::last_write_time(path);
    auto ctime = file_time(ftime);
    cout << asctime(localtime(&ctime));
}