fn main() {
    println!("{}", get_count("aeiou"));
}

fn get_count(string: &str) -> usize {
    string
        .chars()
        .filter(|&c| ['a', 'e', 'i', 'o', 'u'].contains(&c))
        .count()
}

#[test]
fn test0() {
    assert_eq!(get_count("abracadabra"), 5);
}
#[test]
fn test1() {
    assert_eq!(get_count("szymon"), 1);
}
#[test]
fn test2() {
    assert_eq!(get_count("zienkiewicz"), 5);
}
#[test]
fn test3() {
    assert_eq!(get_count("rustjestpog"), 3);
}
#[test]
fn test4() {
    assert_eq!(get_count("hehexd"), 2);
}
#[test]
fn test5() {
    assert_eq!(get_count("ioaueoiaueoiaueoaeuaoie"), 23);
}
#[test]
fn test6() {
    assert_eq!(get_count("iiuwr"), 3);
}
#[test]
fn test7() {
    assert_eq!(get_count(""), 0);
}
#[test]
fn test8() {
    assert_eq!(get_count("nzxvcxzcvxcvxzvcxc"), 0);
}
#[test]
fn test9() {
    assert_eq!(get_count("alibaba"), 4);
}
