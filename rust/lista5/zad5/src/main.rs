use std::collections::VecDeque;

fn main() {
    println!("{:?}", testing(10, 22));
}

fn dbl_linear(n: u32) -> u32 {
    let mut x: u32 = 1;
    let mut yq: VecDeque<u32> = VecDeque::new();
    let mut zq: VecDeque<u32> = VecDeque::new();
    for _ in 0..n {
        let y: u32 = 2 * x + 1;
        let z: u32 = 3 * x + 1;
        yq.push_back(y);
        zq.push_back(z);
        x = std::cmp::min(yq[0], zq[0]); //albo *q.get(0).unwrap()
        if x == yq[0] {
            x = yq.pop_front().unwrap();
        }
        if x == zq[0] {
            x = zq.pop_front().unwrap();
        }
    }
    x
}

fn testing(n: u32, exp: u32) -> () {
    assert_eq!(dbl_linear(n), exp)
}

#[test]
fn test0() {
    testing(10, 22);
}
#[test]
fn test1() {
    testing(20, 57);
}
#[test]
fn test2() {
    testing(30, 91);
}
#[test]
fn test3() {
    testing(50, 175);
}
#[test]
fn test4() {
    testing(100, 447);
}
#[test]
fn test5() {
    testing(120, 543);
}
#[test]
fn test6() {
    testing(140, 693);
}
#[test]
fn test7() {
    testing(160, 777);
}
#[test]
fn test8() {
    testing(180, 957);
}
#[test]
fn test9() {
    testing(200, 1051);
}
