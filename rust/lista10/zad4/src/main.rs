use regex::Regex;

fn main() {
    let s = "Program title: Primes\nAuthor: Kern\nCorporation: Gold\nPhone: +1-503-555-0091\nDate: Tues April 9, 2005\nVersion: 6.7\nLevel: Alpha";
    println!("{}", change(s, "Ladder", "1.1"));
}

fn change(s: &str, prog: &str, version: &str) -> String {
    let ver = Regex::new(r"Version: (?P<vn>\d+\.\d+)\n").unwrap().captures(s);
    let phone = Regex::new(r"Phone: (\+1-\d{3}-\d{3}-\d{4})\n")
        .unwrap()
        .captures(s);
    if ver.is_none() || phone.is_none() {
        return String::from("ERROR: VERSION or PHONE");
    }
    // to nie działa na codewars, ale działa u mnie
    // if ver.unwrap().get(2).map_or("", |m| m.as_str()) == "2.0" {
    if ver.unwrap().name("vn").map_or("", |m| m.as_str()) == "2.0" {
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
        let s1="Program title: Primes\nAuthor: Kern\nCorporation: Gold\nPhone: +1-503-555-0091\nDate: Tues April 9, 2005\nVersion: 6.7\nLevel: Alpha";
        dotest(s1, "Ladder", "1.1", "Program: Ladder Author: g964 Phone: +1-503-555-0090 Date: 2019-01-01 Version: 1.1");
        let s2="Program title: Balance\nAuthor: Dorries\nCorporation: Funny\nPhone: +1-503-555-0095\nDate: Tues July 19, 2014\nVersion: 6.7\nLevel: Release";
        dotest(s2, "Circular", "1.5", "Program: Circular Author: g964 Phone: +1-503-555-0090 Date: 2019-01-01 Version: 1.5");        
        let s3="Program title: Primes\nAuthor: Kern\nCorporation: Gold\nPhone: +1-503-555-0090\nDate: Tues April 9, 2005\nVersion: 67\nLevel: Alpha";
        dotest(s3, "Ladder", "1.1", "ERROR: VERSION or PHONE");        
    }
}
