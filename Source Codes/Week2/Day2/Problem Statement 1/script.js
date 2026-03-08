//JS_Day7_Hands_on_Problem_Statement1_HarishBabuKaveri
const marks = [75, 80, 65, 90, 55];
const calculateTotal = (arr) => arr.reduce((sum, mark) => sum + mark, 0);
    
const calculateAverage = (arr) => {
    const total = calculateTotal(arr);
    return total / arr.length;
};
    
const getResult = (average) => (average >= 40 ? "Pass" : "Fail");
    
const formattedMarks = marks.map((mark, index) => `Subject ${index + 1}: ${mark}`);

const totalMarks = calculateTotal(marks);
const averageMarks = calculateAverage(marks);
const result = getResult(averageMarks);

console.log(`
Student Marks Report
--------------------
${formattedMarks.join("\n")}

Total Marks   : ${totalMarks}
Average Marks : ${averageMarks.toFixed(2)}
Result        : ${result}
`);

document.getElementById("output").innerHTML = `
    <p>Student Marks Report</p>
    <p>--------------------</p>
    <p>${formattedMarks.join(", ")}</p>
    <p>Total Marks   : ${totalMarks}</p>
    <p>Average Marks : ${averageMarks.toFixed(2)}</p>
    <p>Result        : ${result}</p>
    `;