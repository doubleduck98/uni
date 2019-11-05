fn main() {
    println!("{}", xo("oxoxoxoxoxoxox"));
}

fn xo(string: &'static str) -> bool {
    let mut x = 0;
    let mut o = 0;
    string
        .to_lowercase()
        .chars()
        .collect::<Vec<char>>()
        .into_iter()
        .for_each(|c| match c {
            'x' => {
                x += 1;
            }
            'o' => {
                o += 1;
            }
            _ => (),
        });
    x == o
}

#[test]
fn test0() {
    assert_eq!(xo("xo"), true);
}
#[test]
fn test1() {
    assert_eq!(xo("Xo"), true);
}
#[test]
fn test2() {
    assert_eq!(xo("xxOo"), true);
}
#[test]
fn test3() {
    assert_eq!(xo("xxxm"), false);
}
#[test]
fn test4() {
    assert_eq!(xo("Oo"), false);
}
#[test]
fn test5() {
    assert_eq!(xo("ooom"), false);
}
#[test]
fn test6() {
    assert_eq!(xo("xDDDDDDDD"), false);
}
#[test]
fn test7() {
    assert_eq!(xo(""), true);
}
#[test]
fn test8() {
    assert_eq!(xo("essa"), true);
}
#[test]
fn test9() {
    assert_eq!(xo("xxOOxxOOXXooXXoo"), true);
}
