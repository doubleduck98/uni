use regex::Regex;

fn main() {
    let s = "Program title: Primes\nAuthor: Kern\nCorporation: Gold\nPhone: +1-503-555-0091\nDate: Tues April 9, 2005\nVersion: 6.7\nLevel: Alpha";
    println!("{}", change(s, "Ladder", "1.1"));
}

fn change(s: &str, prog: &str, version: &str) -> String {
    let ver = Regex::new(r"Version: (?P<vn>\d+\.\d+)\n")
        .unwrap()
        .captures(s);
    let phone = Regex::new(r"Phone: (\+1-\d{3}-\d{3}-\d{4})\n")
        .unwrap()
        .captures(s);
    if ver.is_none() || phone.is_none() {
        return String::from("ERROR: VERSION or PHONE");
    }
    // to nie działa na codewars, ale działa u mnie
    if ver.unwrap().get(2).map_or("", |m| m.as_str()) == "2.0" {
    // if ver.unwrap().name("vn").map_or("", |m| m.as_str()) == "2.0" {
        format!(
            "Program: {} Author: g964 Phone: +1-503-555-0090 Date: 2019-01-01 Version: 2.0",
            prog
        )
    } else {
        format!(
            "Program: {} Author: g964 Phone: +1-503-555-0090 Date: 2019-01-01 Version: {}",
            prog, version
        )
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    fn dotest(s: &str, prog: &str, version: &str, exp: &str) -> () {
        println!("s:{:?}", s);
        println!("prog:{:?}", prog);
        println!("version:{:?}", version);
        let ans = change(s, prog, version);
        println!("actual: {:?}", ans);
        println!("expect: {:?}", exp);
        println!("{}", ans == exp);
        assert_eq!(ans, exp);
        println!("{}", "-");
    }
    #[test]
    fn basic_tests() {
        let s0 = "Program title: Primes\nAuthor: Kern\nCorporation: Gold\nPhone: +1-503-555-0090\nDate: Tues April 9, 2005\nVersion: 67\nLevel: Alpha";
        dotest(s0, "Ladder", "1.1", "ERROR: VERSION or PHONE");
    }
    #[test]
    fn test1() {
        let s1 = "Program title: Primes\nAuthor: Kern\nCorporation: Gold\nPhone: +1-503-555-0091\nDate: Tues April 9, 2005\nVersion: 6.7\nLevel: Alpha";
        dotest(
            s1,
            "Ladder",
            "1.1",
            "Program: Ladder Author: g964 Phone: +1-503-555-0090 Date: 2019-01-01 Version: 1.1",
        );
    }
    #[test]
    fn test2() {
        let s2 = "Program title: Balance\nAuthor: Dorries\nCorporation: Funny\nPhone: +1-503-555-0095\nDate: Tues July 19, 2014\nVersion: 6.7\nLevel: Release";
        dotest(
            s2,
            "Circular",
            "1.5",
            "Program: Circular Author: g964 Phone: +1-503-555-0090 Date: 2019-01-01 Version: 1.5",
        );
    }
    #[test]
    fn test3() {
        let s3 = "Program title: Balance\nAuthor: Dorries\nCorporation: Funny\nPhone: +1-503-555-0095\nDate: Tues July 19, 2014\nVersion: 6.7\nLevel: Release";
        dotest(
            s3,
            "Circular",
            "2.0",
            "Program: Circular Author: g964 Phone: +1-503-555-0090 Date: 2019-01-01 Version: 2.0",
        );
    }
    #[test]
    fn test4() {
        let s4 = "Program title: Balance\nAuthor: Dorries\nCorporation: Funny\nPhone: +1-503-555-0095\nDate: Tues July 19, 2014\nVersion: 6.7\nLevel: Release";
        dotest(
            s4,
            "Circular",
            "2.0",
            "Program: Circular Author: g964 Phone: +1-503-555-0090 Date: 2019-01-01 Version: 2.0",
        );
    }
    #[test]
    fn test5() {
        let s5 = "Program title: Balance\nAuthor: szipi\nCorporation: Funny\nPhone: 997\nDate: Tues July 19, 2014\nVersion: 6.7\nLevel: Release";
        dotest(s5, "Circular", "2.0", "ERROR: VERSION or PHONE");
    }
    #[test]
    fn test6() {
        let s6 = "Program title: Balance\nAuthor: szipi\nCorporation: Funny\nPhone: +1-503-555-0095\nDate: Tues July 19, 2014\nVersion: 69\nLevel: Release";
        dotest(s6, "Circular", "2.0", "ERROR: VERSION or PHONE");
    }
    #[test]
    fn test7() {
        let s7 = "Program title: Balance\nAuthor: szipi\nCorporation: Funny\nPhone: +1-503-555-0095\nDate: Tues July 19, 2014\nVersion:  \nLevel: Release";
        dotest(s7, "Circular", "", "ERROR: VERSION or PHONE");
    }
    #[test]
    fn test8() {
        let s8 = "Program title: Balance\nAuthor: szipi\nCorporation: Funny\nPhone: +1-503-555-0095\nDate: Tues July 19, 2014\nVersion: 6.9\nLevel: Release";
        dotest(
            s8,
            "",
            "2.0",
            "Program:  Author: g964 Phone: +1-503-555-0090 Date: 2019-01-01 Version: 2.0",
        );
    }
    #[test]
    fn test9() {
        let s9 = "";
        dotest(s9, "Circular", "2.0", "ERROR: VERSION or PHONE");
    }
}
