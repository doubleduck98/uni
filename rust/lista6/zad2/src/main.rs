fn main() {
    println!("{}", dig_pow(3456789, 5));
}

fn dig_pow(n: i64, p: i32) -> i64 {
    let nvec: Vec<i64> = n
        .to_string()
        .chars()
        .map(|d| d.to_digit(10).unwrap() as i64)
        .collect();
    let mut exp: u32 = p as u32;
    let i: i64 = nvec.iter().fold(0, |acc, x| {
        exp += 1;
        acc + x.pow(exp-1)
    });
    let hm = (i as f64) / (n as f64);
    if hm.fract() != 0.0 {
        return -1;
    }
    i / n
}
