fn main() {
    println!("{}", dna_strand("ACTG"));
}

fn dna_strand(dna: &str) -> String {
    dna.chars()
        .map(|c| match c {
            'A' => 'T',
            'T' => 'A',
            'C' => 'G',
            'G' => 'C',
            _ => panic!(),
        })
        .collect()
}

#[test]
fn test0() {
    assert_eq!(dna_strand("ACTC"), "TGAG")
}
#[test]
fn test1() {
    assert_eq!(dna_strand("AAA"), "TTT")
}
#[test]
fn test2() {
    assert_eq!(dna_strand("CCC"), "GGG")
}
#[test]
fn test3() {
    assert_eq!(dna_strand("TTT"), "AAA")
}
#[test]
fn test4() {
    assert_eq!(dna_strand("GGG"), "CCC")
}
#[test]
fn test5() {
    assert_eq!(dna_strand("GGATC"), "CCTAG")
}
#[test]
fn test6() {
    assert_eq!(dna_strand("TAGTTC"), "ATCAAG")
}
#[test]
fn test7() {
    assert_eq!(dna_strand("GACTCAGCTAGCATCGACT"), "CTGAGTCGATCGTAGCTGA")
}
#[test]
fn test8() {
    assert_eq!(dna_strand(""), "")
}
#[test]
fn test9() {
    assert_eq!(dna_strand("ACTG"), "TGAC")
}
