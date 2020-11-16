using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Chap14DefiningClass
{
    //part 1: define class which contain Student info
    class Student
    {
        //Field
        private string fullName;
        private string course;
        private string subject;
        private string university;
        private string email;
        private string contact;

        //part 3: static field which hold number of object created
        private static int studentObjectCreated;

        //part 5: encapsulate the data of class studet in Property
        //Property
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }
        public string Course
        {
            get { return this.course; }
            set { this.course = value; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public string University
        {
            get { return university; }
            set { university = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        //part 3: 
        public static int GetStudentObject
        {
            get { return studentObjectCreated; }
        }

        //Constructor
        //part2: several constructor and data no initial value initialized with null

        public Student()
            : this(null)
        {
        }
        public Student(string name)
            : this(name, null)
        {
        }
        public Student(string name, string course)
            : this(name, course, null)
        {
        }
        public Student(string name, string course, string subject)
            : this(name, course, subject, null)
        {
        }
        public Student(string name, string course, string subject, string university)
            : this(name, subject, course, university, null)
        {
        }
        public Student(string name, string course, string subject, string uni, string email)
            : this(name, course, subject, uni, email, null)
        {
        }
        public Student(string name, string course, string subject, string uni, string email, string contact)
        {
            this.FullName = name;
            this.Course = course;
            this.Subject = subject;
            this.University = uni;
            this.Email = email;
            this.Contact = contact;
            studentObjectCreated++;
        }

        //part 4: which show complete information about student
        public void GetStudentDate()
        {
            Console.WriteLine("Full Name: " + FullName + "\nCourse: " + Course + "\nSubject: " + Subject + "\nUniversity: " + University
                + "\nEmail: " + Email + "\nContact: " + Contact + "\n\n");
        }
    }
    //part 6: Create the class student test which test the functionality of student and store them in static field and property and display the info 
    class StudentTest
    {
        private static Student objDataStore;
        public static Student ObjDataStore
        {
            get { return objDataStore; }
            set { objDataStore = value; }
        }

        static StudentTest()
        {
            Student std1 = new Student("John", null, "Programming", "UBIT", null, "0333-3598423");
            Student std2 = new Student("Taha", null, "Programming", "UBIT", null, "0333-3598423");
            Student std3 = new Student("Sam", null, "Programming", "UBIT", null, "0333-3598423");
            Student std4 = new Student("Shadow", null, "Programming", "UBIT", null, "0333-3598423");
            Student std5 = new Student("Hp", null, "Programming", "UBIT", null, "0333-3598423");

            ObjDataStore = std1;
        }

        //part 7: static method in StudentTest and create several object of type student 
        public static void StdMain()
        {
            Student std1 = new Student("John", null, "Programming", "UBIT", null, "0333-3598423");
            std1.GetStudentDate();
            Student std2 = new Student("Taha", null, "Programming", "UBIT", null, "0333-3598423");
            std2.GetStudentDate();
            Student std3 = new Student("Sam", null, "Programming", "UBIT", null, "0333-3598423");
            std3.GetStudentDate();
            Student std4 = new Student("Shadow", null, "Programming", "UBIT", null, "0333-3598423");
            std4.GetStudentDate();
            Student std5 = new Student("Hp", null, "Programming", "UBIT", null, "0333-3598423");
            std5.GetStudentDate();

            Console.WriteLine("Number of Student: " + Student.GetStudentObject + "\n\n\n");
        }
        //accessing data from method
        public static void GetObjDataStore()
        {
            StudentTest.ObjDataStore.GetStudentDate();
        }
    }

    // part 8: class of Mobile phone
    class MobilePhone
    {
        private string model;
        private string manufacturer;
        private int price;
        private string owner;
        BatteryFeatures battery;
        ScreenFeatures screen;

        //part 10: In static field nokiaN95 store information about mobile model and display that info in method
        static string nokiaN95 = "N95";



        public class BatteryFeatures
        {
            //part1 13: define property to encapsulate 
            public string model { get; set; }
            public int idleTime { get; set; }
            public int hoursTalk { get; set; }
            //part 11: enum of battery type
            public enum BatteryType
            {
                LiIon, NiMH, NiCD
            }
            public BatteryFeatures() { }
            public BatteryFeatures(string model, int idleTime, int hoursTalk)
            {
                this.model = model;
                this.idleTime = idleTime;
                this.hoursTalk = hoursTalk;
            }
            public void DisplayBatteryInfo()
            {
                Console.WriteLine("Model: " + this.model + "\nIdleTime: " + this.idleTime + "\nHoursTalk: " + this.hoursTalk);
            }

        }

        public class ScreenFeatures
        {
            public string size { get; set; }
            public string color { get; set; }
            public ScreenFeatures() { }

            public ScreenFeatures(string size, string color)
            {
                this.size = size;
                this.color = color;
            }
            public void DisplayScreenInfo()
            {
                Console.WriteLine("Size: " + this.size + "\nColor: " + this.color);
            }

        }

        //part 9: build several constructor and return default value if not intial
        public MobilePhone()
            : this(null) { }
        public MobilePhone(string model)
            : this(model, null) { }
        public MobilePhone(string model, string mnufctr)
            : this(model, mnufctr, 0) { }
        public MobilePhone(string model, string mnufctr, int price)
            : this(model, mnufctr, price, null) { }
        public MobilePhone(string model, string mnufctr, int price, string owner)
            : this(model, mnufctr, price, owner, new BatteryFeatures()) { }
        public MobilePhone(string model, string mnufctr, int price, string owner, BatteryFeatures battery)
            : this(model, mnufctr, price, owner, new BatteryFeatures(), new ScreenFeatures()) { }
        public MobilePhone(string model, string mnufctr, int price, string owner, BatteryFeatures battery, ScreenFeatures screen)
        {
            this.model = model;
            this.manufacturer = mnufctr;
            this.price = price;
            this.owner = owner;
            battery = new BatteryFeatures(battery.model, battery.idleTime, battery.hoursTalk);
            this.battery = battery;
            screen = new ScreenFeatures(screen.size, screen.color);
            this.screen = screen;
        }

        public void PrintMobileFeatures()
        {
            Console.WriteLine("Model = " + this.model + "\nManufacturer = " + this.manufacturer + "\nPrice = " + this.price + "\nOwner is " + this.owner);
            this.battery.DisplayBatteryInfo();
            this.screen.DisplayScreenInfo();
            //part 10: display static field info in method
            Console.WriteLine("Model is " + nokiaN95);
        }
    }
    //part 12:

    class GMS<T>
    {
        private T value;

        public GMS(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return base.ToString() + " : " + value.ToString();
        }
    }

    class GMSTest
    {
        //test the functionally and store them into array and display info
        public GMSTest()
        {
            MobilePhone.BatteryFeatures bty = new MobilePhone.BatteryFeatures();
            MobilePhone.ScreenFeatures scn = new MobilePhone.ScreenFeatures();

            MobilePhone m1 = new MobilePhone("m1", "nokia", 123, "John", bty, scn);
            MobilePhone m2 = new MobilePhone("m2", "samsung", 123, "John", bty, scn);
            MobilePhone m3 = new MobilePhone("m3", "samsung", 123, "John", bty, scn);
            MobilePhone m4 = new MobilePhone("m4", "samsung", 123, "Arif", bty, scn);

            MobilePhone[] objHolder = new MobilePhone[4];
            objHolder[0] = m1;
            objHolder[1] = m2;
            objHolder[2] = m3;
            objHolder[3] = m4;

            for (int i = 0; i < objHolder.Length; i++)
            {
                objHolder[i].PrintMobileFeatures();
            }
        }
    }


    //part 15: Create class Call, which contain information about date, start of time and duration of call via mobile
    class Call
    {
        // to store call history
        DateTime[] callHistory = new DateTime[10];
        Stopwatch[] durationHistory = new Stopwatch[10];
        //index for variables
        int i = 0;
        public void MainPage()
        {
            try
            {
                Console.WriteLine("Press 1-Dial Call   2-Check History   3-Delete History");
                int key = int.Parse(Console.ReadLine());
                //decide which method to call by userinput
                if (key == 1)
                {
                    CallPage();
                }
                else if (key == 2)
                {
                    CallHistoryMethod();
                }
                else if (key == 3)
                {
                    DeleteHistory();
                }
                else
                {
                    Console.WriteLine("U press wrong Number");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error");
            }
        }

        public void CallPage()
        {
            // clear console screen

            Console.WriteLine("Make Call?");
            try
            {
                Console.WriteLine("1-Yes    2-No");
                int key = int.Parse(Console.ReadLine());
                if (key == 1)
                {
                    Console.Clear();
                    // to get the current date 
                    DateTime d = DateTime.Now;
                    Console.WriteLine("On Call");
                    // stopwatch to measured the duration of the call
                    System.Diagnostics.Stopwatch stpwtch = new System.Diagnostics.Stopwatch();
                    // start the watch
                    stpwtch.Start();
                    int press = 0;
                    Console.WriteLine("Press 1-Cancel");
                    while (press == 0)
                    {
                        // when user press 1 if break the loop
                        press = int.Parse(Console.ReadLine());
                    }
                    // stop the watch
                    stpwtch.Stop();

                    Console.WriteLine("Stopwatch: " + stpwtch.Elapsed);
                    string str = stpwtch.Elapsed.ToString();
                    Console.WriteLine(str);
                    int it = Convert.ToInt32(str);
                    Console.WriteLine(it);


                    // print the date, time of start and duration of that current call only
                    Console.WriteLine("Date: {0:dd/MM/yyyy}", d);
                    Console.WriteLine("Time of Start: {0:hh\\:mm\\:ss}", d);
                    Console.WriteLine("Duration: {0:hh\\:mm\\:ss} ", stpwtch.Elapsed);

                    //System.Threading.Thread.Sleep(1000); delay of 1 second                    
                    //to protect from StackOverFlow exception: if i > array.Length it again start index from zero
                    if (i == callHistory.Length)
                    {
                        i = 0;
                    }
                    // to get the date of current call in History
                    this.callHistory[i] = d;
                    // to get the duration of current call in duration history
                    this.durationHistory[i] = stpwtch;
                    // to increased index by 1 to get the next call history in variable
                    i++;
                    //if 

                    CallPage();
                }
                else
                {
                    // it again call the previous page
                    MainPage();
                }
            }
            // if user press other than numbers
            catch (FormatException)
            {
                Console.WriteLine("Error");
                MainPage();
            }
            // trying to Add timer and failed becoz i need stopwatch for this
            //Console.WriteLine("SomeText");
            //System.Threading.Thread.Sleep(1000);
            //Console.WriteLine("Press Any key To Continue...");

            //System.Threading.Timer t = new System.Threading.Timer(TimerCallBack, null, 0, 1000);
            //Console.ReadLine();
        }

        //part 16: Store call in History
        public void CallHistoryMethod()
        {
            Console.Clear();
            // display msg of 10 call history
            Console.WriteLine("Only show last 10 call History \n");
            for (int i = 0; i < callHistory.Length; i++)
            {
                //callhistory[i] can't be null becoz it contain default value 01/01/1001 12:00:00 AM
                //break if duration is null so it avoid to print unnecessary data
                if (durationHistory[i] == null) { break; }
                //display call info
                Console.WriteLine("Date: {0:dd/MM/yyyy}", callHistory[i]);
                Console.WriteLine("Time of Start: {0:hh\\:mm\\:ss}", callHistory[i]);
                Console.WriteLine("Duration: {0:hh\\:mm\\:ss} \n", durationHistory[i].Elapsed);
            }
            MainPage();
        }
        //part 17;
        public void DeleteHistory()
        {
            //again allocate fresh memory for variable
            callHistory = new DateTime[10];
            durationHistory = new Stopwatch[10];
            MainPage();
        }

        //part18: total amount of calls and pass price of call in paramter of method
        public int CallPrice(int price)
        {
            Stopwatch s = new Stopwatch();
            int totalprice = 0;
            for (int i = 0; i < durationHistory.Length; i++)
            {
                //totalprice = durationHistory[i];
            }
            return totalprice;
        }
    }

    //drop ex 12, 18,19   

    //part 20: library must contain name list of book, book class contain title, author, publisher, release date and ISBN-Number. Method to add,search,delete, display info of books
    class Library
    {
        List<Book> name = new List<Book>();
        int lisOfBook = 20;
        Book book = new Book();

        public Library()
        {

        }
        public void LibraryDisplay()
        {
            Console.WriteLine("Press");
            Console.WriteLine("1-Add Book  2-Search Book   3-Delete Book   4-Get Book Info ");
            int presskey = Convert.ToInt32(Console.ReadLine());
            if (presskey == 1)
            {
                book = new Book();
                Console.Write("Title: ");
                book.title = Console.ReadLine();
                Console.Write("Author: ");
                book.author = Console.ReadLine();
                Console.Write("Publisher: ");
                book.publisher = Console.ReadLine();
                Console.Write("Release Date: ");
                string date = Console.ReadLine();
                book.releaseDate = default(DateTime);
                //book.releaseDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/YYYY", System.Globalization.CultureInfo.InvariantCulture);
                Console.Write("ISBN Number: ");
                book.ISBN = int.Parse(Console.ReadLine());

                //book = new Book(book.title, book.author, book.publisher, book.releaseDate, book.ISBN);

                AddBook(book);

            }
            else if (presskey == 2)
            {
                Console.Write("Write author Name: ");
                string author = Console.ReadLine();
                SearchBook(author);
            }
            else if (presskey == 3)
            {
                Console.Write("Index Number: ");
                int index = int.Parse(Console.ReadLine());
                DeleteBook(index - 1);
            }
            else if (presskey == 4)
            {
                foreach (Book item in name)
                {
                    item.GetBookInfo();
                    Console.WriteLine();
                }
                LibraryDisplay();
            }
            else
            {
                Console.WriteLine("Incorrect Key!!");
            }
        }

        public void AddBook(Book name)
        {

            this.name.Add(name);
            lisOfBook--;
            Console.WriteLine("Number of Book Slot left: " + lisOfBook);
            LibraryDisplay();
        }
        public void SearchBook(string authorName)
        {
            book = new Book();
            try
            {
                //find the Book author list from userinput author name

                // to find the first book of author name
                //book = name.Find(x => x.author.ToUpper() == authorName.ToUpper());
                //// get book info
                //book.GetBookInfo();

                //part 21: implement that find all the book of author
                // to show all the book from author
                if (name[0].author == authorName)
                {
                    for (int i = 0; i < name.Count; i++)
                    {
                        name[i].GetBookInfo();
                    }
                }
                LibraryDisplay();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error");
                LibraryDisplay();
            }
        }
        public void DeleteBook(int index)
        {
            this.name.RemoveAt(index);
            lisOfBook++;
            Console.WriteLine("Done" + "\nBook Slot left: " + lisOfBook);
            LibraryDisplay();
        }
    }

    class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public DateTime releaseDate { get; set; }
        public int ISBN { get; set; }


        public Book()
            : this(null, null, null, default(DateTime), 0)
        {
        }
        public Book(string title, string author, string publish, DateTime date, int isbn)
        {
            this.title = title;
            this.author = author;
            this.publisher = publish;
            this.releaseDate = date;
            this.ISBN = isbn;
        }
        public void GetBookInfo()
        {
            //Stopwatch a = new Stopwatch();
            //a.Start();
            //Console.WriteLine("Title: " + title);
            //Console.WriteLine("Author: " + author);
            //Console.WriteLine("Publisher: " + publisher);
            //Console.WriteLine("Release Date: " + releaseDate);
            //Console.WriteLine("ISBN-Number: " + ISBN);
            //a.Stop();
            //Console.WriteLine("First Clock: " + a.Elapsed);
            //System.Threading.Thread.Sleep(1000);
            //a = new Stopwatch();
            //a.Start();

            // for fun
            Console.WriteLine("Title: " + title + "\nAuthor: " + author + "\nPublisher: " + publisher + "\nRelease Date: " + releaseDate + "\nISBN Number: " + ISBN);

            //a.Stop();
            // best pattern for display
            //Console.WriteLine("Second Clock: " + a.Elapsed);
            //a = new Stopwatch();
            //a.Start();
            //Console.WriteLine("Title: {0} \nAuthor: {1} \nPublisher: {2} \nRelease Date: {3} \nISBN Number: {4}",title,author,publisher,releaseDate,ISBN);
            //a.Stop();
            //Console.WriteLine("Second Clock: " + a.Elapsed);
        }
    }

    //part 22: WE HAVE SCHOOL IN SCHOOL THEIR ARE CLASSES AND STUDENT. Each class have teacher and each teacher teach some disciplain.
    class School
    {
        public static int totalNoOfteacher = 0;
        public static int totalNoOfStudent = 0;
        public static int totalNoOfClasses = 0;
        SchoolClass sc;
        SchoolStudent ss;
        Teacher t;
        public School()
        {



        }
        public void Main()
        {
            Console.WriteLine("Press: 1-Add Strenght   2-Get Info   3-To Get Total Info about School");
            int presskey = int.Parse(Console.ReadLine());
            if (presskey == 1)
            {
                Console.WriteLine("Press 1-ClassI  2-ClassII   3-ClassIII");
                int sckey = int.Parse(Console.ReadLine());
                if (sckey == 1)
                {
                    Console.WriteLine("1-Add Student  2-Add Teacher");
                    int key = int.Parse(Console.ReadLine());
                    if (key == 1 || key == 2)
                    {
                        sc.AddStdAndTeacherClass1(key);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
                else if (sckey == 2)
                {
                    Console.WriteLine("1-Add Student  2-Add Teacher");
                    int key = int.Parse(Console.ReadLine());
                    if (key == 1 || key == 2)
                    {
                        sc.AddStdAndTeacherClass2(key);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
                else if (sckey == 3)
                {
                    Console.WriteLine("1-Add Student  2-Add Teacher");
                    int key = int.Parse(Console.ReadLine());
                    if (key == 1 || key == 2)
                    {
                        sc.AddStdAndTeacherClass3(key);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }
            }
            else if (presskey == 2)
            {
                Console.WriteLine("Press for 1-ClassI  2-ClassII  3=ClassIII");
                int sckey = int.Parse(Console.ReadLine());
                if (sckey == 1)
                {
                    sc.ClassI();
                }
                else if (sckey == 2)
                {
                    sc.Class2();
                }
                else if (sckey == 3)
                {
                    sc.Class3();
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }
            }

            else if (presskey == 3)
            {
                Console.WriteLine("Total Number of Student: " + totalNoOfStudent);
                Console.WriteLine("Total Number of Teacher: " + totalNoOfteacher);
                School a = new School();
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }

        }

    }
    class SchoolClass
    {
        List<SchoolStudent> studentlistClass1 = new List<SchoolStudent>();
        List<Teacher> teacherlistClass1 = new List<Teacher>();

        List<SchoolStudent> studentlistClass2 = new List<SchoolStudent>();
        List<Teacher> teacherlistClass2 = new List<Teacher>();

        List<SchoolStudent> studentlistClass3 = new List<SchoolStudent>();
        List<Teacher> teacherlistClass3 = new List<Teacher>();


        public void ClassI()
        {
            for (int i = 0; i < studentlistClass1.Count; i++)
            {
                Console.WriteLine(studentlistClass1[i].GetStudentInfo());
            }


            foreach (SchoolStudent item in studentlistClass1)
            {
                Console.WriteLine(item.GetStudentInfo());
            }
            foreach (Teacher item in teacherlistClass1)
            {
                Console.WriteLine(item.GetTeacherInfo());
            }
            Console.WriteLine("Remaining Chair left " + SchoolStudent.NoofStudent);
            Console.WriteLine(studentlistClass1.Count);
            School ss = new School();
            ss.Main();
        }
        public void AddStdAndTeacherClass1(int key)
        {
            // use loop and take name for user my task
            studentlistClass1.Add(new SchoolStudent("Ahsan", 1));
            studentlistClass1.Add(new SchoolStudent("Usman", 2));
            studentlistClass1.Add(new SchoolStudent("Tahins", 3));
            studentlistClass1.Add(new SchoolStudent("Ebad", 4));
            studentlistClass1.Add(new SchoolStudent("Yawar", 5));

            teacherlistClass1.Add(new Teacher("Miss Tooba", Disciplain.Subject.Math, Disciplain.Excercise.Math));
            teacherlistClass1.Add(new Teacher("Sir Kashan", Disciplain.Subject.English, Disciplain.Excercise.English));
            teacherlistClass1.Add(new Teacher("Sir Ahmed", Disciplain.Subject.Urdu, Disciplain.Excercise.Urdu));

            if (key == 1)
            {
                Console.WriteLine("Enter Student Name: ");
                string stdName = Console.ReadLine();
                studentlistClass1.Add(new SchoolStudent(stdName, SchoolStudent.NoofStudent + 1));
            }
            else if (key == 2)
            {
                Console.WriteLine("ENter Teacher Name: ");
                String tchName = Console.ReadLine();
                teacherlistClass1.Add(new Teacher(tchName, Disciplain.Subject.Chemistry, Disciplain.Excercise.Chemistry));
            }
            School ss = new School();
            ss.Main();
        }


        public void Class2()
        {
            SchoolStudent.NoofStudent = 0;
            studentlistClass2.Add(new SchoolStudent("Ahsan", 1));
            studentlistClass2.Add(new SchoolStudent("Usman", 2));
            studentlistClass2.Add(new SchoolStudent("Tahins", 3));
            studentlistClass2.Add(new SchoolStudent("Ebad", 4));
            studentlistClass2.Add(new SchoolStudent("Yawar", 5));

            teacherlistClass2.Add(new Teacher("Miss Tooba", Disciplain.Subject.Math, Disciplain.Excercise.Math));
            teacherlistClass2.Add(new Teacher("Sir Kashan", Disciplain.Subject.English, Disciplain.Excercise.English));
            teacherlistClass2.Add(new Teacher("Sir Ahmed", Disciplain.Subject.Urdu, Disciplain.Excercise.Urdu));

            foreach (SchoolStudent item in studentlistClass2)
            {
                Console.WriteLine(item.GetStudentInfo());
            }
            foreach (Teacher item in teacherlistClass2)
            {
                Console.WriteLine(item.GetTeacherInfo());
            }
            Console.WriteLine("Remaining Chair left " + SchoolStudent.NoofStudent);
            Console.WriteLine("Total Number of student in school: " + School.totalNoOfStudent);
            School ss = new School();

        }
        public void AddStdAndTeacherClass2(int key)
        {
            if (key == 1)
            {
                Console.WriteLine("Enter Student Name: ");
                string stdName = Console.ReadLine();
                studentlistClass2.Add(new SchoolStudent(stdName, SchoolStudent.NoofStudent + 1));
            }
            else if (key == 2)
            {
                Console.WriteLine("ENter Teacher Name: ");
                String tchName = Console.ReadLine();
                teacherlistClass2.Add(new Teacher(tchName, Disciplain.Subject.Chemistry, Disciplain.Excercise.Chemistry));
            }
            School ss = new School();
        }

        public void Class3()
        {
            SchoolStudent.NoofStudent = 0;
            studentlistClass3.Add(new SchoolStudent("Ahsan", 1));
            studentlistClass3.Add(new SchoolStudent("Usman", 2));
            studentlistClass3.Add(new SchoolStudent("Tahins", 3));
            studentlistClass3.Add(new SchoolStudent("Ebad", 4));
            studentlistClass3.Add(new SchoolStudent("Yawar", 5));

            teacherlistClass3.Add(new Teacher("Miss Tooba", Disciplain.Subject.Math, Disciplain.Excercise.Math));
            teacherlistClass3.Add(new Teacher("Sir Kashan", Disciplain.Subject.English, Disciplain.Excercise.English));
            teacherlistClass3.Add(new Teacher("Sir Ahmed", Disciplain.Subject.Urdu, Disciplain.Excercise.Urdu));

            foreach (SchoolStudent item in studentlistClass3)
            {
                Console.WriteLine(item.GetStudentInfo());
            }
            foreach (Teacher item in teacherlistClass3)
            {
                Console.WriteLine(item.GetTeacherInfo());
            }

            Console.WriteLine("Remaining Chair left " + SchoolStudent.NoofStudent);
            Console.WriteLine("Total Number of student in school: " + School.totalNoOfStudent);
            School ss = new School();
        }
        public void AddStdAndTeacherClass3(int key)
        {
            if (key == 1)
            {
                Console.WriteLine("Enter Student Name: ");
                string stdName = Console.ReadLine();
                studentlistClass3.Add(new SchoolStudent(stdName, 6));
            }
            else if (key == 2)
            {
                Console.WriteLine("ENter Teacher Name: ");
                String tchName = Console.ReadLine();
                teacherlistClass3.Add(new Teacher(tchName, Disciplain.Subject.Chemistry, Disciplain.Excercise.Chemistry));
            }
            School ss = new School();
        }


    }
    public class SchoolStudent
    {
        static int noOfStudent = 0;

        public static int NoofStudent { get { return (15 - noOfStudent); } set { noOfStudent = value; } }
        public string StudentName { get; set; }
        public int StudentID { get; set; }
        public SchoolStudent()
        {
        }
        public SchoolStudent(string name, int rollNumber)
        {
            this.StudentName = name;
            this.StudentID = rollNumber;
            noOfStudent++;
            School.totalNoOfStudent++;
        }
        public string GetStudentInfo()
        {
            return "Name: " + StudentName + " " + "RollNumber: " + StudentID;
        }
    }

    class Teacher
    {
        public string Name { get; set; }
        public string disciplain { get; set; }
        public int noOfLecture { get; set; }
        public int noofExcercise { get; set; }

        static int noofteacher { get; set; }
        public Teacher()
        {
            noofteacher = 0;
        }
        public Teacher(string name, Disciplain.Subject displn, Disciplain.Excercise excercise)
        {
            this.Name = name;
            this.disciplain = displn.ToString();
            this.noOfLecture = (int)displn;
            this.noofExcercise = (int)excercise;
            noofteacher++;
            School.totalNoOfteacher++;
        }
        public string GetTeacherInfo()
        {
            return "Name: " + Name + " Disciplain: " + disciplain + " Number of Lecture: " + noOfLecture + " Number of Excercise: " + noofExcercise;
        }
    }

    class Disciplain
    {
        public enum Subject
        {
            Math = 50,
            English = 30,
            Urdu = 15,
            Physics = 35,
            Chemistry = 30,
            Science = 50
        }
        public enum Excercise
        {
            Math = 25,
            English = 15,
            Urdu = 10,
            Physics = 20,
            Chemistry = 15,
            Science = 15
        }
    }

    //part 23: generic list 


    //pending becoz of less knowledge
    class GenericList<T>
    {
        T[] arraylist = new T[10];
        int index = 0;
        public GenericList(params T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                index = i;
                arraylist[index] = array[i];
            }
        }
        public void Add(T val)
        {
            index++;
            if (index < arraylist.Length)
                arraylist[index] = val;
            else
                Console.WriteLine("Array is full");


            //part 24: auto resiz the array
            // autoresize the length of an array
            Array.Resize(ref arraylist, index + 2);
        }
        public void ItemByIndex(int i)
        {
            if (arraylist[i] == null)
                Console.WriteLine("Array is null");
            else
                Console.WriteLine(arraylist[i]);
        }
        public void Remove(int index)
        {
            // add the previous value in the removeindex to adjust the value
            for (int i = index; i < arraylist.Length - 1; i++)
            {
                arraylist[i] = arraylist[i + 1];
            }
        }
        public void Insert(T item, int position)
        {
            if (index < arraylist.Length)
            {
                // insert the value at given position 

                // store the value at that position
                T swap;
                swap = arraylist[position];
                // add current value at the index
                arraylist[position] = item;
                // adjust the value in array
                for (int i = position + 1; i < arraylist.Length; i++)
                {
                    T swap2;
                    swap2 = arraylist[i];
                    arraylist[i] = swap;
                    swap = swap2;
                }
            }
            else
                Console.WriteLine("Array is Full");

        }
        public void Clear()
        {
            //reinitialize to clear the array
            arraylist = new T[10];
        }
        public void Search(T value)
        {
            for (int i = 0; i < arraylist.Length; i++)
            {
                // compare in list
                if (EqualityComparer<T>.Default.Equals(arraylist[i], value))
                {
                    Console.WriteLine("Find");
                    break;
                }
            }
        }

        public void Display()
        {
            foreach (var item in arraylist)
            {
                if (!EqualityComparer<T>.Default.Equals(item, default(T)))
                    Console.Write(item);
            }
            Console.WriteLine();
        }
        public void DisplayWithIndex()
        {
            for (int i = 0; i < arraylist.Length; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(arraylist[i], default(T)))
                    Console.WriteLine("arraylist[{0}] = {1}", i, arraylist[i]);
            }
        }
    }

    //part 25: Fraction class  
    //part 26,27 left
    class Fraction
    {
        public double decimalvalue { get; set; }

        public static void Parse(string str)
        {
            Fraction f = new Fraction();
            f.decimalvalue = Convert.ToDouble(str);

        }
    }

    class Exercise
    {
        public void Main()
        {
            //SchoolClass a = new SchoolClass();

            //a.ClassI();
            //a.Class2();

            //School ss = new School();
            //ss.Main();

            //GenericList<int> myfirstlist = new GenericList<int>(1, 2, 3, 4, 5, 6);
            //myfirstlist.Display();
            //myfirstlist.DisplayWithIndex();

            //myfirstlist.Add(7);

            ////myfirstlist.Add(7);         
            //myfirstlist.Search(8);
            //myfirstlist.Search(7);
            //myfirstlist.ItemByIndex(3);
            //myfirstlist.DisplayWithIndex();
            //myfirstlist.Remove(3);
            //myfirstlist.DisplayWithIndex();
            //myfirstlist.ItemByIndex(3);
            //myfirstlist.Insert(10, 3);
            ////myfirstlist.Clear();
            ////myfirstlist.DisplayWithIndex();
            //myfirstlist.Search(10);

            //GenericList<string> str = new GenericList<string>("Burair", "Uzair", "Raahim");
            //str.Add("Shezar");
            //str.DisplayWithIndex();
            //str.Search("John");
            //str.Remove(3);
            //str.Insert("Samsung", 3);
            //str.DisplayWithIndex();
            //str.ItemByIndex(2);

            //Main8to20();

            //Way to change input in datetime
            //DateTime dt = DateTime.ParseExact(Console.ReadLine(),"d/M/yyyy",CultureInfo.InvariantCulture);            
            //Console.WriteLine(dt.ToString("dd/MMMM/yyyy",CultureInfo.InvariantCulture));
        }

        //part 1 to 7
        static void StdMain()
        {
            //display Main value 
            //StudentTest.StdMain();

            ////send reference address from objDataStore to 's', Now s allocate the same address as objDataStore  
            //Student s = StudentTest.ObjDataStore;
            ////display the address stored by objDataStore
            //Console.WriteLine(StudentTest.ObjDataStore);
            ////Output: Chap14DefineClass.Student

            ////get the student data from s (becoz 's' reference same address as objDataStore ) 
            //s.GetStudentDate();

            // from ObjDataStore property (which having the address of std1) i access the the method of 'Student' to get the data of 'std1' 
            StudentTest.ObjDataStore.GetStudentDate();
            //from method
            StudentTest.GetObjDataStore();


            //at first try this all getting null value becoz i declara in MainStd and objDataStore not getting any address untill i call that 
            //'MainStd' methodbut in above it work becoz i declara all the 'object' in 'Constructor' by Help Guidence
            //Console.WriteLine(StudentTest.ObjDataStore);
            //StudentTest.ObjDataStore.GetStudentDate();
        }

        static void Main8to20()
        {
            ////StdMain();   
            //MobilePhone.BatteryFeatures bty = new MobilePhone.BatteryFeatures();
            //MobilePhone.ScreenFeatures scn = new MobilePhone.ScreenFeatures();

            //MobilePhone m = new MobilePhone("asd", "sds", 123, "Burair", bty, scn);
            //m.PrintMobileFeatures();

            //MobilePhone a = new MobilePhone();
            //a.PrintMobileFeatures();

            //part 12
            //MobilePhone s = new MobilePhone("m1", "nokia", 123, "John");
            //GMS<MobilePhone> a = new GMS<MobilePhone>(s);
            //Console.WriteLine(a.ToString());            

            //GMSTest a = new GMSTest();

            //Call a = new Call();
            //a.MainPage();

            Library library = new Library();
            library.LibraryDisplay();

            //to see wht the hell is happening in list
            //List<int> a = new List<int>();
            //a.Add(1);
            //a.Add(2);

            //List<string> s = new List<string>();
            //s.Add("Adasd");
            //s.Add("sdfsad");
            //foreach (int item in a)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (string item in s)
            //{
            //    Console.WriteLine(item);
            //}
            //List<Book> b = new List<Book>();
            //Book b1 = new Book();
            //b1.title = "asd";
            //b1.author = "23";
            //b1.publisher = "pasidasd";
            //b1.releaseDate = default(DateTime);
            //b1.ISBN = 123;
            //b.Add(b1);
            //b1 = new Book("as32", "sawqe", "we213", default(DateTime), 3);
            //b.Add(b1);
            //foreach (Book item in b)
            //{
            //    item.GetBookInfo();
            //}

        }

    }

}
