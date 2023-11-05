using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        private Library library;
        private CodeGenerator bookcodes;
        private CodeGenerator studentcodes;


        public Form1()
        {
            InitializeComponent();
            library = new Library();
            bookcodes = new CodeGenerator();



            label2.Text = "Ime";

            label3.Text = "Autor";

            label4.Text = "Kolièina";


            foreach (Book book in library.GetBooks())
            {
                comboBoxBooks.Items.Add($"{book.Name} od {book.Author} - {book.CopiesAvailable} Available - Code: {book.Code}");
            }


            foreach (Student student in library.GetStudents())
            {
                comboBoxStudents.Items.Add(student.Name + " - ID: " + student.Id);
            }

        }


        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBookName.Text) || string.IsNullOrWhiteSpace(textBoxBookAuthor.Text) || string.IsNullOrWhiteSpace(textBoxBookQuantity.Text))
            {
                MessageBox.Show("Polja ne smiju biti prazna.");
            }
            else
            {
                try
                {
                    string code = CodeGenerator.GenerateUniqueCode(library.GetBooks().Select(b => b.Code).ToList());
                    string name = textBoxBookName.Text;
                    string author = textBoxBookAuthor.Text;
                    int quantity;

                    if (!int.TryParse(textBoxBookQuantity.Text, out quantity))
                    {
                        MessageBox.Show("Kolièina mora biti valjani broj.");
                        return;
                    }

                    library.AddBook(code, name, author, quantity);


                    comboBoxBooks.Items.Clear();
                    foreach (Book book in library.GetBooks())
                    {
                        comboBoxBooks.Items.Add($"{book.Name} by {book.Author} - {book.CopiesAvailable} Available - Code: {book.Code}");
                    }
                }
                catch
                {
                    MessageBox.Show("Greška u upisu podataka.");
                }
            }
        }


        private void buttonReturnBook_Click(object sender, EventArgs e)
        {
            if (comboBoxStudents.SelectedItem == null || comboBoxBooks.SelectedItem == null)
            {
                MessageBox.Show("Odaberite knjigu i studenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string selectedStudentName = comboBoxStudents.SelectedItem.ToString();
                string[] studentDetails = selectedStudentName.Split('-');
                string studentName = studentDetails[0].Trim();
                string selectedBookDetails = comboBoxBooks.SelectedItem.ToString();

                string bookCode = selectedBookDetails.Substring(selectedBookDetails.LastIndexOf("Code:") + 6).Trim();

                Student selectedStudent = library.GetStudents().Find(s => s.Name == studentName);
                Book selectedBook = library.GetBooks().Find(b => b.Code == bookCode);

                if (selectedStudent != null && selectedBook != null && selectedStudent.BorrowedBooks.Contains(selectedBook))
                {
                    selectedStudent.BorrowedBooks.Remove(selectedBook);
                    selectedBook.IncreaseCopiesAvailable();
                    MessageBox.Show($"Knjiga {selectedBook.Name} vraèena od strane {selectedStudent.Name}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxBooks.Items.Clear();
                    foreach (Book book in library.GetBooks())
                    {
                        comboBoxBooks.Items.Add($"{book.Name} od {book.Author} - {book.CopiesAvailable} Available - Code: {book.Code}");
                    }
                }
                else
                {
                    MessageBox.Show("Odabrani student nema posuðenu odabranu knjigu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            if (comboBoxBooks.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite knjigu koji tražite.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string selectedBookDetails = comboBoxBooks.SelectedItem.ToString();
                string bookCode = selectedBookDetails.Substring(selectedBookDetails.LastIndexOf("Code:") + 6).Trim();

                Book selectedBook = library.GetBooks().Find(b => b.Code == bookCode);

                if (selectedBook != null)
                {
                    string message = "Studenti koji su posudili tu knjigu:" + Environment.NewLine;
                    bool found = false;

                    foreach (Student student in library.GetStudents())
                    {
                        foreach (Book book in student.BorrowedBooks)
                        {
                            if (book.Code == selectedBook.Code)
                            {
                                found = true;
                                DateTime returnDate = DateTime.Today.AddDays(30);
                                if (returnDate < DateTime.Today)
                                {
                                    message += $"{student.Name} (Datum povratka: {returnDate.ToString("dd/MM/yyyy")}) - Datum povratka je istekao." + Environment.NewLine;
                                }
                                else
                                {
                                    message += $"{student.Name} (Datum povratka: {returnDate.ToString("dd/MM/yyyy")})" + Environment.NewLine;
                                }
                            }
                        }
                    }

                    if (!found)
                    {
                        message = "Nema uèenika koji su posudili tu knjigu.";
                    }

                    MessageBox.Show(message, "Posuðeno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonRemoveBook_Click(object sender, EventArgs e)
        {
            if (comboBoxBooks.SelectedItem == null)
            {
                MessageBox.Show("Odaberi knjigu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string selectedBookDetails = comboBoxBooks.SelectedItem.ToString();
                string bookCode = selectedBookDetails.Substring(selectedBookDetails.LastIndexOf("Code:") + 6).Trim();

                Book selectedBook = library.GetBooks().Find(b => b.Code == bookCode);

                if (selectedBook != null)
                {
                    int totalCopies = library.GetTotalCopies(bookCode);
                    if (selectedBook.CopiesAvailable == totalCopies)
                    {
                        DialogResult result = MessageBox.Show("Da li sigurno želite obrisati ovu knjigu?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            library.GetBooks().Remove(selectedBook);

                            comboBoxBooks.Items.Remove(comboBoxBooks.SelectedItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ova knjiga se ne može obrisati jer je posuðena.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "")
            {
                MessageBox.Show("Polje ne smije biti prazno");
            }
            else
            {
                string name = textBox1.Text;
                string id = CodeGeneratorStudent.GenerateUniqueCode(library.GetStudents().Select(b => b.Id).ToList());

                library.AddStudent(name, id);


                comboBoxStudents.Items.Clear();
                foreach (Student student in library.GetStudents())
                {
                    comboBoxStudents.Items.Add(student.Name + " - " + " - ID: " + student.Id);
                }
            }
        }



        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonInfo_Click(object sender, EventArgs e)
        {
            if (comboBoxStudents.SelectedItem == null)
            {
                MessageBox.Show("Odaberite studenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string selectedStudentName = comboBoxStudents.SelectedItem.ToString();
                string[] studentDetails = selectedStudentName.Split('-');
                string studentName = studentDetails[0].Trim();
                Student selectedStudent = library.GetStudents().Find(s => s.Name == studentName);

                string borrowedBooks = "";
                if (selectedStudent != null)
                {
                    foreach (Book book in selectedStudent.BorrowedBooks)
                    {
                        DateTime returnDate = DateTime.Now.AddDays(30);
                        string status = returnDate < DateTime.Now ? " (Overdue)" : "";
                        borrowedBooks += $"{book.Name} by {book.Author} - Datum vraèanja: {returnDate.ToShortDateString()}{status}\n";
                    }

                    MessageBox.Show($"Posuðene knjige:\n{borrowedBooks}", "Posuðene knjige od strane " + selectedStudentName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonBorrowBook_Click(object sender, EventArgs e)
        {
            if (comboBoxStudents.SelectedItem == null || comboBoxBooks.SelectedItem == null)
            {
                MessageBox.Show("Odaberite knjigu i studenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string selectedStudentName = comboBoxStudents.SelectedItem.ToString();
                string[] studentDetails = selectedStudentName.Split('-');
                string studentName = studentDetails[0].Trim();
                string bookDetails = comboBoxBooks.SelectedItem.ToString();

                string bookCode = bookDetails.Substring(bookDetails.LastIndexOf("Code:") + 6).Trim();

                Student selectedStudent = library.GetStudents().Find(s => s.Name == studentName);
                Book selectedBook = library.GetBooks().Find(b => b.Code == bookCode);

                if (selectedBook != null && selectedBook.CopiesAvailable > 0)
                {
                    if (!selectedStudent.BorrowedBooks.Contains(selectedBook))
                    {
                        library.BorrowBook(selectedStudent, selectedBook.Code);

                        comboBoxBooks.Items.Clear();
                        foreach (Book book in library.GetBooks())
                        {
                            comboBoxBooks.Items.Add($"{book.Name} od {book.Author} - {book.CopiesAvailable} Available - Code: {book.Code}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Odabrana knjiga veæ je posuðena od strane te osobe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Knjiga nije dostupna.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public class CodeGenerator
        {
            private static readonly Random random = new Random();
            private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            public static string GenerateUniqueCode(List<string> existingCodes)
            {
                string code;
                do
                {
                    code = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                } while (existingCodes.Contains(code));
                return code;
            }
        }

        public static class CodeGeneratorStudent
        {
            private static readonly Random random = new Random();
            private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            public static string GenerateUniqueCode(List<string> existingCodesStudents)
            {
                string code;
                do
                {
                    code = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
                } while (existingCodesStudents.Contains(code));
                return code;
            }
        }

        public class Book
        {
            private string code;
            private string name;
            private string author;
            private int copiesAvailable;

            public string Code { get { return code; } }
            public string Name { get { return name; } }
            public string Author { get { return author; } }
            public int CopiesAvailable { get { return copiesAvailable; } }

            public Book(string code, string name, string author, int copiesAvailable)
            {
                this.code = code;
                this.name = name;
                this.author = author;
                this.copiesAvailable = copiesAvailable;
            }

            public void DecreaseCopiesAvailable()
            {
                copiesAvailable--;
            }

            public void IncreaseCopiesAvailable()
            {
                copiesAvailable++;
            }



        }

        public class Student
        {
            public string Id { get; private set; }
            public string Name { get; private set; }
            public List<Book> BorrowedBooks { get; private set; }

            public Student(string name, string id)
            {
                Id = id;
                Name = name;
                BorrowedBooks = new List<Book>();
            }

        }

        public class Library
        {
            private List<Book> books;
            private List<Student> students;

            public void BorrowBook(Student student, string bookCode)
            {
                Book book = books.Find(b => b.Code == bookCode);

                if (book != null && book.CopiesAvailable > 0)
                {
                    student.BorrowedBooks.Add(book);
                    book.DecreaseCopiesAvailable();
                }
            }




            public Library()
            {
                books = new List<Book>
            {

                new Book("B001", "The Great Gatsby", "F. Scott Fitzgerald", 5),
                new Book("B002", "To Kill a Mockingbird", "Harper Lee", 5),
                new Book("B003", "1984", "George Orwell", 5),
                new Book("B004", "The Catcher in the Rye", "J.D. Salinger", 5)

            };

                students = new List<Student>
            {

                new Student("Ivor Trstenjak" , "ABCD"),
                new Student("Jakov Biškup" , "DBAC"),
                new Student("Noel Špoljariæ" , "DFFE"),
                new Student("Karlo Preložnjak" , "AAAD"),
                new Student("Andro Suvajac" , "DNFD")

            };



            }

            public int GetTotalCopies(string bookCode)
            {
                Book selectedBook = books.Find(b => b.Code == bookCode);
                if (selectedBook != null)
                {
                    int borrowedCopies = 0;
                    foreach (Student student in students)
                    {
                        foreach (Book borrowedBook in student.BorrowedBooks)
                        {
                            if (borrowedBook.Code == bookCode)
                            {
                                borrowedCopies++;
                            }
                        }
                    }
                    return selectedBook.CopiesAvailable + borrowedCopies;
                }
                return 0;
            }



            public List<Book> GetBooks()
            {
                return books;
            }

            public List<Student> GetStudents()
            {
                return students;
            }


            public void AddBook(string code, string name, string author, int copiesAvailable)
            {
                books.Add(new Book(code, name, author, copiesAvailable));
            }

            public void AddStudent(string name, string id)
            {
                students.Add(new Student(name, id));
            }
        }
    }
}

