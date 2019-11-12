fn main() {
    let a1 = vec![121, 144, 19, 161, 19, 144, 19, 11];
    let a2 = vec![
        11 * 11,
        121 * 121,
        144 * 144,
        19 * 19,
        161 * 161,
        19 * 19,
        144 * 144,
        19 * 19,
    ];
    let b1 = vec![121, 144, 19, 161, 19, 144, 19, 11];
    let b2 = vec![
        11 * 21,
        121 * 121,
        144 * 144,
        19 * 19,
        161 * 161,
        19 * 19,
        144 * 144,
        19 * 19,
    ];
    println!("{} {}", comp(a1, a2), comp(b1, b2));
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
