use std::collections::BTreeMap;

fn main() {
    println!("{:?}", letter_frequency("ESSA"));
}

fn remove_trash(s: &str) -> String {
    let mut ss: String = s.to_lowercase().split_whitespace().collect();
    ss.retain(|c| (c as u32) >= ('a' as u32) && (c as u32) <= ('z' as u32));
    ss
}

fn letter_frequency(input: &str) -> BTreeMap<char, i32> {
    let mut tree: BTreeMap<char, i32> = BTreeMap::new();
    remove_trash(input).chars().for_each(|c| {
        *tree.entry(c).or_insert(0) += 1;
    });
    tree
}

#[test]
fn test0() {
    let answer: BTreeMap<char, i32> = [('a', 2), ('c', 1), ('l', 1), ('t', 1), ('u', 1)]
        .iter()
        .cloned()
        .collect();

    assert_eq!(letter_frequency("actual"), answer);
}

#[test]
fn test1() {
    let answer: BTreeMap<char, i32> = [
        ('a', 3),
        ('b', 2),
        ('f', 1),
        ('p', 1),
        ('s', 1),
        ('t', 2),
        ('u', 1),
        ('x', 5),
    ]
    .iter()
    .cloned()
    .collect();

    assert_eq!(letter_frequency("AaabBF UttsP xxxxx"), answer);
}

#[test]
fn test2() {
    let answer: BTreeMap<char, i32> = [('e', 1), ('s', 2), ('a', 1)].iter().cloned().collect();
    assert_eq!(letter_frequency("essa"), answer);
}

#[test]
fn test3() {
    let answer: BTreeMap<char, i32> = [
        ('c', 1),
        ('e', 2),
        ('i', 3),
        ('k', 1),
        ('m', 1),
        ('n', 2),
        ('o', 1),
        ('s', 1),
        ('w', 1),
        ('y', 1),
        ('z', 3),
    ]
    .iter()
    .cloned()
    .collect();
    assert_eq!(letter_frequency("szymon zienkiewicz"), answer);
}

#[test]
fn test4() {
    let answer: BTreeMap<char, i32> = [('x', 1), ('d', 3)].iter().cloned().collect();
    assert_eq!(letter_frequency("xDDD"), answer);
}

#[test]
fn test5() {
    let answer: BTreeMap<char, i32> = [].iter().cloned().collect();
    assert_eq!(letter_frequency(""), answer);
}

#[test]
fn test6() {
    let answer: BTreeMap<char, i32> = [('r', 1), ('s', 1), ('u', 1), ('t', 1)]
        .iter()
        .cloned()
        .collect();
    assert_eq!(letter_frequency("rust"), answer);
}

#[test]
fn test7() {
    let answer: BTreeMap<char, i32> = [].iter().cloned().collect();
    assert_eq!(letter_frequency("!#%^&*#@!%^"), answer);
}

#[test]
fn test8() {
    let answer: BTreeMap<char, i32> = [('o', 10)].iter().cloned().collect();
    assert_eq!(letter_frequency("OOOOOooooo"), answer);
}

#[test]
fn test9() {
    let answer: BTreeMap<char, i32> = [('a', 2), ('b', 2), ('c', 2), ('d', 2)]
        .iter()
        .cloned()
        .collect();
    assert_eq!(letter_frequency("AaBbCcDd"), answer);
}
