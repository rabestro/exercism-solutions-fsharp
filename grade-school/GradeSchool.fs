module GradeSchool

type School = Map<int, string list>

let empty: School = Map.empty
let roster (school: School): string list = school.Values |> List.concat

let add (student: string) (grade: int) (school: School): School =
    if roster school |> Seq.contains student then
        school
    elif school.ContainsKey grade then
        let students = school.Item grade
        school.Add(grade, student :: students |> List.sort)
    else
        school.Add(grade, List.singleton student)

let grade (number: int) (school: School): string list =
    if school.ContainsKey number then school.Item number else List.empty
