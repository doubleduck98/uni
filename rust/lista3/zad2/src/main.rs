fn main() {
    println!("{}", number(&[(10, 0), (3, 5), (5, 8)]));
}

fn number(bus_stops: &[(i32, i32)]) -> i32 {
    bus_stops.iter().map(|&(a, b)| a - b).sum()
}

#[test]
fn test0() {
    assert_eq!(number(&[(10, 0), (3, 5), (5, 8)]), 5);
}
#[test]
fn test1() {
    assert_eq!(
        number(&[(3, 0), (9, 1), (4, 10), (12, 2), (6, 1), (7, 10)]),
        17
    );
}
#[test]
fn test2() {
    assert_eq!(
        number(&[(3, 0), (9, 1), (4, 8), (12, 2), (6, 1), (7, 8)]),
        21
    );
}
#[test]
fn test3() {
    assert_eq!(number(&[(1, 0)]), 1);
}
#[test]
fn test4() {
    assert_eq!(number(&[(2, 2), (3, 3), (4, 4)]), 0);
}
#[test]
fn test5() {
    assert_eq!(number(&[(10, 2), (5, 5), (5, 2), (4, 8), (9, 0)]), 16);
}
#[test]
fn test6() {
    assert_eq!(number(&[(10, 0), (15, 0), (7, 0)]), 32);
}
#[test]
fn test7() {
    assert_eq!(number(&[(7, 1), (6, 9), (4, 2)]), 5);
}
#[test]
fn test8() {
    assert_eq!(number(&[(5, 9), (9, 4)]), 1);
}
#[test]
fn test9() {
    assert_eq!(number(&[(4, 2), (4, 2), (4, 2), (4, 2), (4, 2)]), 10);
}
