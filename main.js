function getRandomIndex(array) {
    return Math.floor(Math.random() * array.length);
  }
  
  const students = ["Student 1", "Student 2", "Student 3", "Student 4", "Student 5", "Student 6", "Student 7", "Student 8", "Student 9"];
  
  const pairs = [];
  
  while (students.length > 1) {
    const index1 = getRandomIndex(students);
    const student1 = students[index1];
    students.splice(index1, 1);
  
    const index2 = getRandomIndex(students);
    const student2 = students[index2];
    students.splice(index2, 1);
  
    pairs.push([student1, student2]);
  }
  
  // If there is one student left, add them to a pair as an individual
  if (students.length === 1) {
    pairs.push([students[0]]);
  }
  
  console.table(pairs);