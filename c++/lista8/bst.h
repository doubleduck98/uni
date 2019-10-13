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

        friend ostream &operator<<(ostream &wyj, const Node *node) {
            if (node == nullptr)
                return wyj << "";
            return wyj << node->left << node->key << " " << node->right;
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

    //metoda pomocnicza do znajdywania najmniejszej wartosci w poddrzewie
    Node *minKey(Node *cnode) {
        Node *curr = cnode;
        while (curr && curr->left != nullptr)
            curr = curr->left;

        return curr;
    }

    //metoda pomocnicza do usuwania wierzchołka
    //znajdujemy nastepnik w poddrzewie, kopiujemy wartosc do wezla i usuwamy zastepce
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
        if (this->node == nullptr) {
            this->node = new Node(value);
            return;
        }
        Node *cnode = this->node;
        while (true) {
            if (cnode->key >= value) {
                if (cnode->left == nullptr) {
                    cnode->left = new Node(value);
                    return;
                } else
                    cnode = cnode->left;
            } else {
                if (cnode->right == nullptr) {
                    cnode->right = new Node(value);
                    return;
                } else
                    cnode = cnode->right;
            }
        }
    }

    //metoda usuwania
    void usunWezel(T value) {
        if (this->node == nullptr)
            throw invalid_argument("drzewo jest puste");
        else
            node = usunxd(value, this->node);
    }

    //metoda znajdowania
    bool znajdzWezel(T value) {
        Node *cnode = this->node;
        while (cnode != nullptr) {
            if (cnode->key == value)
                return true;
            else if (cnode->key > value)
                cnode = cnode->left;
            else
                cnode = cnode->right;
        }
        return false;
    }

    //strumienie wypisywania dla referencji i wskaźnika
    friend ostream &operator<<(ostream &wyj, const bst<T> &bst) {
        if (bst.node == nullptr)
            return wyj << "drzewo jest puste";
        else
            return wyj << bst.node;
    }
};


#endif //LISTA8_BST_H