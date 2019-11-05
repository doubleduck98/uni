fn main() {
    assert_eq!(solution(4.2), 4.0);
}

fn solution(n: f64) -> f64 {
    if n.fract() < 0.25 {
        n.trunc()
    } else if n.fract() < 0.75 {
        n.trunc() + 0.5
    } else {
        n.ceil()
    }
}

#[test]
fn test0() {
    assert_eq!(solution(4.2), 4.0);
}
#[test]
fn test1() {
    assert_eq!(solution(4.2), 4.0);
}
#[test]
fn test2() {
    assert_eq!(solution(4.6), 4.5);
}
#[test]
fn test3() {
    assert_eq!(solution(4.8), 5.0);
}
#[test]
fn test4() {
    assert_eq!(solution(4.4), 4.5);
}
#[test]
fn test5() {
    assert_eq!(solution(4.75), 5.0);
}

#[test]
fn test6() {
    assert_eq!(solution(4.1), 4.0);
}

#[test]
fn test7() {
    assert_eq!(solution(4.9), 5.0);
}

#[test]
fn test8() {
    assert_eq!(solution(4.0), 4.0);
}

#[test]
fn test9() {
    assert_eq!(solution(4.45), 4.5);
}
