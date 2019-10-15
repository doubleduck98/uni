fn main() {
    testing("siema", "eniu", "aeimnsu")
}

fn longest(a1: &str, a2: &str) -> String {
    let mut chars: Vec<char> = a1.chars().collect();
    chars.extend(a2.chars());
    chars.sort();
    chars.dedup();
    let mut res = String::new();
    for c in chars {
        res.push(c);
    }
    res
}

fn testing(s1: &str, s2: &str, exp: &str) -> () {
    println!("s1:{:?} s2:{:?}", s1, s2);
    println!("{:?} {:?}", longest(s1, s2), exp);
    println!("{}", longest(s1, s2) == exp);
    assert_eq!(&longest(s1, s2), exp)
}

#[test]
fn test0() {
    testing("aretheyhere", "yestheyarehere", "aehrsty");
}
#[test]
fn test1() {
    testing(
        "loopingisfunbutdangerous",
        "lessdangerousthancoding",
        "abcdefghilnoprstu",
    );
}
#[test]
fn test2() {
    testing("szymon", "zienkiewicz", "ceikmnoswyz");
}
#[test]
fn test3() {
    testing("jakub", "pacierpnik", "abceijknpru");
}
#[test]
fn test4() {
    testing("siema", "eniu", "aeimnsu");
}
#[test]
fn test5() {
    testing("fortnite", "blackhole", "abcefhiklnort");
}
#[test]
fn test6() {
    testing("hfiusgfs", "czxjlcbzkjxcz", "bcfghijklsuxz");
}
#[test]
fn test7() {
    testing("rust", "kozacki", "acikorstuz");
}
#[test]
fn test8() {
    testing("xdxdxdxdxdxdx", "xdxdxdxdxdxdxd", "dx");
}
#[test]
fn test9() {
    testing("", "", "");
}
