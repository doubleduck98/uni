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
