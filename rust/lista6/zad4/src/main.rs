fn main() {
    let a = vec![121, 144, 19, 161, 19, 144, 19, 11];
    let b = vec![11*11, 121*121, 144*144, 19*19, 161*161, 19*19, 144*144, 19*19];
    assert_eq!(comp(a, b), true)
}

fn comp(a: Vec<i64>, b: Vec<i64>) -> bool {
    if a.is_empty() && b.is_empty() {
        return true;
    } else if a.len() != b.len() {
        return false;
    }
    let mut aa: Vec<i64> = a.into_iter().map(|x| x.pow(2)).collect();
    let mut bb = b;
    aa.sort();
    bb.sort();
    aa == bb
}

#[test]
fn test0 () {
    let a = vec![121, 144, 19, 161, 19, 144, 19, 11];
    let b = vec![11*11, 121*121, 144*144, 19*19, 161*161, 19*19, 144*144, 19*19];
    assert_eq!(comp(a, b), true)
}
#[test]
fn test1 () {
    let a = vec![121, 144, 19, 161, 19, 144, 19, 11];
    let b = vec![11*21, 121*121, 144*144, 19*19, 161*161, 19*19, 144*144, 19*19];
    assert_eq!(comp(a, b), false)
}
#[test]
fn test2 () {
    let a = vec![];
    let b = vec![];
    assert_eq!(comp(a, b), true)
}
#[test]
fn test3 () {
    let a = vec![1, 2, 3, 4, 5];
    let b = vec![1, 2*2, 3*3, 4*4, 5*5];
    assert_eq!(comp(a, b), true)
}
#[test]
fn test4 () {
    let a = vec![1, 2, 3, 4, 5];
    let b = vec![1, 2*2, 3*3, 4, 5*5];
    assert_eq!(comp(a, b), false)
}
#[test]
fn test5 () {
    let a = vec![1, 2, 3, 4, 5];
    let b = vec![-1*-1, 2*2, 3*3, 4*4, 5*5];
    assert_eq!(comp(a, b), true)
}
#[test]
fn test6 () {
    let a = vec![1, 1, 1, 1, 1];
    let b = vec![1, 1, 1, 1, 1];
    assert_eq!(comp(a, b), true)
}
#[test]
fn test7 () {
    let a = vec![1, 2, 2, 2, 5];
    let b = vec![1, 4, 4, 5*5, 4];
    assert_eq!(comp(a, b), true)
}
#[test]
fn test8 () {
    let a = vec![10, 20, 30, 40, 50];
    let b = vec![10, 20, 30, 40, 50];
    assert_eq!(comp(a, b), false)
}
#[test]
fn test9 () {
    let a = vec![10, 20, 30, 40, 50];
    let b = vec![10*10, 20*20, 30*30, 40*40, 50*50];
    assert_eq!(comp(a, b), true)
}