//
// Created by szipi on 11.05.19.
//

#ifndef LISTA8_BST_H
#define LISTA8_BST_H

#include <iostream>
#include <stdexcept>
#include <algorithm>

using namespace std;

template<class T>
class bst {
private:
    class Node {
    public:
        Node *left;
        Node *right;
        T key;

        Node() = default;

        explicit Node(T value) {
            this->key = value;
            left = nullptr;
            right = nullptr;
        }

        ~Node() {
            delete left;
            delete right;
        }
    } *node = nullptr;

    //todo:nie działa
    void kopiujxd(const Node *from, Node *to) {
        copy(from, from + sizeof(Node), to);
        if (to->left != nullptr)
            kopiujxd(from->left, to->left);
        if (to->right != nullptr)
            kopiujxd(from->right, to->right);
    }

    //metoda pomocnicza do dodawania wierzchołka
    void dodajxd(T value, Node *cnode) {
        if (cnode->key >= value) {
            if (cnode->left == nullptr)
                cnode->left = new Node(value);
            else
                dodajxd(value, cnode->left);
        } else {
            if (cnode->right == nullptr)
                cnode->right = new Node(value);
            else
                dodajxd(value, cnode->right);
        }
    }

    //metoda pomocnicza do znajdywania najmniejszej wartosci w poddrzewie
    Node *minKey(Node *cnode) {
        Node *curr = cnode;
        while (curr && curr->left != nullptr)
            curr = curr->left;

        return curr;
    }

    //metoda pomocnicza do usuwania wierzchołka
    Node *usunxd(T value, Node *cnode) {
        if (cnode == nullptr)
            throw invalid_argument("nie ma takiej wartosci w drzewie");
        if (value < cnode->key)
            cnode->left = usunxd(value, cnode->left);
        else if (value > cnode->key)
            cnode->right = usunxd(value, cnode->right);
        else {
            if (cnode->left == nullptr) {
                Node *temp = cnode->right;
                cnode->right = nullptr;
                delete cnode;
                return temp;
            } else if (cnode->right == nullptr) {
                Node *temp = cnode->left;
                cnode->left = nullptr;
                delete cnode;
                return temp;
            }
            Node *temp = minKey(cnode->right);
            cnode->key = temp->key;
            cnode->right = usunxd(temp->key, cnode->right);
        }
        return cnode;
    }

    //metoda pomocnicza do znajdywania wierzchołka
    bool znajdzxd(T value, Node *cnode) {
        if (cnode == nullptr)
            throw invalid_argument("nie ma takiej wartosci w drzewie");
        else if (value < cnode->key)
            znajdzxd(value, cnode->left);
        else if (cnode->key == value)
            return true;
        else
            znajdzxd(value, cnode->right);
    }

    //metoda pomocnicza do wypisywania
    ostream wypiszxd(ostream &wyj, Node *cnode) {
        return wyj << cnode->left == nullptr ? wypiszxd(wyj, cnode->left) : ""
        << cnode->key << cnode->right == nullptr ? wypiszxd(wyj, cnode->right) : "";
    }

public:
    bst() = default;

    //konstruktor z init_list
    bst(initializer_list<T> list) {
        for (auto &x: list) {
            this->dodajWezel(x);
        }
    }

    //konstruktor kopiujacy todo:nie działa
    bst<T>(const bst<T> &drzewo) {
        delete this->node;
        this->node = new Node();
        copy(drzewo.node, drzewo.node + sizeof(Node), this->node);
        if (this->node->left != nullptr)
            kopiujxd(drzewo.node->left, this->node->left);
        if (this->node->right != nullptr)
            kopiujxd(drzewo.node->right, this->node->right);
    }

    //konstruktor przenoszący
    bst<T>(bst<T> &&drzewo) noexcept
            : node(nullptr) {
        delete this->node;
        this->node = drzewo.node;
        drzewo.node = nullptr;
    }

    //operator przenoszący
    bst<T> &operator=(bst<T> &&drzewo) noexcept {
        if (this != drzewo) {
            delete this->node;
            this->node = drzewo.node;
            drzewo.node = nullptr;
        }
        return *this;
    }

    //destruktor
    ~bst() {
        delete this->node;
    }

    //metoda dodawania
    void dodajWezel(T value) {
        if (this->node == nullptr)
            this->node = new Node(value);
        else
            dodajxd(value, this->node);
    }

    //metoda usuwania
    void usunWezel(T value) {
        if (this->node == nullptr)
            throw invalid_argument("drzewo jest puste");
        else
            usunxd(value, this->node);
    }

    //metoda znajdowania
    bool znajdzWezel(T value) {
        return znajdzxd(value, this->node);
    }

    //todo:operator strumieniowy
    void wypisz() {
        if (this->node == nullptr)
            cout << "drzewo jest puste";
        else
            wypiszxd(this->node);
        cout << endl;
    }

    friend ostream &operator<<(ostream &wyj, const bst<T> &bst) {
        if (bst.node == nullptr)
            return wyj << "drzewo jest puste";
        else
            return wypiszxd(wyj, bst.node)
    }
};


#endif //LISTA8_BST_H