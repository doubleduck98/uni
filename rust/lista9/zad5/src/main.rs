fn main() {
    println!(
        "{}",
        solution::range_extraction(&[
            -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20
        ])
    );
}

mod solution {
    pub fn range_extraction(a: &[i32]) -> String {
        let mut res: Vec<String> = Vec::new();
        let mut fst: i32 = a[0];
        let mut last: i32 = a[0];
        for curr in a.iter().skip(1) {
            if *curr == last + 1 {
                last = *curr;
            } else if (fst - last).abs() >= 2 {
                res.push(format!("{}-{}", fst, last));
                fst = *curr;
                last = *curr;
            } else {
                res.push(format!("{}", fst));
                if fst != last {
                    res.push(format!("{}", last));
                }
                fst = *curr;
                last = *curr;
            }
        }
        if (fst - last).abs() >= 2 {
            res.push(format!("{}-{}", fst, last));
        } else {
            res.push(format!("{}", fst));
            if fst != last {
                res.push(format!("{}", last));
            }
        }
        res.join(",")
    }
}

#[test]
fn test0() {
    assert_eq!(
        solution::range_extraction(&[
            -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20
        ]),
        "-6,-3-1,3-5,7-11,14,15,17-20"
    )
}
#[test]
fn test1() {
    assert_eq!(
        solution::range_extraction(&[-3, -2, -1, 2, 10, 15, 16, 18, 19, 20]),
        "-3--1,2,10,15,16,18-20"
    )
}
#[test]
fn test2() {
    assert_eq!(solution::range_extraction(&[0, 1, 2, 3, 4, 5]), "0-5")
}
#[test]
fn test3() {
    assert_eq!(
        solution::range_extraction(&[0, 2, 4, 6, 8, 10]),
        "0,2,4,6,8,10"
    )
}
#[test]
fn test4() {
    assert_eq!(
        solution::range_extraction(&[1, 3, 5, 7, 9, 11]),
        "1,3,5,7,9,11"
    )
}
#[test]
fn test5() {
    assert_eq!(
        solution::range_extraction(&[1, 2, 5, 6, 7, 8, 9, 12, 14, 15, 17]),
        "1,2,5-9,12,14,15,17"
    )
}
#[test]
fn test6() {
    assert_eq!(
        solution::range_extraction(&[-5, -4, -2, -1, 0, 2, 3]),
        "-5,-4,-2-0,2,3"
    )
}
#[test]
fn test7() {
    assert_eq!(
        solution::range_extraction(&[-9, -8, -6, -3, -2, -1]),
        "-9,-8,-6,-3--1"
    )
}
#[test]
fn test8() {
    assert_eq!(solution::range_extraction(&[1, 3, 37]), "1,3,37")
}
#[test]
fn test9() {
    assert_eq!(solution::range_extraction(&[1]), "1")
}
