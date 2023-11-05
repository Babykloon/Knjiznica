namespace WinFormsApp8
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxBooks = new ComboBox();
            comboBoxStudents = new ComboBox();
            buttonAddBook = new Button();
            textBoxBookName = new TextBox();
            textBoxBookAuthor = new TextBox();
            textBoxBookQuantity = new TextBox();
            buttonAddStudent = new Button();
            textBox1 = new TextBox();
            ButtonInfo = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonBorrowBook = new Button();
            buttonReturnBook = new Button();
            buttonRemoveBook = new Button();
            buttonSearchBook = new Button();
            SuspendLayout();
            // 
            // comboBoxBooks
            // 
            comboBoxBooks.FormattingEnabled = true;
            comboBoxBooks.Location = new Point(2, 34);
            comboBoxBooks.Name = "comboBoxBooks";
            comboBoxBooks.Size = new Size(334, 23);
            comboBoxBooks.TabIndex = 0;
            // 
            // comboBoxStudents
            // 
            comboBoxStudents.FormattingEnabled = true;
            comboBoxStudents.Location = new Point(452, 34);
            comboBoxStudents.Name = "comboBoxStudents";
            comboBoxStudents.Size = new Size(168, 23);
            comboBoxStudents.TabIndex = 1;
            // 
            // buttonAddBook
            // 
            buttonAddBook.Location = new Point(102, 233);
            buttonAddBook.Name = "buttonAddBook";
            buttonAddBook.Size = new Size(100, 23);
            buttonAddBook.TabIndex = 2;
            buttonAddBook.Text = "Dodaj Knjigu";
            buttonAddBook.UseVisualStyleBackColor = true;
            buttonAddBook.Click += buttonAddBook_Click;
            // 
            // textBoxBookName
            // 
            textBoxBookName.Location = new Point(102, 84);
            textBoxBookName.MaxLength = 50;
            textBoxBookName.Name = "textBoxBookName";
            textBoxBookName.Size = new Size(100, 23);
            textBoxBookName.TabIndex = 4;
            // 
            // textBoxBookAuthor
            // 
            textBoxBookAuthor.Location = new Point(102, 131);
            textBoxBookAuthor.MaxLength = 50;
            textBoxBookAuthor.Name = "textBoxBookAuthor";
            textBoxBookAuthor.Size = new Size(100, 23);
            textBoxBookAuthor.TabIndex = 5;
            // 
            // textBoxBookQuantity
            // 
            textBoxBookQuantity.Location = new Point(102, 186);
            textBoxBookQuantity.MaxLength = 4;
            textBoxBookQuantity.Name = "textBoxBookQuantity";
            textBoxBookQuantity.Size = new Size(100, 23);
            textBoxBookQuantity.TabIndex = 6;
            // 
            // buttonAddStudent
            // 
            buttonAddStudent.Location = new Point(520, 111);
            buttonAddStudent.Name = "buttonAddStudent";
            buttonAddStudent.Size = new Size(100, 23);
            buttonAddStudent.TabIndex = 7;
            buttonAddStudent.Text = "Dodaj Studenta";
            buttonAddStudent.UseVisualStyleBackColor = true;
            buttonAddStudent.Click += buttonAddStudent_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(520, 71);
            textBox1.MaxLength = 50;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 8;
            // 
            // ButtonInfo
            // 
            ButtonInfo.Location = new Point(647, 24);
            ButtonInfo.Name = "ButtonInfo";
            ButtonInfo.Size = new Size(87, 41);
            ButtonInfo.TabIndex = 9;
            ButtonInfo.Text = "Dodatne Informacije";
            ButtonInfo.UseVisualStyleBackColor = true;
            ButtonInfo.Click += ButtonInfo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 87);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 11;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 134);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 12;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 189);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 13;
            label4.Text = "label4";
            // 
            // buttonBorrowBook
            // 
            buttonBorrowBook.Location = new Point(356, 34);
            buttonBorrowBook.Name = "buttonBorrowBook";
            buttonBorrowBook.Size = new Size(75, 23);
            buttonBorrowBook.TabIndex = 14;
            buttonBorrowBook.Text = "Posudi";
            buttonBorrowBook.UseVisualStyleBackColor = true;
            buttonBorrowBook.Click += buttonBorrowBook_Click;
            // 
            // buttonReturnBook
            // 
            buttonReturnBook.Location = new Point(356, 74);
            buttonReturnBook.Name = "buttonReturnBook";
            buttonReturnBook.Size = new Size(75, 40);
            buttonReturnBook.TabIndex = 15;
            buttonReturnBook.Text = "Vrati Knjigu";
            buttonReturnBook.UseVisualStyleBackColor = true;
            buttonReturnBook.Click += buttonReturnBook_Click;
            // 
            // buttonRemoveBook
            // 
            buttonRemoveBook.Location = new Point(102, 305);
            buttonRemoveBook.Name = "buttonRemoveBook";
            buttonRemoveBook.Size = new Size(100, 23);
            buttonRemoveBook.TabIndex = 16;
            buttonRemoveBook.Text = "Obriši Knjigu";
            buttonRemoveBook.UseVisualStyleBackColor = true;
            buttonRemoveBook.Click += buttonRemoveBook_Click;
            // 
            // buttonSearchBook
            // 
            buttonSearchBook.Location = new Point(356, 131);
            buttonSearchBook.Name = "buttonSearchBook";
            buttonSearchBook.Size = new Size(75, 33);
            buttonSearchBook.TabIndex = 17;
            buttonSearchBook.Text = "Traži Knjigu";
            buttonSearchBook.UseVisualStyleBackColor = true;
            buttonSearchBook.Click += buttonSearchBook_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSearchBook);
            Controls.Add(buttonRemoveBook);
            Controls.Add(buttonReturnBook);
            Controls.Add(buttonBorrowBook);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ButtonInfo);
            Controls.Add(textBox1);
            Controls.Add(buttonAddStudent);
            Controls.Add(textBoxBookQuantity);
            Controls.Add(textBoxBookAuthor);
            Controls.Add(textBoxBookName);
            Controls.Add(buttonAddBook);
            Controls.Add(comboBoxStudents);
            Controls.Add(comboBoxBooks);
            Name = "Form1";
            Text = "Form1";
            Click += Form1_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxBooks;
        private ComboBox comboBoxStudents;
        private Button buttonAddBook;
        private TextBox textBoxBookName;
        private TextBox textBoxBookAuthor;
        private TextBox textBoxBookQuantity;
        private Button buttonAddStudent;
        private TextBox textBox1;
        private Button ButtonInfo;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonBorrowBook;
        private Button buttonReturnBook;
        private Button buttonRemoveBook;
        private Button buttonSearchBook;
    }
}