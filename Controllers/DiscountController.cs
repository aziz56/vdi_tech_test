namespace Technical_TestVDI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Technical_TestVDI.Data;
using Technical_TestVDI.Models;

public class DiscountController : Controller
{
    private readonly AppDbContext _context;
    private static int _counter = 1;

    public DiscountController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index() => View();
    [HttpPost]
    public IActionResult Index(DiscountRequest req)
    {
        double diskon = CalculateDiscount(req.CustomerType.ToLower(), req.PointReward, req.TotalBelanja);
        double totalBayar = req.TotalBelanja - diskon;
        string transaksiId = $"{DateTime.Now:yyyyMMdd}_{_counter++.ToString("D5")}";

        var entity = new DiscountEntity
        {
            TransaksiId = transaksiId,
            CustomerType = req.CustomerType,
            PointReward = req.PointReward,
            TotalBelanja = req.TotalBelanja,
            Diskon = diskon,
            TotalBayar = totalBayar
        };

        _context.Discounts.Add(entity);
        _context.SaveChanges();

        var response = new DiscountResponsecs
        {
            TransaksiId = transaksiId,
            Diskon = diskon,
            TotalBayar = totalBayar
        };

        ViewBag.Response = response;
        return View(req);
    }

    private double CalculateDiscount(string tipe, int point, double total)
    {
        return tipe switch
        {
            "platinum" => point <= 300 ? total * 0.5 + 35 :
                          point <= 500 ? total * 0.5 + 50 : total * 0.5 + 68,
            "gold" => point <= 300 ? total * 0.25 + 25 :
                      point <= 500 ? total * 0.25 + 34 : total * 0.25 + 52,
            "silver" => point <= 300 ? total * 0.1 + 12 :
                        point <= 500 ? total * 0.1 + 27 : total * 0.1 + 39,
            _ => 0
        };
    } } 
