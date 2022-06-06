using AH_Project.Models;
using AH_Project.Models.Entities;
using AH_Project.Models.Services.Interfaces;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AH_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHost;

        public HomeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHost)
        {
            _unitOfWork = unitOfWork;
            _webHost = webHost;
        }

        public IActionResult Index(int Image_Id)
        {
            return View(new VmEvaluation() { Image_Id= Image_Id>0? Image_Id:0 });
        }

        public async Task<IActionResult> Index2()
        {
            return View(await _unitOfWork.Evaluations.FindAllAsync(s=>s.Id>0,null,null, new[] { "ModelCaption" }, s => s.ModelCaption.Image_Id,null));
        }

        // POST: Home/AddEvaluation
        [HttpPost]
        public async Task<IActionResult> Index(VmEvaluation model)
        {
            if (ModelState.IsValid)
            {
                var ModelCaptions = await _unitOfWork.ModelCaptions.FindAllAsync(s=>s.Image_Id==model.Image_Id);
                var Evaluations = await _unitOfWork.Evaluations.FindAllAsync(s=>s.ModelCaption.Image_Id==model.Image_Id);
                var Model1 = ModelCaptions.FirstOrDefault(s=>s.Model_Id==1);
                if (Model1 != null)
                {
                    var EModel1 = Evaluations.FirstOrDefault(s=>s.ModelCaptionId == Model1.Id);
                    if (EModel1 != null)
                    {
                        EModel1.Diversity = model.radio1_1;
                        EModel1.Novality = model.radio2_1;
                        EModel1.Informativeness = model.radio3_1;
                        EModel1.Fluency = model.radio4_1;
                        _unitOfWork.Evaluations.Update(EModel1);
                    }
                    else
                    {
                        await _unitOfWork.Evaluations.AddAsync(new Evaluation()
                        {
                            ModelCaptionId = Model1.Id,
                            Diversity = model.radio1_1,
                            Novality = model.radio2_1,
                            Informativeness = model.radio3_1,
                            Fluency = model.radio4_1,
                        });
                    }                       
                }
                var Model2 = ModelCaptions.FirstOrDefault(s => s.Model_Id == 2);
                if (Model2 != null)
                {
                    var EModel = Evaluations.FirstOrDefault(s => s.ModelCaptionId == Model2.Id);
                    if (EModel != null)
                    {
                        EModel.Diversity = model.radio1_2;
                        EModel.Novality = model.radio2_2;
                        EModel.Informativeness = model.radio3_2;
                        EModel.Fluency = model.radio4_2;
                        _unitOfWork.Evaluations.Update(EModel);
                    }
                    else
                    {
                        await _unitOfWork.Evaluations.AddAsync(new Evaluation()
                    {
                        ModelCaptionId = Model2.Id,
                        Diversity = model.radio1_2,
                        Novality = model.radio2_2,
                        Informativeness = model.radio3_2,
                        Fluency = model.radio4_2,
                    });
                }
                }
                var Model3 = ModelCaptions.FirstOrDefault(s => s.Model_Id == 3);
                if (Model3 != null)
                {
                    var EModel = Evaluations.FirstOrDefault(s => s.ModelCaptionId == Model3.Id);
                    if (EModel != null)
                    {
                        EModel.Diversity = model.radio1_3;
                        EModel.Novality = model.radio2_3;
                        EModel.Informativeness = model.radio3_3;
                        EModel.Fluency = model.radio4_3;
                        _unitOfWork.Evaluations.Update(EModel);
                    }
                    else
                    {
                        await _unitOfWork.Evaluations.AddAsync(new Evaluation()
                        {
                            ModelCaptionId = Model3.Id,
                            Diversity = model.radio1_3,
                            Novality = model.radio2_3,
                            Informativeness = model.radio3_3,
                            Fluency = model.radio4_3,
                        });
                    }
                }
                var Model4 = ModelCaptions.FirstOrDefault(s => s.Model_Id == 4);
                if (Model4 != null)
                {
                    var EModel = Evaluations.FirstOrDefault(s => s.ModelCaptionId == Model4.Id);
                    if (EModel != null)
                    {
                        EModel.Diversity = model.radio1_4;
                        EModel.Novality = model.radio2_4;
                        EModel.Informativeness = model.radio3_4;
                        EModel.Fluency = model.radio4_4;
                        _unitOfWork.Evaluations.Update(EModel);
                    }
                    else
                    {
                        await _unitOfWork.Evaluations.AddAsync(new Evaluation()
                        {
                            ModelCaptionId = Model4.Id,
                            Diversity = model.radio1_4,
                            Novality = model.radio2_4,
                            Informativeness = model.radio3_4,
                            Fluency = model.radio4_4,
                        });
                    }
                }
                var Model5 = ModelCaptions.FirstOrDefault(s => s.Model_Id == 5);
                if (Model5 != null)
                {
                    var EModel = Evaluations.FirstOrDefault(s => s.ModelCaptionId == Model5.Id);
                    if (EModel != null)
                    {
                        EModel.Diversity = model.radio1_5;
                        EModel.Novality = model.radio2_5;
                        EModel.Informativeness = model.radio3_5;
                        EModel.Fluency = model.radio4_5;
                        _unitOfWork.Evaluations.Update(EModel);
                    }
                    else
                    {
                        await _unitOfWork.Evaluations.AddAsync(new Evaluation()
                        {
                            ModelCaptionId = Model5.Id,
                            Diversity = model.radio1_5,
                            Novality = model.radio2_5,
                            Informativeness = model.radio3_5,
                            Fluency = model.radio4_5,
                        });
                    }
                }
                var Model6 = ModelCaptions.FirstOrDefault(s => s.Model_Id == 6);
                if (Model6 != null)
                {
                    var EModel = Evaluations.FirstOrDefault(s => s.ModelCaptionId == Model6.Id);
                    if (EModel != null)
                    {
                        EModel.Diversity = model.radio1_6;
                        EModel.Novality = model.radio2_6;
                        EModel.Informativeness = model.radio3_6;
                        EModel.Fluency = model.radio4_6;
                        _unitOfWork.Evaluations.Update(EModel);
                    }
                    else
                    {
                        await _unitOfWork.Evaluations.AddAsync(new Evaluation()
                        {
                            ModelCaptionId = Model6.Id,
                            Diversity = model.radio1_6,
                            Novality = model.radio2_6,
                            Informativeness = model.radio3_6,
                            Fluency = model.radio4_6,
                        });
                    }
                }
                TempData["success"] = "Add  successfully ";
                _unitOfWork.Complete();
                return View(model);
            }
            TempData["error"] = "IsValid! ";
            return View(model);
        }

        public async Task<IActionResult> ReadExcelcaptions()
        {
                string fileName = Path.Combine(_webHost.WebRootPath, "img/captions.xlsx");
            List<ModelCaption> ModelCaptions = new List<ModelCaption>();
            //var fileName = "./Users.xlsx";
            // For .net core, the next line requires the NuGet package, 
            // System.Text.Encoding.CodePages
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read()) //Each row of the file
                    {
                            if(reader.GetValue(0).ToString()== "Image_Id")
                        {

                        }
                        else
                        {
                            ModelCaptions.Add(new ModelCaption
                            {
                                Image_Id = int.Parse(reader.GetValue(0).ToString()),
                                Model_Id = int.Parse(reader.GetValue(1).ToString()),
                                Caption = reader.GetValue(2).ToString()
                            });
                        }
                        
                    }
                }
            }
            await _unitOfWork.ModelCaptions.AddRangeAsync(ModelCaptions);
             _unitOfWork.Complete();
            return Content("den..."+ ModelCaptions.Count());
        }

        public async Task<IActionResult> ReadExcelSimilarCaption()
        {
            string fileName = Path.Combine(_webHost.WebRootPath, "img/SimilarCaption.xlsx");
            List<SimilarCaption> SimilarCaptions = new List<SimilarCaption>();
            //var fileName = "./Users.xlsx";
            // For .net core, the next line requires the NuGet package, 
            // System.Text.Encoding.CodePages
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read()) //Each row of the file
                    {
                        if (reader.GetValue(0).ToString() == "Image_Id")
                        {

                        }
                        else
                        {
                            SimilarCaptions.Add(new SimilarCaption
                            {
                                Image_Id = int.Parse(reader.GetValue(0).ToString()),
                                Caption = reader.GetValue(1).ToString()
                            });
                        }

                    }
                }
            }
            await _unitOfWork.SimilarCaptions.AddRangeAsync(SimilarCaptions);
            _unitOfWork.Complete();
            return Content("den..." + SimilarCaptions.Count());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}