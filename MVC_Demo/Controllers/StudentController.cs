using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Models.Student;

namespace MVC_Demo.Controllers
{
    public class StudentController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var model = GetModelData();

            return View(model);
        }

        //Add new student infomation 
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentItemModel student)
        {
            try
            {
                //Check form input
                if (ModelState.IsValid)
                {
                    var listStudent = GetModelData();
                    var idStudent = listStudent.Students.Max(x => x.StudentId) + 1;
                    student.StudentId = idStudent;
                    listStudent.Students.Add(student);

                    TempData["StudentList"] = System.Text.Json.JsonSerializer.Serialize(listStudent);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Bạn phải điền đầy đủ thông tin";
                    return View();
                }
            }
            catch
            {
                return View();
            }

            return View("Index");
        }

        //Edit information student by id
        [HttpGet]
        public IActionResult UpdateStudent(int studentid)
        {
            var student = GetModelData().Students.FirstOrDefault(x => x.StudentId == studentid);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStudent(StudentItemModel student)
        {
            try
            {
                //Check form input
                if (ModelState.IsValid)
                {
                    var listStudent = GetModelData();
                    var obj = listStudent.Students.FirstOrDefault(x => x.StudentId == student.StudentId);
                    obj.Name = student.Name;
                    obj.Age = student.Age;

                    TempData["StudentList"] = System.Text.Json.JsonSerializer.Serialize(listStudent);
                    return View("Index", listStudent);
                }
                else
                {
                    ViewBag.error = "Bạn phải điền đầy đủ thông tin";
                    return View();
                }
            }
            catch
            {
                return View();
            }

            return View("Index");
            
        }

        //Delete student information by id
        [HttpGet]
        public IActionResult DeleteStudent(int studentid)
        {
            var lst = GetModelData();
            var student = lst.Students.FirstOrDefault(x => x.StudentId == studentid);
            lst.Students.Remove(student);

            TempData["StudentList"] = System.Text.Json.JsonSerializer.Serialize(lst);

            return RedirectToAction("Index", "Student");
        }
        StudentViewModel GetModelData()
        {
            TempData.Keep("StudentList");
            if (TempData["StudentList"] == null)
            {
                var model = new StudentViewModel()
                {
                    Students = new List<StudentItemModel>
                        {
                            new StudentItemModel{StudentId= 1 ,Name="Lê Xuân Trường", Age = 22 },

                            new StudentItemModel{StudentId= 2 ,Name="Lê Xuân Quang", Age = 23 },

                            new StudentItemModel{StudentId= 3 ,Name="Lê Xuân Thắng", Age = 23 },

                            new StudentItemModel{StudentId= 4 ,Name="Lê Xuân Tùng", Age = 23 },

                            new StudentItemModel{StudentId= 5 ,Name="Nguyễn Hoàng Vỹ", Age = 23 },

                            new StudentItemModel{StudentId= 6 ,Name="Cao Xuân Đạt", Age = 23 }

                        }
                };

                //Chuyen doi tempData sang dang Json
                TempData["StudentList"] = System.Text.Json.JsonSerializer.Serialize(model);

                return model;
            }
            else
            {
                var model = System.Text.Json.JsonSerializer.Deserialize<StudentViewModel>($"{TempData["StudentList"]}");

                return model;
            }
        }
    }
}
