fn main() {
    println!("{}", last_digit("10", "100000"));
}

fn exp_mod_4(exp: &str) -> u32 {
    exp.chars()
        .fold(0, |acc, x| (acc * 10 + x.to_digit(10).unwrap()) % 4)
}

fn last_digit(str1: &str, str2: &str) -> i32 {
    if str2 == "0" {return 1}
    str1
        .chars()
        .last()
        .unwrap()
        .to_digit(10)
        .unwrap()
        .pow(if exp_mod_4(str2) == 0 {4} else {exp_mod_4(str2)}) as i32
        % 10
}
